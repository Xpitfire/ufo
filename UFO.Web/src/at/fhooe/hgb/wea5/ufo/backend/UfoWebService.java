package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.util.Constants;
import at.fhooe.hgb.wea5.ufo.web.generated.*;

import java.util.ArrayList;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
public class UfoWebService implements UfoDelegate {

    private static final WebAccessServiceSoap webAccessProxy = new WebAccessService().getWebAccessServiceSoap();

    private PagingData artistsPage;
    private PagingData venuesPage;
    private PagingData performancesPage;

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

    private PagingData prepareNextPerformancesPage() {
        if (performancesPage == null) {
            performancesPage = webAccessProxy.requestPerformancePagingData();
        } else {
            performancesPage.setOffset(performancesPage.getOffset() + performancesPage.getRequest());
        }
        return performancesPage;
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
    public Artist getArtistById(int id) {
        return prepareArtist(webAccessProxy.getArtist(id));
    }

    @Override
    public Venue getVenueById(String venueId) {
        return webAccessProxy.getVenue(venueId);
    }

    @Override
    public List<Venue> getNextVenuesPage() {
        ArrayOfVenue tmp = webAccessProxy.getVenues(prepareNextVenuesPage());
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
        System.out.println();
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
    public List<Performance> getNextPerformancesPage() {
        ArrayOfPerformance tmp = webAccessProxy.getPerformances(prepareNextPerformancesPage());
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
    public List<String> getAutoCompletion(String keyword) {
        ArrayOfString tmp = webAccessProxy.getAutoCompletion(keyword);
        if (tmp == null)
            return new ArrayList<>();
        return tmp.getString();
    }
}
