package at.ufo.app;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.method.LinkMovementMethod;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.util.Async;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Helper;
import at.ufo.app.util.Logger;

public class ArtistDetailsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_artists_details);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            final Artist artist = extras.getParcelable("SelectedArtist");

            TextView tv = (TextView) findViewById(R.id.a_detail_name);
            tv.setText(artist.getName());
            tv = (TextView) findViewById(R.id.a_detail_category);
            tv.setText(artist.getCategory());
            tv = (TextView) findViewById(R.id.a_detail_country);
            tv.setText(artist.getCountry());
            tv = (TextView) findViewById(R.id.a_detail_video);
            if(artist.getPromoVideo() != null) {
                tv.setText(artist.getPromoVideo());
                tv.setMovementMethod(LinkMovementMethod.getInstance());
            } else {
                tv.setText("");
            }
            final ImageView img = (ImageView) findViewById(R.id.a_detail_image_view);

            String url = artist.getPicture();
            if (url != null && !url.isEmpty()) {
                Future<Bitmap> f = Async.getThreadPool().submit(Helper.getBitmapFromURL(url));
                try {
                    img.setImageBitmap(f.get());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } catch (Exception e) {
                    Logger.LogSevere("Could not set artist image", e);
                }
            }
        }
    }



}
