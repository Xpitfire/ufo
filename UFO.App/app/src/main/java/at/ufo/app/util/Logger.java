package at.ufo.app.util;

import android.util.Log;

/**
 * Created by dinum_000 on 17.01.2016.
 */
public class Logger {

    public static final String LOG_TAG = "UFO-APP-LOG";

    public static void LogInfo(String message) {
        Log.d(LOG_TAG, message);
    }

    public static void LogSevere(String message, Exception ex) {
        Log.d(LOG_TAG, message, ex);
    }

}
