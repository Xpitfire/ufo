package at.ufo.app;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;

/**
 * Created by Flow on 17.01.16.
 */
public class PerformanceArrayAdapter extends ArrayAdapter<Performance> {

    public PerformanceArrayAdapter(Context context) {
        super(context, -1);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if(convertView == null) {
            Context c = getContext();
            LayoutInflater infl = (LayoutInflater)c.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infl.inflate(R.layout.list_item_layout, null);
        }

        Performance performance = getItem(position);
        if(performance != null) {
            TextView tv = (TextView)convertView.findViewById(R.id.text_view_artist);
            tv.setText(performance.getArtist().getName());
            tv = (TextView)convertView.findViewById(R.id.text_view_category);
            tv.setText(performance.getArtist().getCategory());
            tv = (TextView)convertView.findViewById(R.id.text_view_venue);
            Venue v = performance.getVenue();
            tv.setText(v.getLocationName() + " - " + v.getName());
            tv = (TextView)convertView.findViewById(R.id.text_view_time);
            Date d = performance.getDate();
            DateFormat format = new SimpleDateFormat("HH:mm");
            tv.setText(format.format(d));
        }

        return convertView;
    }
}
