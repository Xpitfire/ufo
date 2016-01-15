package at.ufo.app.domain.entities;

import java.util.Date;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public class Performance {

    private Venue venue;
    private Artist artist;
    private Date date;

    public Venue getVenue() {
        return venue;
    }

    public void setVenue(Venue venue) {
        this.venue = venue;
    }

    public Artist getArtist() {
        return artist;
    }

    public void setArtist(Artist artist) {
        this.artist = artist;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
