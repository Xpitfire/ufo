package at.ufo.app;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * Created by Flow on 27.01.16.
 */
public class VenueListFragment extends Fragment {

    private static VenueListFragment instance;

    public static VenueListFragment newInstance() {
        if (instance == null) {
            instance = new VenueListFragment();
            Bundle b = new Bundle();
        }
        return instance;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View  v = inflater.inflate(R.layout.venue_list_layout, container, false);

        TextView tv = (TextView) v.findViewById(R.id.venue_header_text);
        tv.setText("Venue");

        return v;

    }
}
