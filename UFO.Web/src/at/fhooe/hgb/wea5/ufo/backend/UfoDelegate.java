package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.web.generated.*;

import java.util.Date;
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
    List<Performance> getPerformancesPerDate(Date date);
    List<Performance> getLatestPerformances();
    List<Performance> getPerformancesPerKeyword(String keyword);
    boolean delayPerformance(SessionToken token, Performance oldPerformance, Performance newPerformance);
    List<Category> getCategories();

    List<String> getAutoCompletion(String keyword);

    void cancelPerformance(SessionToken token, Performance p);

    SessionToken requestSessionToken(String username, String passwordHash);
    boolean login(SessionToken token);
    void logout(SessionToken token);
}
