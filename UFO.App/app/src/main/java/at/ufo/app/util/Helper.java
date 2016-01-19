package at.ufo.app.util;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.Callable;

/**
 * Created by dinum_000 on 19.01.2016.
 */
public final class Helper {

    private Helper() {
    }

    public static Callable<Bitmap> getBitmapFromURL(final String src) {
        return new Callable<Bitmap>() {
            @Override
            public Bitmap call() throws Exception {
                try {
                    URL url = new URL(src);
                    HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                    connection.setDoInput(true);
                    connection.connect();
                    InputStream input = connection.getInputStream();
                    Bitmap myBitmap = BitmapFactory.decodeStream(input);
                    return myBitmap;
                } catch (IOException e) {
                    Logger.LogSevere("Failed to load bitmap!", e);
                    return null;
                }
            }
        };
    }

}
