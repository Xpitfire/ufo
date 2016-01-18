package at.ufo.app.util;

import android.content.Context;
import android.widget.Toast;

/**
 * Created by dinum_000 on 18.01.2016.
 */
public final class Messenger {

    public void showToastMessage(Context context, String message) {
        Logger.LogInfo(message);
        Toast.makeText(context, message, Toast.LENGTH_SHORT).show();
    }

}
