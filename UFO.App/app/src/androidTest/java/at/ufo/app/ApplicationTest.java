package at.ufo.app;

import android.app.Application;
import android.test.ApplicationTestCase;

import java.text.ParseException;
import java.util.Date;
import java.util.List;

import at.ufo.app.domain.DomainDelegate;
import at.ufo.app.domain.DomainFactory;
import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Page;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;
import at.ufo.app.util.Constants;

/**
 * <a href="http://d.android.com/tools/testing/testing_android.html">Testing Fundamentals</a>
 */
public class ApplicationTest extends ApplicationTestCase<Application> {

    protected DomainDelegate delegate;

    public ApplicationTest() {
        super(Application.class);
    }

    @Override
    protected void setUp() throws Exception {
        super.setUp();
        delegate = DomainFactory.getDefaultDelegate();
    }

    public void testUpcomingPerformancesAccess() {
        List<Performance> performances = delegate.getUpcomingPerformances();
        assertTrue(!performances.isEmpty());
    }

    public void testPerformancesKeywordAccess() {
        List<Performance> performances = delegate.getPerformancesByKeyword("Billy");
        assertTrue(!performances.isEmpty());
    }

    public void testPerformancesByArtistAccess() {
        Artist a = new Artist();
        a.setArtistId(39);
        List<Performance> performances = delegate.getPerformancesByArtist(a);
        assertTrue(!performances.isEmpty());
    }

    public void testPerformancesByVenueAccess() {
        Venue v = new Venue();
        v.setVenueId("A1");
        List<Performance> performances = delegate.getPerformancesByVenue(v);
        assertTrue(!performances.isEmpty());
    }

    public void testPerformancesByDateAccess() {
        Date d = null;
        try {
            d = Constants.DATE_FORMATTER_YYYY_MM_DD.parse("2015-11-15");
        } catch (ParseException e) {
            assertTrue(false);
            return;
        }
        List<Performance> performances = delegate.getPerformancesByDate(d);
        assertTrue(!performances.isEmpty());
    }

    public void testPerformanceByIdAccess() {
        try {
            Performance performance = delegate.getPerformanceById(64, Constants.DATE_FORMATTER_FULL.parse("2015-11-15 22:00:00"));
            assertTrue(performance != null);
        } catch (ParseException e) {
            assertTrue(false);
        }
    }

    public void testPerformancesLimitAccess() {
        List<Performance> performances = delegate.getPerformances(new Page());
        assertTrue(!performances.isEmpty());
    }

    public void testVenuesLimitAccess() {
        List<Venue> venues = delegate.getVenues(new Page());
        assertTrue(!venues.isEmpty());
    }

    public void testVenuesByKeywordAccess() {
        List<Venue> venues = delegate.getVenuesByKeyword("Landhaus");
        assertTrue(!venues.isEmpty());
    }

    public void testVenueByIdAccess() {
        Venue venue = delegate.getVenueById("A2");
        assertTrue(venue != null);
    }

    public void testArtistsLimitAccess() {
        List<Artist> artists = delegate.getArtists(new Page());
        assertTrue(!artists.isEmpty());
    }

    public void testArtistsByKeywordAccess() {
        List<Artist> artists = delegate.getArtistsByKeyword("Bryan");
        assertTrue(!artists.isEmpty());
    }

    public void testArtistByIdAccess() {
        Artist artist = delegate.getArtistById(443);
        assertTrue(artist != null);
    }

    public void testConnectionAlive() {
        assertTrue(delegate.isConnected());
    }
}