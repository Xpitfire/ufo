package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 13.01.2016
 */
public interface UfoDelegate {

    Artist getArtistById(int id);
    List<Artist> getNextArtistsPage();
    List<Artist> getArtistPerKeyword(String keyword);

    Venue getVenueById(String venueId);
    List<Venue> getNextVenuesPage();
    List<Venue> getVenuesPerKeyword(String keyword);

    List<Performance> getPerformancesPerArtist(Artist artist);
    List<Performance> getPerformancesPerVenue(Venue venue);
    List<Performance> getNextPerformancesPage();
    List<Performance> getLatestPerformances();
    List<Performance> getPerformancesPerKeyword(String keyword);

    List<String> getAutoCompletion(String keyword);

}
