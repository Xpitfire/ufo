package at.ufo.app;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import at.ufo.app.R;

/**
 * Created by Flow on 27.01.16.
 */
public class ArtistListFragment extends Fragment {

    public static ArtistListFragment newInstance() {

        ArtistListFragment f = new ArtistListFragment();
        Bundle b = new Bundle();

        return f;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View  v = inflater.inflate(R.layout.artist_list_layout, container, false);

        TextView tv = (TextView) v.findViewById(R.id.artist_header_text);
        tv.setText("Artist");

        return v;

    }
}
