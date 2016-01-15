package at.ufo.app.domain;

import java.util.List;

import at.ufo.app.domain.entities.Performance;

/**
 * Created by Marius-Constantin on 1/15/2016.
 */
public interface DomainDelegate {

    List<Performance> getUpcomingPerformances();
    List<Performance> getPerformancesByKeyword(String keyword);

}
