package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.util.Constants;
import at.fhooe.hgb.wea5.ufo.web.generated.*;

import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 16.01.2016
 */
public class UfoWebService implements UfoDelegate {

    private static final WebAccessServiceSoap webAccessProxy = new WebAccessService().getWebAccessServiceSoap();

    private PagingData artistPage;

    private PagingData initPage() {
        artistPage = webAccessProxy.requestArtistPagingData();
        return artistPage;
    }

    private PagingData getArtistPage() {
        if (artistPage == null) {
            initPage();
        }
        return artistPage;
    }

    private PagingData getNextPage() {
        artistPage.setOffset(artistPage.getOffset() + artistPage.getRequest());
        return artistPage;
    }

    private Artist prepareArtist(Artist artist) {
        BlobData data = artist.getPicture();
        if (data == null) {
            data = new BlobData();
            artist.setPicture(data);
        }
        if (artist.getPicture().getPath() == null) {
            artist.getPicture().setPath(Constants.IMAGE_PLACEHOLDER);
        }
        return artist;
    }

    private List<Artist> createArtists(PagingData page) {
        List<Artist> artists = webAccessProxy.getArtists(page).getArtist();
        artists.forEach(artist -> prepareArtist(artist));
        return artists;
    }

    @Override
    public List<Artist> getFirstArtistsPage() {
        return createArtists(getArtistPage());
    }

    @Override
    public List<Artist> getNextArtistsPage() {
        return createArtists(getNextPage());
    }

    @Override
    public Artist getArtistById(int id) {
        return webAccessProxy.getArtist(id);
    }
}
