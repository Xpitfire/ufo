package at.ufo.app;

import android.app.Application;
import android.test.ApplicationTestCase;

import java.util.List;

import at.ufo.app.db.DbAccess;
import at.ufo.app.domain.DomainDelegate;
import at.ufo.app.domain.entities.Performance;

/**
 * <a href="http://d.android.com/tools/testing/testing_android.html">Testing Fundamentals</a>
 */
public class ApplicationTest extends ApplicationTestCase<Application> {

    protected DomainDelegate delegate;

    public ApplicationTest() {
        super(Application.class);
    }

    @Override
    protected void setUp() throws Exception {
        super.setUp();
        delegate = new DbAccess();
    }

    public void testUpcomingPerformancesAccess() {
        List<Performance> performances = delegate.getUpcomingPerformances();
        assertTrue(!performances.isEmpty());
    }

    public void testKeywordPerformancesAccess() {
        List<Performance> performances = delegate.getPerformancesByKeyword("Billy");
        assertTrue(!performances.isEmpty());
    }
}