package at.ufo.app;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import org.w3c.dom.Text;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import at.ufo.app.domain.entities.Performance;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Helper;
import at.ufo.app.util.Logger;

public class PerformanceDetailsActivity extends AppCompatActivity {

    private ExecutorService executorService = Executors.newSingleThreadExecutor();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_performance_details);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            final Performance performance = extras.getParcelable("SelectedPerformance");

            FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
            fab.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
                    sharingIntent.setType("text/plain");
                    String shareBody = "Termin am " + Constants.DATE_FORMATTER_FULL.format(performance.getDate()) +  " in "
                            + performance.getVenue().getName() + ", "
                            + performance.getVenue().getLocationName() + ".";
                    sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT, "Aufführung: " + performance.getArtist().getName());
                    sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, shareBody);
                    startActivity(Intent.createChooser(sharingIntent, "Share via"));
                }
            });

            TextView tv = (TextView) findViewById(R.id.artist_details_name);
            tv.setText(performance.getArtist().getName());
            tv = (TextView) findViewById(R.id.artist_details_category);
            tv.setText(performance.getArtist().getCategory());

            final LatLng ll = new LatLng(performance.getVenue().getLatitude(), performance.getVenue().getLongitude());
            ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMapAsync(new OnMapReadyCallback() {
                @Override
                public void onMapReady(GoogleMap googleMap) {
                    googleMap.addMarker(new MarkerOptions().position(ll).title(performance.getVenue().getName()));

                    // Move the camera instantly to the selected location with a zoom of 15.
                    googleMap.moveCamera(CameraUpdateFactory.newLatLngZoom(ll, 17));
                    // Zoom in, animating the camera.
                    //googleMap.animateCamera(CameraUpdateFactory.zoomTo(15), 2000, null);
                }
            });

            String url = performance.getArtist().getPicture();
            if (url != null && !url.isEmpty()) {
                ImageView img = (ImageView) findViewById(R.id.artist_image_view);
                Future<Bitmap> f = executorService.submit(Helper.getBitmapFromURL(url));
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
