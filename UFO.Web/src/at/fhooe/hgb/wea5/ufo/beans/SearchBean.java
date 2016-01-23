package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import java.io.Serializable;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 22.01.2016
 */
@ManagedBean
@RequestScoped
public class SearchBean implements Serializable {

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

    public String redirect() {
        return "search.xhtml?query=" + searchKeyword + "&faces-redirect=true";
    }

}
