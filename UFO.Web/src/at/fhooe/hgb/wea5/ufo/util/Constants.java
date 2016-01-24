package at.fhooe.hgb.wea5.ufo.util;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 14.01.2016
 */
public final class Constants {

    private Constants() {}

    public static final String IMAGE_PLACEHOLDER = "http://www.360fashion.net/wp-content/uploads/2013/01/image-placeholder-500x500.jpg?pfdrid_c=true";

    public static final SimpleDateFormat TIME_FORMATTER = new SimpleDateFormat("HH:mm");
    public static final SimpleDateFormat DATE_FORMATTER = new SimpleDateFormat("dd.MM.yyyy");
    public static final SimpleDateFormat FULL_DATE_FORMATTER = new SimpleDateFormat("dd.MM.yyyy HH:mm");

    public static final List<String> HOURS_LIST = new ArrayList<>();

    static {
        for (int i = 14; i < 24; i++) {
            HOURS_LIST.add(i + ":00");
        }
        HOURS_LIST.add("00:00");
    }

}
