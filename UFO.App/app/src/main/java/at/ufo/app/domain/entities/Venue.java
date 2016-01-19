package at.ufo.app.domain.entities;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public class Venue implements Parcelable {

    private String venueId;
    private String name;
    private String locationId;
    private String locationName;
    private double longitude;
    private double latitude;

    public String getVenueId() {
        return venueId;
    }

    public void setVenueId(String venueId) {
        this.venueId = venueId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLocationId() {
        return locationId;
    }

    public void setLocationId(String locationId) {
        this.locationId = locationId;
    }

    public String getLocationName() {
        return locationName;
    }

    public void setLocationName(String locationName) {
        this.locationName = locationName;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(venueId);
        dest.writeString(name);
        dest.writeString(locationId);
        dest.writeString(locationName);
        dest.writeDouble(longitude);
        dest.writeDouble(latitude);
    }

    public static final Parcelable.Creator<Venue> CREATOR = new Parcelable.Creator<Venue>() {
        @Override
        public Venue createFromParcel(Parcel source) {
            return new Venue(source);
        }

        @Override
        public Venue[] newArray(int size) {
            return new Venue[size];
        }
    };

    private Venue(Parcel in) {
        venueId = in.readString();
        name = in.readString();
        locationId = in.readString();
        locationName = in.readString();
        longitude = in.readDouble();
        latitude = in.readDouble();
    }

    public Venue() {
    }
}
