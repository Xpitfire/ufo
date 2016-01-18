package at.ufo.app.db;

import at.ufo.app.util.Constants;

/**
 * Created by dinum_000 on 18.01.2016.
 */
public final class SqlQueries {

    private SqlQueries() {}

    public static final String SELECT_LATEST_PERFORMANCES =
            "SELECT * FROM performanceview WHERE DATE_ADD((SELECT Date FROM performanceview ORDER BY Date DESC LIMIT 1), INTERVAL -1 MONTH)";

    public static final String SELECT_PERFORMANCES_BY_ARTIST =
            "SELECT * FROM performanceview WHERE ArtistId = ?";

    public static final String SELECT_PERFORMANCES_BY_VENUE =
            "SELECT * FROM performanceview WHERE VenueId = ?";

    public static final String SELECT_PERFORMANCES_BY_DATE =
            "SELECT * FROM performanceview WHERE Date LIKE ?";

    public static final String SELECT_PERFORMANCES_LIMIT =
            "SELECT * FROM performanceview LIMIT ?,?";

    public static final String SELECT_PERFORMANCES_BY_KEYWORD =
            "SELECT * FROM performanceview WHERE ArtistName LIKE ? OR VenueName LIKE ? OR LocationName LIKE ? LIMIT " + Constants.REQUEST_SIZE;


    public static final String SELECT_ARTISTS_LIMIT =
            "SELECT * FROM artistview LIMIT ?,?";
    public static final String SELECT_ARTISTS_BY_KEYWORD =
            "SELECT * FROM artistview WHERE ArtistName LIKE ? LIMIT " + Constants.REQUEST_SIZE;


    public static final String SELECT_VENUES_LIMIT =
            "SELECT * FROM venueview LIMIT ?,?";
    public static final String SELECT_VENUES_BY_KEYWORD =
            "SELECT * FROM venueview WHERE VenueName LIKE ? OR LocationName LIKE ? LIMIT " + Constants.REQUEST_SIZE;

}
