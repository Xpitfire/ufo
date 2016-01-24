package at.fhooe.hgb.wea5.ufo.beans;

        import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
        import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
        import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
        import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

        import javax.annotation.PostConstruct;
        import javax.faces.bean.ManagedBean;
        import javax.faces.bean.ManagedProperty;
        import javax.faces.bean.ViewScoped;
        import javax.faces.context.FacesContext;
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
public class DelayPerformanceBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;
    public void setSessionBean(SessionBean sessionBean) { this.sessionBean = sessionBean; }

    @ManagedProperty(value = "#{venueCollectionBean}")
    private VenueCollectionBean venueListBean;
    public void setVenueListBean(VenueCollectionBean venueListBean) { this.venueListBean = venueListBean; }

    private List<String> venueNames;
    private String selectedVenue;
    private Performance performance;
    private int day;
    private int month;
    private int year;
    private int hour;
    private boolean isActive = false;

    @PostConstruct
    public void init() {
        venueNames = new ArrayList<>();
        venueNames.addAll(venueListBean.getVenues().stream().map(
                v -> prepareVenueName(v)).collect(Collectors.toList()));
    }

    private String prepareVenueName(Venue venue) {
        StringBuilder sb = new StringBuilder();
        sb.append(venue.getName())
                .append(" (")
                .append(venue.getVenueId())
                .append(")");
        return  sb.toString();
    }

    public void InvokePerformance(Performance p) {
        this.performance = p;
        selectedVenue = prepareVenueName(p.getVenue());

        day = p.getDateTime().getDay();
        month = p.getDateTime().getMonth();
        year = p.getDateTime().getYear();
        hour = p.getDateTime().getHour();
        isActive = true;
    }

    public void save(){
        Performance newPerformance = new Performance();
        newPerformance.setArtist(performance.getArtist());
        for(Venue v : venueListBean.getVenues()) {
            if(prepareVenueName(v).equals(selectedVenue)) {
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

        FacesContext facesContext = FacesContext.getCurrentInstance();
        facesContext.getApplication().getNavigationHandler().handleNavigation(facesContext, null, "index?faces-redirect=true");
    }

    public List<String> getVenueNames() {
        return venueNames;
    }

    public void setVenueNames(List<String> venueNames) {
        this.venueNames = venueNames;
    }

    public String getSelectedVenue() {
        return selectedVenue;
    }

    public void setSelectedVenue(String selectedVenue) {
        this.selectedVenue = selectedVenue;
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