package at.ufo.app.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import at.ufo.app.domain.DomainDelegate;
import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Logger;

/**
 * Created by Dinu Marius-Constantin on 17.01.2016.
 */
public class DbAccess implements DomainDelegate {

    private static final ExecutorService executor = Executors.newFixedThreadPool(2);
    private DateFormat df = new SimpleDateFormat(Constants.DATE_FORMAT);

    private static final String url = "jdbc:mysql://sql4.freemysqlhosting.net:3306/sql4103380";
    private static final String user = "sql4103380";
    private static final String pass = "YWuCAqEDQV";

    private Connection createConnection(boolean autoCommit) {
        Connection con = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            con = DriverManager.getConnection(url, user, pass);
            con.setAutoCommit(autoCommit);
            Logger.LogInfo("Database connected to URL: " + url);
        } catch(Exception e) {
            Logger.LogSevere("Database connection failed due to a connection exception!", e);
        }
        return con;
    }

    private Connection createConnection() {
        return createConnection(true);
    }

    private Venue createVenue(String venueId, String name, String locationId, String locationName, double longitude, double latitude) {
        Venue v = new Venue();
        v.setVenueId(venueId);
        v.setName(name);
        v.setLocationId(locationId);
        v.setLocationName(locationName);
        v.setLongitude(longitude);
        v.setLatitude(latitude);
        return v;
    }

    private Venue createVenue(ResultSet rs) throws SQLException {
        return createVenue(rs.getString("VenueId"),
                rs.getString("VenueName"),
                rs.getString("LocationId"),
                rs.getString("LocationName"),
                rs.getDouble("Longitude"),
                rs.getDouble("Latitude"));
    }

    private Artist createArtist(int artistId, String name, String category, String categoryColor, String country, String countryCode, String picture, String promoVideo) {
        Artist a = new Artist();
        a.setArtistId(artistId);
        a.setName(name);
        a.setCategory(category);
        a.setCategoryColor(categoryColor);
        a.setCountry(country);
        a.setCountryCode(countryCode);
        a.setPicture(picture);
        a.setPromoVideo(promoVideo);
        return a;
    }

    private Artist createArtist(ResultSet rs) throws SQLException {
        return createArtist(rs.getInt("ArtistId"),
                rs.getString("ArtistName"),
                rs.getString("CategoryName"),
                rs.getString("CategoryColor"),
                rs.getString("CountryName"),
                rs.getString("CountryCode"),
                rs.getString("Picture"),
                rs.getString("PromoVideo"));
    }

    private Performance createPerformance(Date date, Artist artist, Venue venue) {
        Performance p = new Performance();
        p.setDate(date);
        p.setArtist(artist);
        p.setVenue(venue);
        return p;
    }

    private Performance createPerformance(ResultSet rs) throws SQLException, ParseException {
        return createPerformance(df.parse(rs.getString("Date")),
                createArtist(rs),
                createVenue(rs));
    }

    @Override
    public List<Performance> getUpcomingPerformances() {
        final List<Performance>  performances = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                try (Connection con = createConnection();
                     Statement st = con.createStatement();
                     ResultSet rs = st.executeQuery(SqlQueries.SELECT_LATEST_PERFORMANCES)) {
                    while (rs.next()) {
                        performances.add(createPerformance(rs));
                    }
                } catch (Exception e) {
                    Logger.LogSevere("Performance data request failed!", e);
                }
                return performances;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return performances;
    }

    @Override
    public List<Performance> getPerformancesByKeyword(final String keyword) {
        final List<Performance>  performances = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(SqlQueries.SELECT_PERFORMANCES_BY_KEYWORD)) {
                    pst.setString(1, keyword);
                    pst.setString(2, keyword);
                    pst.setString(3, keyword);
                    // TODO: Fistindex range parameter exception
                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        performances.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Performance data request failed!", e);
                }
                return performances;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return performances;
    }

}
