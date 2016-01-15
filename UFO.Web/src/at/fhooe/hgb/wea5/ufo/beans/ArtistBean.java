package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.web.generated.Artist;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 14.01.2016
 */
@ManagedBean(name = "artistBean")
@RequestScoped
public class ArtistBean {

    private int id;
    private Artist artist;
    private List<Artist> artists;

    public void init() {

    }

    public int getId() {
        return id;
    }
    public void setId(int artistId) {
        this.id = artistId;
    }

    public Artist getArtist() {
        return artist;
    }

    public List<Artist> getAllArtists(){
        return artists;
    }

}
