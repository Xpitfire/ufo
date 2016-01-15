package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.util.Crypto;
import at.fhooe.hgb.wea5.ufo.web.generated.SessionToken;
import at.fhooe.hgb.wea5.ufo.web.generated.User;
import at.fhooe.hgb.wea5.ufo.web.generated.WebAccessService;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import java.io.Serializable;

/**
 * @author: Dinu Marius-Constantin
 * @date: 15.01.2016
 */
@ManagedBean(name = "sessionBean")
@SessionScoped
public class SessionBean implements Serializable {

    private boolean isAuthenticated;
    private User user;
    private SessionToken token;

    public boolean isAuthenticated() {
        return isAuthenticated;
    }

    public boolean authenticate(String email, String password) {
        user = new User();
        user.setEMail(email);
        user.setPassword(Crypto.md5(password));
        WebAccessService service = new WebAccessService();
        token = service.getWebAccessServiceSoap().requestSessionToken(user);
        return isAuthenticated = (token != null);
    }

    public void logout() {
        this.isAuthenticated = false;
        user = null;
        token = null;
    }

}
