package at.ufo.app.dummy;

import com.mysql.jdbc.NotImplemented;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;

import at.ufo.app.domain.DomainDelegate;
import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Page;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;

/**
 * Created by Flow on 17.01.16.
 */
public class DummyDomainDelegate implements DomainDelegate {

    private static Artist NewArtist(int id, String n, String ca, String co, String cou) {
        Artist a = new Artist();
        a.setArtistId(id);
        a.setName(n);
        a.setCategory(ca);
        a.setCategoryColor(co);
        a.setCountry(cou);
        return a;
    }

    private static Venue NewVenue(String id, String n, String locid, String locn, double lon, double lat) {
        Venue v = new Venue();
        v.setVenueId(id);
        v.setName(n);
        v.setLocationId(locid);
        v.setLocationName(locn);
        v.setLongitude(lon);
        v.setLatitude(lat);
        return v;
    }

    private static Performance NewPerformance(Venue v, Artist a, Date d) {
        Performance p = new Performance();
        p.setVenue(v);
        p.setArtist(a);
        p.setDate(d);
        return p;
    }

    @Override
    public List<Performance> getUpcomingPerformances() {
        List<Performance> l = new ArrayList<>();
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(0,"Blink 182","MU","#ff0000","US"), new Date(2016,07,11,14,00)));
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(1,"Sum 41","MU","#00ff00","US"), new Date(2016,07,11,15,00)));
        l.add(NewPerformance(NewVenue("P4","Platz","HA","Hauptplatz",14.1,14.1), NewArtist(2,"Jon Lajoie","MU","#0000ff","CA"), new Date(2016,07,11,16,00)));
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(3,"Less Than Jake","MU","#b00b1e","US"), new Date(2016,07,11,17,00)));
        l.add(NewPerformance(NewVenue("P4","Platz","HA","Hauptplatz",14.1,14.1), NewArtist(4,"Kontrust","MU","#432ff5","AT"), new Date(2016,07,11,18,00)));
        l.add(NewPerformance(NewVenue("P4","Platz","HA","Hauptplatz",14.1,14.1), NewArtist(5,"Curious","MU","#b5b5b5","AT"), new Date(2016,07,11,19,00)));
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(6,"Ektomorf","MU","#432ff5","US"), new Date(2016,07,11,20,00)));
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(7,"Wax Fang","MU","#432ff5","US"), new Date(2016,07,11,21,00)));
        l.add(NewPerformance(NewVenue("P4","Platz","HA","Hauptplatz",14.1,14.1), NewArtist(8,"Savlonic","MU","#432ff5","UK"), new Date(2016,07,11,22,00)));
        l.add(NewPerformance(NewVenue("R1","Altes Rathaus","HA","Hauptplatz",14.1,14.1), NewArtist(9,"Mr. Oizo","MU","#432ff5","FR"), new Date(2016,07,11,23,00)));
        return l;
    }

    @Override
    public List<Performance> getPerformancesByKeyword(String keyword) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Performance> getPerformancesByArtist(Artist artist) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Performance> getPerformancesByVenue(Venue venue) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Performance> getPerformancesByDate(Date date) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Performance> getPerformances(Page page) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public Performance getPerformanceById(int artistId, Date date) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Artist> getArtists(Page page) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Artist> getArtistsByKeyword(String keyword) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public Artist getArtistById(int id) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Venue> getVenues(Page page) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public List<Venue> getVenuesByKeyword(String keyword) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public Venue getVenueById(String id) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public boolean isConnected() {
        return true;
    }
}
