package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
@ManagedBean
@ViewScoped
public class VenueBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();
    private String venueId;
    private Venue venue;

    public void init() {
        venue = delegate.getVenueById(venueId);
    }

    public String getVenueId() {
        return venueId;
    }

    public void setVenueId(String venueId) {
        this.venueId = venueId;
    }

    public Venue getVenue() {
        return venue;
    }

}
