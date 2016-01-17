package at.ufo.app;


import android.app.ListActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;

import java.util.List;

import at.ufo.app.domain.entities.Performance;
import at.ufo.app.dummy.Performances;

/**
 * Created by Flow on 17.01.16.
 */
public class HomeActivity extends ListActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_main);


        PerformanceArrayAdapter paa = new PerformanceArrayAdapter(this);
        List<Performance> pl = Performances.GetDummyPerformances();

        paa.addAll(pl);

        setListAdapter(paa);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id) {
        String data = l.getAdapter().getItem(position).toString();
        Toast.makeText(this, data + " wurde ausgewählt", Toast.LENGTH_SHORT).show();
    }
}
