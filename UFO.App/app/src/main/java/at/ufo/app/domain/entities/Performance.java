package at.ufo.app.domain.entities;

import android.os.Parcel;
import android.os.Parcelable;

import java.text.ParseException;
import java.util.Date;

import at.ufo.app.util.Constants;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public class Performance implements Parcelable {

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

    @Override
    public String toString() {
        return "Performance{" +
                "venue=" + venue +
                ", artist=" + artist +
                ", date=" + date +
                '}';
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeParcelable(venue, flags);
        dest.writeParcelable(artist, flags);
        dest.writeString(Constants.DATE_FORMATTER_FULL.format(date));
    }

    public static final Parcelable.Creator<Performance> CREATOR = new Parcelable.Creator<Performance>() {
        @Override
        public Performance createFromParcel(Parcel source) {
            return new Performance(source);
        }

        @Override
        public Performance[] newArray(int size) {
            return new Performance[size];
        }
    };

    private Performance(Parcel in) {
        venue = (Venue) in.readParcelable(Venue.class.getClassLoader());
        artist = (Artist) in.readParcelable(Artist.class.getClassLoader());
        try {
            date = Constants.DATE_FORMATTER_FULL.parse(in.readString());
        } catch (ParseException e) {
            e.printStackTrace();
        }
    }

    public Performance() {
    }
}
