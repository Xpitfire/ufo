package at.ufo.app.domain.entities;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public class Artist implements Parcelable {

    private int artistId;
    private String name;
    private String category;
    private String categoryColor;
    private String country;
    private String countryCode;
    private String picture;
    private String promoVideo;

    public int getArtistId() {
        return artistId;
    }

    public void setArtistId(int artistId) {
        this.artistId = artistId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getCountryCode() {
        return countryCode;
    }

    public void setCountryCode(String countryCode) {
        this.countryCode = countryCode;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public String getPromoVideo() {
        return promoVideo;
    }

    public void setPromoVideo(String promoVideo) {
        this.promoVideo = promoVideo;
    }

    public String getCategoryColor() {
        return categoryColor;
    }

    public void setCategoryColor(String categoryColor) {
        this.categoryColor = categoryColor;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(artistId);
        dest.writeString(name);
        dest.writeString(category);
        dest.writeString(categoryColor);
        dest.writeString(country);
        dest.writeString(countryCode);
        dest.writeString(picture);
        dest.writeString(promoVideo);
    }

    public static final Parcelable.Creator<Artist> CREATOR = new Parcelable.Creator<Artist>() {
        @Override
        public Artist createFromParcel(Parcel source) {
            return new Artist(source);
        }

        @Override
        public Artist[] newArray(int size) {
            return new Artist[size];
        }
    };

    private Artist(Parcel in) {
        artistId = in.readInt();
        name = in.readString();
        category = in.readString();
        categoryColor = in.readString();
        country = in.readString();
        countryCode = in.readString();
        picture = in.readString();
        promoVideo = in.readString();
    }

    public Artist() {
    }
}
