package at.ufo.app;

import android.content.Intent;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import at.ufo.app.R;
import at.ufo.app.domain.DomainFactory;
import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Page;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.util.Constants;
import at.ufo.app.util.EndlessScrollListener;

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

        InitArtistTable(v);

        return v;

    }


    private void InitArtistTable(View view) {
        ListView lv = (ListView) view.findViewById(R.id.list_view_artist);
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent intent = new Intent(getActivity().getApplicationContext(), ArtistDetailsActivity.class);
                Artist p = (Artist)parent.getItemAtPosition(position);
                intent.putExtra("SelectedArtist", p);
                startActivity(intent);
            }
        });
        ArtistArrayAdapter aaa = new ArtistArrayAdapter(getActivity().getApplicationContext());
        Page p = new Page(0, 500);
        List<Artist> al;
        al = DomainFactory.getDefaultDelegate().getArtists(p);
        Collections.sort(al, new Comparator<Artist>() {
            @Override
            public int compare(Artist lhs, Artist rhs) {
                return lhs.getName().compareTo(rhs.getName());
            }
        });

        for(Artist a : al)
            aaa.addItem(a);
        lv.setAdapter(aaa);
        // lv.setOnScrollListener(new EndlessScrollListener(p, al));
    }
}
