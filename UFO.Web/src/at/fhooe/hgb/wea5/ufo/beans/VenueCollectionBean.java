package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 17.01.2016
 */
@ManagedBean
@ViewScoped
public class VenueCollectionBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();
    private List<Venue> venues;

    @PostConstruct
    public void init() {
        venues = delegate.getNextVenuesPage();
    }

    public List<Venue> getVenues() {
        return venues;
    }

}
