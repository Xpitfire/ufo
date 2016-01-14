package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.util.FacesUtil;
import at.fhooe.hgb.wea5.ufo.web.generated.Artist;
import at.fhooe.hgb.wea5.ufo.web.generated.PagingData;
import at.fhooe.hgb.wea5.ufo.web.generated.WebAccessService;
import at.fhooe.hgb.wea5.ufo.web.generated.WebAccessServiceSoap;

import javax.annotation.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.List;

/**
 * @author: Dinu Marius-Constantin
 * @date: 14.01.2016
 */
@ManagedBean
@SessionScoped
public class LoginBean {
    private boolean isAuthenticated = false;
    private String username;
    private String password;
    private String errorMessage;

    public void login() {
        if(password != null && username != null) {
            //isAuthenticated = new UfoService().getUfoServiceSoap().authenticateUser(username, password);
            FacesUtil.getLogger().info("Perform login...");
            WebAccessService service = null;
            PagingData page = null;
            service = new WebAccessService();
            page = service.getWebAccessServiceSoap().requestArtistPagingData();
            service.getWebAccessServiceSoap().getArtist(page);

            List<Artist> artists = service.getWebAccessServiceSoap().getArtist(page).getArtist();
            artists.forEach(System.out::println);

            isAuthenticated = true;
        }

        if(isAuthenticated) {
            FacesContext facesContext = FacesContext.getCurrentInstance();
            String outcome = "index?faces-redirect=true";
            facesContext.getApplication().getNavigationHandler().handleNavigation(facesContext, null, outcome);
            errorMessage = "";
        } else {
            errorMessage = "Benutzername oder Passwort falsch.";
        }
    }

    public boolean isAuthenticated() {
        return isAuthenticated;
    }

    public void setAuthenticated(boolean authenticated) {
        this.isAuthenticated = authenticated;
    }

    public void logout() {
        this.isAuthenticated = false;
    }

    public String getUsername() {
        return username;
    }
    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword(){
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }

    public String getErrorMessage() {
        return errorMessage;
    }
    public void setErrorMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }

}
