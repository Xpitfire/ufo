package at.ufo.app;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.view.View;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.ListView;
import android.widget.Toast;

import java.util.Date;
import java.util.List;

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

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        ListView lv = (ListView)findViewById(R.id.list_view_performance);
        PerformanceArrayAdapter paa = new PerformanceArrayAdapter(this);
        List<Performance> pl = DomainFactory.getDefaultDelegate().getUpcomingPerformances();

        Performance lastPerformance = null;
        for (Performance p : pl) {
            if (lastPerformance == null) {
                paa.addSectionHeaderItem(p);
            } else {
                String curDate = Constants.DATE_FORMATTER_DD.format(p.getDate());
                String oldDate = Constants.DATE_FORMATTER_DD.format(lastPerformance.getDate());
                if (!curDate.equals(oldDate)) {
                    paa.addSectionHeaderItem(p);
                } else {
                    paa.addItem(p);
                }
            }
            lastPerformance = p;
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
