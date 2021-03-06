package at.ufo.app.util;

import java.text.DateFormat;
import java.text.SimpleDateFormat;

/**
 * Created by dinum_000 on 17.01.2016.
 */
public class Constants {

    public static final String IMAGE_PLACEHOLDER = "placeholder.png";

    public static final DateFormat DATE_FORMATTER_FULL = new SimpleDateFormat(Constants.DATE_FORMAT_FULL);
    public static final DateFormat DATE_FORMATTER_YYYY_MM_DD = new SimpleDateFormat(Constants.DATE_FORMAT_YYYY_MM_DD);
    public static final DateFormat DATE_FORMATTER_DD_MM_YYYY = new SimpleDateFormat(Constants.DATE_FORMAT_DD_MM_YYYY);
    public static final DateFormat DATE_FORMATTER_DD = new SimpleDateFormat(Constants.DATE_FORMAT_DD);
    public static final DateFormat DATE_FORMATTER_HH_MM = new SimpleDateFormat(Constants.DATE_FORMAT_HH_MM);
    public static final DateFormat DATE_FORMATTER_YYYY = new SimpleDateFormat(Constants.DATE_FORMAT_YYYY);

    public static final String DATE_FORMAT_FULL = "yyyy-MM-dd HH:mm:ss";
    public static final String DATE_FORMAT_YYYY_MM_DD = "yyyy-MM-dd";
    public static final String DATE_FORMAT_DD_MM_YYYY = "dd.MM.yyyy";
    public static final String DATE_FORMAT_DD = "dd";
    public static final String DATE_FORMAT_HH_MM = "HH:mm";
    public static final String DATE_FORMAT_YYYY = "yyyy";

    public static final int REQUEST_SIZE = 50;
}
