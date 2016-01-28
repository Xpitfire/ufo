package at.ufo.app.util;

import android.widget.AbsListView;

import java.util.List;

import at.ufo.app.domain.DomainFactory;
import at.ufo.app.domain.entities.Artist;
import at.ufo.app.domain.entities.Page;

/**
 * Created by Flow on 27.01.16.
 */
public class EndlessScrollListener implements AbsListView.OnScrollListener {

    private int visibleThreshold = 10;
    private int previousTotal = 0;
    private boolean loading = true;
    private List<Artist> list;
    private Page page;

    public EndlessScrollListener(Page p, List<Artist> l) {
        list = l;
        page = p;
        page.setRequestSize(10);
        page.next();
    }
    public EndlessScrollListener(int visibleThreshold) {
        this.visibleThreshold = visibleThreshold;
    }

    @Override
    public void onScroll(AbsListView view, int firstVisibleItem,
                         int visibleItemCount, int totalItemCount) {
        if (loading) {
            if (totalItemCount > previousTotal) {
                loading = false;
                previousTotal = totalItemCount;
            }
        }
        if (!loading && (totalItemCount - visibleItemCount) <= (firstVisibleItem + visibleThreshold)) {
            list = DomainFactory.getDefaultDelegate().getArtists(page);
            page.next();
            loading = true;
        }
    }

    @Override
    public void onScrollStateChanged(AbsListView view, int scrollState) {
    }
}