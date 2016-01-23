package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.util.FacesUtil;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;
import at.fhooe.hgb.wea5.ufo.web.generated.Venue;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;
import java.io.Serializable;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 23.01.2016
 */
@ManagedBean
@ViewScoped
public class SearchResultBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    private List<Performance> performances;
    private List<Venue> venues;
    private List<Artist> artists;

    @PostConstruct
    public void init() {
        String searchKeyword = FacesUtil.getRequestParameterValue("query");

        if (searchKeyword != null && !searchKeyword.isEmpty()) {
            artists = delegate.getArtistPerKeyword(searchKeyword);
            venues = delegate.getVenuesPerKeyword(searchKeyword);
            performances = delegate.getPerformancesPerKeyword(searchKeyword);
        }
    }

    public List<Artist> getArtists() {
        return artists;
    }

    public List<Venue> getVenues() {
        return venues;
    }

    public List<Performance> getPerformances() {
        return performances;
    }


}
