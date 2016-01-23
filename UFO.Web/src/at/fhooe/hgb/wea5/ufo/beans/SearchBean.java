package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;

import javax.faces.bean.ManagedBean;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 22.01.2016
 */
@ManagedBean
public class SearchBean {

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    private String searchKeyword;

    public void setSearchKeyword(String searchKeyword) {
        this.searchKeyword = searchKeyword;
    }

    public String getSearchKeyword() {
        return searchKeyword;
    }

    public List<String> autocomplete(String query) {
        return delegate.getAutoCompletion(query);
    }



}
