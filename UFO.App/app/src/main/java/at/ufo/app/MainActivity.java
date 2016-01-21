package at.ufo.app;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.view.View;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.Date;
import java.util.List;
import java.util.Objects;

import at.ufo.app.domain.DomainDelegate;
import at.ufo.app.domain.DomainFactory;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.dummy.DummyDomainDelegate;
import at.ufo.app.util.Constants;
import at.ufo.app.util.Logger;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle(R.string.upcoming_performances);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        ListView lv = (ListView)findViewById(R.id.list_view_performance);
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent intent = new Intent(getApplicationContext(), PerformanceDetailsActivity.class);
                Performance p = (Performance)parent.getItemAtPosition(position);
                intent.putExtra("SelectedPerformance", p);
                startActivity(intent);
            }
        });
        PerformanceArrayAdapter paa = new PerformanceArrayAdapter(this);
        List<Performance> pl = DomainFactory.getDefaultDelegate().getUpcomingPerformances();

        Performance prevPerformance = null;
        String year = null;
        for (Performance p : pl) {
            if (prevPerformance == null) {
                paa.addSectionHeaderItem(p);
                year = Constants.DATE_FORMATTER_YYYY.format(p.getDate());
            } else {
                String curDay = Constants.DATE_FORMATTER_DD.format(p.getDate());
                String curYear = Constants.DATE_FORMATTER_YYYY.format(p.getDate());
                String prevDay = Constants.DATE_FORMATTER_DD.format(prevPerformance.getDate());

                if (year != null && !year.equals(curYear)) {
                    break;
                }
                if (!curDay.equals(prevDay)) {
                    paa.addSectionHeaderItem(p);
                }
            }
            paa.addItem(p);
            prevPerformance = p;
        }
        lv.setAdapter(paa);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

}
