package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.Location;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.*;

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
    private Venue venue = new Venue();
    private List<Performance> performancesOverview;
    private SimpleDateFormat timeFormatter = new SimpleDateFormat("HH:mm");
    private SimpleDateFormat dateFormatter = new SimpleDateFormat("dd.MM.yyyy");

    private List<String> hours = new ArrayList<>();

    public PerformanceCollectionBean() {
        for (int i = 14; i < 24; i++) {
            hours.add(i + ":00");
        }
        hours.add("00:00");
    }

    public void initPerformancesPerArtist() {
        artist = delegate.getArtistById(artistId);
        performancesPerArtist = delegate.getPerformancesPerArtist(artist);
    }

    public void initPerformancesPerVenue() {
        venue = delegate.getVenueById(venueId);
        performancesPerVenue = delegate.getPerformancesPerVenue(venue);
    }

    @PostConstruct
    public void initPerformancesOverview() {
        performancesOverview = delegate.getLatestPerformances();
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

    public List<String> getHours() {
        return hours;
    }

    public String checkPerformanceAvailable(Performance p, String hour) {
        Calendar cal = p.getDateTime().toGregorianCalendar();
        String perfHour = timeFormatter.format(cal.getTime());
        return perfHour.equals(hour) ? p.getArtist().getName() : null;
    }

    public String toDateString(XMLGregorianCalendarImpl calendar) {
        return dateFormatter.format(calendar.toGregorianCalendar().getTime());
    }

}
