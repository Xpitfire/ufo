package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.web.generated.Artist;

import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 13.01.2016
 */
public interface UfoDelegate {

    List<Artist> getFirstArtistsPage();
    List<Artist> getNextArtistsPage();

    Artist getArtistById(int id);
}
