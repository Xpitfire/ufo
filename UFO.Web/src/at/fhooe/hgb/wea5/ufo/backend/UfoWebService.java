package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.util.Constants;
import at.fhooe.hgb.wea5.ufo.web.generated.*;

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
            venuesPage = webAccessProxy.requestArtistPagingData();
        } else {
            venuesPage.setOffset(venuesPage.getOffset() + venuesPage.getRequest());
        }
        return venuesPage;
    }

    private PagingData prepareNextPerformancesPage() {
        if (performancesPage == null) {
            performancesPage = webAccessProxy.requestArtistPagingData();
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

    private List<Artist> createArtists(PagingData page) {
        List<Artist> artists = webAccessProxy.getArtists(page).getArtist();
        artists.forEach(artist -> prepareArtist(artist));
        return artists;
    }

    @Override
    public List<Artist> getNextArtistsPage() {
        return createArtists(prepareNextArtistsPage());
    }

    @Override
    public Artist getArtistById(int id) {
        return webAccessProxy.getArtist(id);
    }

    @Override
    public Venue getVenueById(String venueId) {
        return webAccessProxy.getVenue(venueId);
    }

    @Override
    public List<Venue> getNextVenuesPage() {
        return webAccessProxy.getVenues(prepareNextVenuesPage()).getVenue();
    }

    @Override
    public List<Performance> getPerformancesPerArtist(Artist artist) {
        // TODO: find java.lang.NullPointerException
        //
        List<Performance> performances = webAccessProxy.getPerformancesPerArtist(artist).getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getPerformancesPerVenue(Venue venue) {
        List<Performance> performances = webAccessProxy.getPerformancesPerVenue(venue).getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }

    @Override
    public List<Performance> getNextPerformancesPage() {
        List<Performance> performances = webAccessProxy.getPerformances(prepareNextPerformancesPage()).getPerformance();
        performances.forEach(performance -> preparePerformance(performance));
        return performances;
    }
}
