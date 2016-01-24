package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.util.Constants;
import at.fhooe.hgb.wea5.ufo.web.generated.*;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.util.ArrayList;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
public class UfoWebService implements UfoDelegate {

    private static final WebAccessServiceSoap webAccessProxy = new WebAccessService().getWebAccessServiceSoap();

    private PagingData artistsPage;
    private PagingData venuesPage;

    private PagingData prepareNextArtistsPage() {
        if (artistsPage == null) {
            artistsPage = webAccessProxy.requestArtistPagingData();
        } else {
            artistsPage.setOffset(artistsPage.getOffset() + artistsPage.getRequest());
        }
        return artistsPage;
    }

    private PagingData prepareNextVenuesPage() {
        if (venuesPage == null) {
            venuesPage = webAccessProxy.requestVenuePagingData();
        } else {
            venuesPage.setOffset(venuesPage.getOffset() + venuesPage.getRequest());
        }
        return venuesPage;
    }

    private Artist prepareArtist(Artist artist) {
        BlobData data = artist.getPicture();
        if (data == null) {
            data = new BlobData();
            artist.setPicture(data);
        }
        if (artist.getPicture().getPath() == null) {
            artist.getPicture().setPath(Constants.IMAGE_PLACEHOLDER);
        }
        return artist;
    }

    private Performance preparePerformance(Performance performance) {
        prepareArtist(performance.getArtist());
        return performance;
    }

    @Override
    public List<Artist> getNextArtistsPage() {
        ArrayOfArtist tmp = webAccessProxy.getArtists(prepareNextArtistsPage());
        if (tmp == null)
            return new ArrayList<>();
        List<Artist> artists = tmp.getArtist();
        artists.forEach(artist -> prepareArtist(artist));
        return artists;
    }

    @Override
    public List<Artist> getArtistPerKeyword(String keyword) {
        ArrayOfArtist tmp = webAccessProxy.searchArtistsPerKeyword(keyword);
        if (tmp == null)
            return new ArrayList<>();
        List<Artist> artists = tmp.getArtist();
        artists.forEach(artist -> prepareArtist(artist));
        return artists;
    }

    @Override
    public Artist getArtistById(int id) {
        Artist a = webAccessProxy.getArtist(id);
        if (a == null)
            return prepareArtist(new Artist());
        return prepareArtist(a);
    }

    @Override
    public Venue getVenueById(String venueId) {
        Venue v = webAccessProxy.getVenue(venueId);
        if (v == null)
            return new Venue();
        return v;
    }

    @Override
    public List<Venue> getNextVenuesPage() {
        ArrayOfVenue tmp = webAccessProxy.getVenues(prepareNextVenuesPage());
        if (tmp == null)
            return new ArrayList<>();
        return tmp.getVenue();
    }

    @Override
    public List<Venue> getVenuesPerKeyword(String keyword) {
        ArrayOfVenue tmp = webAccessProxy.searchVenuesPerKeyword(keyword);
        if (tmp == null)
            return new ArrayList<>();
        return tmp.getVenue();
    }

    @Override
    public List<Performance> getPerformancesPerArtist(Artist artist) {
        ArrayOfPerformance tmp = webAccessProxy.getPerformancesPerArtist(artist);
        if (tmp == null)
            return new ArrayList<>();
        List<Performance> performances = tmp.getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getPerformancesPerVenue(Venue venue) {
        ArrayOfPerformance tmp = webAccessProxy.getPerformancesPerVenue(venue);
        if (tmp == null)
            return new ArrayList<>();
        List<Performance> performances = tmp.getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getPerformancesPerDate(Date date) {
        GregorianCalendar gcal = new GregorianCalendar();
        gcal.setTime(date);
        XMLGregorianCalendar xgcal;
        try {
            xgcal = DatatypeFactory.newInstance().newXMLGregorianCalendar(gcal);
        } catch (DatatypeConfigurationException e) {
            return new ArrayList<>();
        }
        ArrayOfPerformance tmp = webAccessProxy.getPerformancesPerDate(xgcal);
        if (tmp == null)
            return new ArrayList<>();
        List<Performance> performances = tmp.getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getLatestPerformances() {
        ArrayOfPerformance tmp = webAccessProxy.getLatestPerformances();
        if (tmp == null)
            return new ArrayList<>();
        List<Performance> performances = tmp.getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getPerformancesPerKeyword(String keyword) {
        ArrayOfPerformance tmp = webAccessProxy.searchPerformancesPerKeyword(keyword);
        if (tmp == null)
            return new ArrayList<>();
        List<Performance> performances = tmp.getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public boolean delayPerformance(SessionToken token, Performance oldPerformance, Performance newPerformance) {
        return webAccessProxy.delayPerformance(token, oldPerformance, newPerformance);
    }

    @Override
    public List<Category> getCategories() {
        PagingData page = webAccessProxy.requestCategoryPagingData();
        List<Category> categories = new ArrayList<>();
        if (page == null)
            return categories;

        ArrayOfCategory tmp = webAccessProxy.getCategories(page);
        while (tmp != null && tmp.getCategory() != null && tmp.getCategory().size() > 0) {
            categories.addAll(tmp.getCategory());
            page.setOffset(page.getOffset() + page.getRequest());
            tmp = webAccessProxy.getCategories(page);
        }
        return categories;
    }

    @Override
    public List<String> getAutoCompletion(String keyword) {
        ArrayOfString tmp = webAccessProxy.getPerformanceAutoCompletion(keyword);
        if (tmp == null)
            return new ArrayList<>();
        return tmp.getString();
    }

    @Override
    public void cancelPerformance(SessionToken token, Performance p) {
        webAccessProxy.removePerformance(token, p);
    }

    @Override
    public SessionToken requestSessionToken(String username, String passwordHash) {
        User user = new User();
        user.setEMail(username);
        user.setPassword(passwordHash);
        return webAccessProxy.requestSessionToken(user);
    }

    @Override
    public boolean login(SessionToken token) {
        return webAccessProxy.loginAdmin(token);
    }

    @Override
    public void logout(SessionToken token) {
        webAccessProxy.logoutAdmin(token);
    }
}
