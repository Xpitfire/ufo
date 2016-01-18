package at.ufo.app.domain;

import java.util.Date;
import java.util.List;

import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Page;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public interface DomainDelegate {

    List<Performance> getUpcomingPerformances();
    List<Performance> getPerformancesByKeyword(String keyword);
    List<Performance> getPerformancesByArtist(Artist artist);
    List<Performance> getPerformancesByVenue(Venue venue);
    List<Performance> getPerformancesByDate(Date date);
    List<Performance> getPerformances(Page page);
    List<Artist> getArtists(Page page);
    List<Artist> getArtistsByKeyword(String keyword);
    List<Venue> getVenues(Page page);
    List<Venue> getVenuesByKeyword(Page page);

}
