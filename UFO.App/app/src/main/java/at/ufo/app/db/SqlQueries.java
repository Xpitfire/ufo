package at.ufo.app.db;

/**
 * Created by dinum_000 on 18.01.2016.
 */
public final class SqlQueries {

    public static final String SELECT_PERFORMANCES_BY_KEYWORD =
            "SELECT * \n" +
            "  FROM performanceview \n" +
            " WHERE ArtistName LIKE '%?%' OR VenueName LIKE '%?%' OR LocationName LIKE '%?%'\n" +
            " LIMIT 50";

    private SqlQueries() {}

    public static final String SELECT_LATEST_PERFORMANCES =
            "SELECT *\n" +
            "  FROM performanceview\n" +
            " WHERE DATE_ADD((SELECT Date \n" +
            "  FROM performanceview \n" +
            " ORDER BY Date DESC LIMIT 1), \n" +
            "          INTERVAL -1 MONTH)";

    public static final String SELECT_PERFORMANCES_BY_ARTIST = "";
    public static final String SELECT_PERFORMANCES_BY_VENUE = "";

    public static final String SELECT_ARTISTS_LIMIT = "";
    public static final String SELECT_ARTISTS_BY_KEYWORD = "";

    public static final String SELECT_VENUES_LIMIT = "";
    public static final String SELECT_VENUES_BY_KEYWORD = "";

}
