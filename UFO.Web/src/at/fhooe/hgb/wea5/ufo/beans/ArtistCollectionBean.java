package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
@ManagedBean
@ViewScoped
public class ArtistCollectionBean implements Serializable {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();
    private List<Artist> artists = new ArrayList<>();

    @PostConstruct
    public void init() {
        List<Artist> tmp = delegate.getNextArtistsPage();
        while (tmp != null && tmp.size() > 0) {
            artists.addAll(tmp);
            tmp = delegate.getNextArtistsPage();
        }
    }

    public List<Artist> getArtists() {
        return artists;
    }

}
