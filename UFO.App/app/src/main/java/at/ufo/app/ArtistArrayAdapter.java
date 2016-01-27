package at.ufo.app;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.domain.entities.Venue;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Helper;
import at.ufo.app.util.Logger;

/**
 * Created by Flow on 17.01.16.
 */
public class ArtistArrayAdapter extends BaseAdapter {

    private ExecutorService executorService = Executors.newSingleThreadExecutor();
    private static final int TYPE_ITEM = 0;


    private List<Artist> artists = new ArrayList<>();
    private LayoutInflater inflater;

    public ArtistArrayAdapter(Context context) {
        inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public void addItem(final Artist item) {
        artists.add(item);
        notifyDataSetChanged();
    }

    @Override
    public int getCount() {
        return artists.size();
    }

    @Override
    public Artist getItem(int position) {
        return artists.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if(convertView == null) {
            convertView = inflater.inflate(R.layout.artist_list_item_layout, null);
        }
        Artist artist = getItem(position);

        if(artist != null) {
            TextView tv;


            tv = (TextView) convertView.findViewById(R.id.a_text_view_artist);
            String name = artist.getName();
            if (name.length() > 18) {
                name = name.substring(0, 18);
                name += "...";
            }
            tv.setText(name);
            tv = (TextView) convertView.findViewById(R.id.a_text_view_category);
            tv.setText(artist.getCategory());
            tv = (TextView) convertView.findViewById(R.id.a_text_view_country);
            String c = artist.getCountryCode();
            tv.setText(c);
            tv = (TextView) convertView.findViewById(R.id.a_layout_category_color);
            tv.setBackgroundColor(Color.parseColor(artist.getCategoryColor()));
            ImageView iv;
            iv = (ImageView) convertView.findViewById(R.id.a_image_view);


            String url = artist.getPicture();
            if (url != null && !url.isEmpty()) {
                Future<Bitmap> f = executorService.submit(Helper.getBitmapFromURL(url));
                try {
                    iv.setImageBitmap(f.get());
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } catch (Exception e) {
                    Logger.LogSevere("Could not set artist image", e);
                }
            } else {
                iv.setImageResource(R.mipmap.placeholder);
            }

        }

        return convertView;
    }

}
