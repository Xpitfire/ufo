package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 17.01.2016
 */
@ManagedBean
@ViewScoped
public class VenueCollectionBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();
    private List<Venue> venues = new ArrayList<>();

    @PostConstruct
    public void init() {
        List<Venue> tmp = delegate.getNextVenuesPage();
        while (tmp != null && tmp.size() > 0) {
            venues.addAll(tmp);
            tmp = delegate.getNextVenuesPage();
        }
        venues.sort((o1, o2) -> o1.getVenueId().compareTo(o2.getVenueId()));
    }

    public List<Venue> getVenues() {
        return venues;
    }

}
