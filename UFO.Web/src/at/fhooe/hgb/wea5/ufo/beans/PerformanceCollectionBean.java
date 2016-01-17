package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
@ManagedBean
@ViewScoped
public class PerformanceCollectionBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();
    private List<Performance> performancesPerArtist;
    private int artistId;
    private Artist artist;
    private List<Performance> performancesPerVenue;
    private String venueId;
    private Venue venue;
    private List<Performance> performancesOverview;
    private SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd.MM.yyyy hh:mm");

    public void initPerformancesPerArtist() {
        artist = delegate.getArtistById(artistId);
        performancesPerArtist = delegate.getPerformancesPerArtist(artist);
    }

    public void initPerformancesPerVenue() {
        venue = delegate.getVenueById(venueId);
        performancesPerVenue = delegate.getPerformancesPerVenue(venue);
    }

    public void initPerfomancesOverview() {
        performancesOverview = delegate.getNextPerformancesPage();
    }

    public List<Performance> getPerformancesPerArtist() {
        return performancesPerArtist;
    }

    public int getArtistId() {
        return artistId;
    }

    public void setArtistId(int artistId) {
        this.artistId = artistId;
    }

    public List<Performance> getPerformancesPerVenue() {
        return performancesPerVenue;
    }

    public String getVenueId() {
        return venueId;
    }

    public void setVenueId(String venueId) {
        this.venueId = venueId;
    }

    public List<Performance> getPerformancesOverview() {
        return performancesOverview;
    }

}
