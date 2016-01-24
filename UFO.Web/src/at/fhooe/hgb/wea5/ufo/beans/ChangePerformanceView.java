package at.fhooe.hgb.wea5.ufo.beans;

        import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
        import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
        import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
        import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

        import javax.annotation.PostConstruct;
        import javax.faces.bean.ManagedBean;
        import javax.faces.bean.ManagedProperty;
        import javax.faces.bean.ViewScoped;
        import javax.xml.datatype.DatatypeConfigurationException;
        import javax.xml.datatype.DatatypeFactory;
        import javax.xml.datatype.XMLGregorianCalendar;
        import java.io.Serializable;
        import java.util.*;
        import java.util.stream.Collectors;

/**
 * @author: Dinu Marius-Constantin
 * @date: 24.01.2016
 */
@ManagedBean
@ViewScoped
public class ChangePerformanceView implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }

    @ManagedProperty(value = "#{venueCollectionBean}")
    private VenueCollectionBean venueListBean;
    public void setVenueListBean(VenueCollectionBean venueListBean) { this.venueListBean = venueListBean; }

    private List<String> venues;
    private String pickedVenue;
    private Performance performance;
    private int day;
    private int month;
    private int year;
    private int hour;
    private boolean isActive = false;

    @PostConstruct
    public void init() {
        venues = new ArrayList<>();
        venues.addAll(venueListBean.getVenues().stream().map(Venue::getName).collect(Collectors.toList()));
    }

    public void InvokePerformance(Performance p) {
        this.performance = p;
        pickedVenue = p.getVenue().getName();

        day = p.getDateTime().getDay();
        month = p.getDateTime().getMonth();
        year = p.getDateTime().getYear();
        hour = p.getDateTime().getHour();
        isActive = true;
    }

    public void saveChanges(){
        Performance newPerformance = new Performance();
        newPerformance.setArtist(performance.getArtist());
        for(Venue v : venueListBean.getVenues()) {
            if(v.getName().equals(pickedVenue)) {
                newPerformance.setVenue(v);
                break;
            }
        }

        GregorianCalendar gcal = new GregorianCalendar();
        gcal.set(year, month - 1, day, hour, 0, 0);
        XMLGregorianCalendar xgcal;
        try {
            xgcal = DatatypeFactory.newInstance().newXMLGregorianCalendar(gcal);
            newPerformance.setDateTime(xgcal);
            boolean res = delegate.delayPerformance(sessionBean.getSessionToken(), performance, newPerformance);
            System.out.println("Performance changed: " + res);
        } catch(DatatypeConfigurationException e){
            System.out.println("Date not valid");
        }
    }


    public List<String> getVenues() {
        return venues;
    }

    public void setVenues(List<String> venues) {
        this.venues = venues;
    }

    public String getPickedVenue() {
        return pickedVenue;
    }

    public void setPickedVenue(String pickedVenue) {
        this.pickedVenue = pickedVenue;
    }

    public Performance getPerformance() {
        return performance;
    }

    public void setPerformance(Performance performance) {
        this.performance = performance;
    }

    public int getDay() {
        return day;
    }

    public void setDay(int day) {
        this.day = day;
    }

    public int getMonth() {
        return month;
    }

    public void setMonth(int month) {
        this.month = month;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public int getHour() {
        return hour;
    }

    public void setHour(int hour) {
        this.hour = hour;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }
}