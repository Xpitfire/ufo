package at.ufo.app;

import android.support.v4.app.Fragment;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.List;

import at.ufo.app.domain.DomainFactory;
import at.ufo.app.domain.entities.Performance;
import at.ufo.app.util.Constants;

/**
 * Created by Flow on 27.01.16.
 */
public class PerformanceListFragment extends Fragment {

    public static PerformanceListFragment newInstance() {

        PerformanceListFragment f = new PerformanceListFragment();
        Bundle b = new Bundle();

        f.setArguments(b);

        return f;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View  v = inflater.inflate(R.layout.performance_list_layout, container, false);

        InitPerformanceTable(v);

        return v;

    }


    private void InitPerformanceTable(View view) {
        ListView lv = (ListView) view.findViewById(R.id.list_view_performance);
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent intent = new Intent(getActivity().getApplicationContext(), PerformanceDetailsActivity.class);
                Performance p = (Performance)parent.getItemAtPosition(position);
                intent.putExtra("SelectedPerformance", p);
                startActivity(intent);
            }
        });
        PerformanceArrayAdapter paa = new PerformanceArrayAdapter(getActivity().getApplicationContext());
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
}