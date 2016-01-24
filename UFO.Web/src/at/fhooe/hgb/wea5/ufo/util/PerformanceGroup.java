package at.fhooe.hgb.wea5.ufo.util;

import at.fhooe.hgb.wea5.ufo.web.generated.Category;
import at.fhooe.hgb.wea5.ufo.web.generated.Performance;

import java.util.*;
import java.util.stream.Collectors;

/**
 * @author: Dinu Marius-Constantin
 * @date: 24.01.2016
 */
public final class PerformanceGroup {

    private Map<String, List<Performance>> venueMap;

    private PerformanceGroup() {
    }

    public static Set<String> getVenues(List<Performance> rawPerformances) {
        Set<String> venueSet = rawPerformances.stream().map(p -> p.getVenue().getVenueId()).collect(Collectors.toSet());
        return venueSet;
    }

    public static Set<String> getDates(List<Performance> rawPerformances) {
        Set<String> dateSet = rawPerformances.stream().map(p -> Constants.DATE_FORMATTER.format(p.getDateTime().toGregorianCalendar().getTime())).collect(Collectors.toSet());
        return dateSet;
    }

    public static Map<String, PerformanceGroup> buildGrouping(List<Performance> rawPerformances, List<Category> categories) {
        if (rawPerformances == null || rawPerformances.size() <= 0 || categories == null || categories.size() <= 0)
            return null;

        Map<String, PerformanceGroup> groupingMap = new TreeMap<>();

        Set<String> dateSet = getDates(rawPerformances);
        Set<String> venueSet = getVenues(rawPerformances);

        for (String d : dateSet) {
            PerformanceGroup pG = new PerformanceGroup();
            pG.venueMap = new TreeMap<>();
            groupingMap.put(d, pG);
            for (String v : venueSet) {
                List<Performance> pH = new ArrayList<>();
                pG.venueMap.put(v, pH);
                rawPerformances.stream()
                        .filter(p -> {
                            boolean res = d.equals(Constants.DATE_FORMATTER.format(p.getDateTime().toGregorianCalendar().getTime()))
                                    && v.equals(p.getVenue().getVenueId());
                            for (Category c : categories) {
                                if (c.getCategoryId().equals(p.getArtist().getCategory().getCategoryId()))
                                    return res;
                            }
                            return false;
                        })
                        .forEach(p -> pH.add(p));
            }
        }

        return groupingMap;
    }

    public Map<String, List<Performance>> getVenueMap() {
        return venueMap;
    }

}
