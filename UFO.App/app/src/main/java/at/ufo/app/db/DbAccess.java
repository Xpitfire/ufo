package at.ufo.app.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.ParseException;
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
import at.ufo.app.domain.entities.Page;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Logger;

/**
 * Created by Dinu Marius-Constantin on 17.01.2016.
 */
public class DbAccess implements DomainDelegate {

    private static final ExecutorService executor = Executors.newFixedThreadPool(2);

    // Administration web page: http://www.phpmyadmin.co/index.php
    //private static final String url = "jdbc:mysql://sql4.freemysqlhosting.net:3306/sql4104460";
    //private static final String user = "sql4104460";
    //private static final String pass = "6fMmkYtu3k";
    private static final String url = "jdbc:mysql://192.168.0.110:3306/ufo";
    private static final String user = "xpitfire";
    private static final String pass = "matrix3788";

    private Connection createConnection() {
        Connection con = null;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            con = DriverManager.getConnection(url, user, pass);
            Logger.LogInfo("Database connected to URL: " + url);
        } catch(Exception e) {
            Logger.LogSevere("Database connection failed due to a connection exception!", e);
        }
        return con;
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
        return createPerformance(Constants.DATE_FORMATTER_FULL.parse(rs.getString("Date")),
                createArtist(rs),
                createVenue(rs));
    }

    @Override
    public List<Performance> getUpcomingPerformances() {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                try (Connection con = createConnection();
                     Statement st = con.createStatement();
                     ResultSet rs = st.executeQuery(SqlQueries.SELECT_LATEST_PERFORMANCES)) {
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Performance> getPerformancesByKeyword(final String keyword) {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCES_BY_KEYWORD;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    String placeholder = "%" + keyword + "%";
                    pst.setString(1, placeholder);
                    pst.setString(2, placeholder);
                    pst.setString(3, placeholder);

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query data request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Performance> getPerformancesByArtist(final Artist artist) {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCES_BY_ARTIST;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, artist.getArtistId());

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Performance> getPerformancesByVenue(final Venue venue) {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCES_BY_VENUE;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setString(1, venue.getVenueId());

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Performance> getPerformancesByDate(final Date date) {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCES_BY_DATE;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setString(1, "%" + Constants.DATE_FORMATTER_YYYY_MM_DD.format(date) + "%");

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Performance> getPerformances(final Page page) {
        final List<Performance>  list = new ArrayList<>();
        Callable<List<Performance>> task = new Callable<List<Performance>>() {
            @Override
            public List<Performance> call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCES_LIMIT;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, page.getOffset());
                    pst.setInt(2, page.getRequestSize());

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createPerformance(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Performance>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public Performance getPerformanceById(final int artistId, final Date date) {
        Callable<Performance> task = new Callable<Performance>() {
            @Override
            public Performance call() throws Exception {
                String query = SqlQueries.SELECT_PERFORMANCE_BY_ID;
                Performance p = null;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, artistId);
                    pst.setString(2, Constants.DATE_FORMATTER_FULL.format(date));

                    ResultSet rs = pst.executeQuery();
                    if (rs.next()) {
                        p = createPerformance(rs);
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return p;
            }
        };
        Future<Performance> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return null;
    }

    @Override
    public List<Artist> getArtists(final Page page) {
        final List<Artist>  list = new ArrayList<>();
        Callable<List<Artist>> task = new Callable<List<Artist>>() {
            @Override
            public List<Artist> call() throws Exception {
                String query = SqlQueries.SELECT_ARTISTS_LIMIT;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, page.getOffset());
                    pst.setInt(2, page.getRequestSize());

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createArtist(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Artist>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Artist> getArtistsByKeyword(final String keyword) {
        final List<Artist>  list = new ArrayList<>();
        Callable<List<Artist>> task = new Callable<List<Artist>>() {
            @Override
            public List<Artist> call() throws Exception {
                String query = SqlQueries.SELECT_ARTISTS_BY_KEYWORD;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    String placeholder = "%" + keyword + "%";
                    pst.setString(1, placeholder);

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createArtist(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query data request failed!", e);
                }
                return list;
            }
        };
        Future<List<Artist>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public Artist getArtistById(final int id) {
        Callable<Artist> task = new Callable<Artist>() {
            @Override
            public Artist call() throws Exception {
                String query = SqlQueries.SELECT_ARTIST_BY_ID;
                Artist a = null;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, id);

                    ResultSet rs = pst.executeQuery();
                    if (rs.next()) {
                        a = createArtist(rs);
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return a;
            }
        };
        Future<Artist> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return null;
    }

    @Override
    public List<Venue> getVenues(final Page page) {
        final List<Venue>  list = new ArrayList<>();
        Callable<List<Venue>> task = new Callable<List<Venue>>() {
            @Override
            public List<Venue> call() throws Exception {
                String query = SqlQueries.SELECT_VENUES_LIMIT;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setInt(1, page.getOffset());
                    pst.setInt(2, page.getRequestSize());

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createVenue(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return list;
            }
        };
        Future<List<Venue>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public List<Venue> getVenuesByKeyword(final String keyword) {
        final List<Venue>  list = new ArrayList<>();
        Callable<List<Venue>> task = new Callable<List<Venue>>() {
            @Override
            public List<Venue> call() throws Exception {
                String query = SqlQueries.SELECT_VENUES_BY_KEYWORD;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    String placeholder = "%" + keyword + "%";
                    pst.setString(1, placeholder);
                    pst.setString(2, placeholder);

                    ResultSet rs = pst.executeQuery();
                    while (rs.next()) {
                        list.add(createVenue(rs));
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query data request failed!", e);
                }
                return list;
            }
        };
        Future<List<Venue>> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return list;
    }

    @Override
    public Venue getVenueById(final String id) {
        Callable<Venue> task = new Callable<Venue>() {
            @Override
            public Venue call() throws Exception {
                String query = SqlQueries.SELECT_VENUE_BY_ID;
                Venue v = null;
                try (Connection con = createConnection();
                     PreparedStatement pst = con.prepareStatement(query)) {
                    pst.setString(1, id);

                    ResultSet rs = pst.executeQuery();
                    if (rs.next()) {
                        v = createVenue(rs);
                    }
                    rs.close();
                } catch (Exception e) {
                    Logger.LogSevere("Query request failed!", e);
                }
                return v;
            }
        };
        Future<Venue> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return null;
    }

    @Override
    public boolean isConnected() {
        Callable<Boolean> task = new Callable<Boolean>() {
            @Override
            public Boolean call() throws Exception {
                boolean online = false;
                try (Connection con = createConnection()) {
                    online = !con.isClosed();
                } catch (Exception e) {
                    Logger.LogSevere("Ping request failed!", e);
                }
                return online;
            }
        };
        Future<Boolean> future = executor.submit(task);
        try {
            return future.get();
        } catch (InterruptedException | ExecutionException e) {
            Logger.LogSevere("Failed to process concurrent Future call!", e);
        }
        return false;
    }

}
