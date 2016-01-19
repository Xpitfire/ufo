package at.ufo.app;

import android.content.Context;
import android.graphics.Color;
import android.text.Layout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Logger;

/**
 * Created by Flow on 17.01.16.
 */
public class PerformanceArrayAdapter extends BaseAdapter {

    private static final int TYPE_ITEM = 0;
    private static final int TYPE_SEPARATOR = 1;

    private List<Performance> performances = new ArrayList<>();
    private Set<Integer> sectionHeader = new TreeSet<>();
    private LayoutInflater inflater;

    public PerformanceArrayAdapter(Context context) {
        inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public void addItem(final Performance item) {
        performances.add(item);
        notifyDataSetChanged();
    }

    public void addSectionHeaderItem(final Performance item) {
        performances.add(item);
        sectionHeader.add(performances.size() - 1);
        notifyDataSetChanged();
    }

    @Override
    public int getItemViewType(int position) {
        return sectionHeader.contains(position) ? TYPE_SEPARATOR : TYPE_ITEM;
    }

    @Override
    public int getViewTypeCount() {
        return 2;
    }

    @Override
    public int getCount() {
        return performances.size();
    }

    @Override
    public Performance getItem(int position) {
        return performances.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if(convertView == null) {
            convertView = inflater.inflate(R.layout.list_item_layout, null);
        }
        int rowType = getItemViewType(position);
        Performance performance = getItem(position);

        if(performance != null) {
            TextView tv;
            switch (rowType) {
                case TYPE_ITEM:
                    tv = (TextView) convertView.findViewById(R.id.text_view_artist);
                    String name = performance.getArtist().getName();
                    if (name.length() > 18) {
                        name = name.substring(0, 18);
                        name += "...";
                    }
                    tv.setText(name);
                    tv = (TextView) convertView.findViewById(R.id.text_view_category);
                    tv.setText(performance.getArtist().getCategory());
                    tv = (TextView) convertView.findViewById(R.id.text_view_venue);
                    Venue v = performance.getVenue();
                    tv.setText(v.getLocationName() + " - " + v.getName());
                    tv = (TextView) convertView.findViewById(R.id.text_view_time);
                    tv.setText(Constants.DATE_FORMATTER_HH_MM.format(performance.getDate()));
                    tv = (TextView) convertView.findViewById(R.id.layout_category_color);
                    tv.setBackgroundColor(Color.parseColor(performance.getArtist().getCategoryColor()));
                    break;
                case TYPE_SEPARATOR:
                    tv = (TextView) convertView.findViewById(R.id.textSeparator);
                    tv.setVisibility(View.VISIBLE);
                    tv.setText(Constants.DATE_FORMATTER_DD_MM_YYYY.format(performance.getDate()));
                    View view = convertView.findViewById(R.id.layout_artist_box);
                    view.setVisibility(View.GONE);
                    break;
            }
        }

        return convertView;
    }

}
