package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.util.PerformanceGroup;
import at.fhooe.hgb.wea5.ufo.util.Constants;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;
import org.primefaces.event.SelectEvent;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.*;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
@ManagedBean
@ViewScoped
public class PerformanceCollectionBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }

    private List<Performance> performancesPerArtist;
    private int artistId;
    private Artist artist;
    private List<Performance> performancesPerVenue;
    private String venueId;
    private Venue venue = new Venue();
    private List<Performance> performancesOverview;
    private Map<String, PerformanceGroup> groupMap;


    private Date date = Calendar.getInstance().getTime();

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
        groupMap = PerformanceGroup.buildGrouping(performancesOverview);
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

    public List<String> getHours() {
        return Constants.HOURS_LIST;
    }

    public String checkPerformanceAvailable(Performance p, String hour) {
        Calendar cal = p.getDateTime().toGregorianCalendar();
        String perfHour = Constants.TIME_FORMATTER.format(cal.getTime());
        return perfHour.equals(hour) ? p.getArtist().getName() : null;
    }

    public String toFullDateString(XMLGregorianCalendarImpl calendar) {
        return Constants.FULL_DATE_FORMATTER.format(calendar.toGregorianCalendar().getTime());
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Date getDate() {
        return date;
    }

    public void dateChange(SelectEvent event)  {
        this.date = (Date)event.getObject();
        performancesOverview = delegate.getPerformancesPerDate(date);
        groupMap = PerformanceGroup.buildGrouping(performancesOverview);
    }

    public void cancelAction(Performance p) {
        if (!sessionBean.isAuthenticated())
            return;
        performancesOverview.remove(p);
        groupMap = PerformanceGroup.buildGrouping(performancesOverview);
        delegate.cancelPerformance(sessionBean.getSessionToken(), p);
    }

    public Map<String, PerformanceGroup> getGroupMap() {
        return groupMap;
    }

}
