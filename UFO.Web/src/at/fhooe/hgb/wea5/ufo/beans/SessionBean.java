package at.fhooe.hgb.wea5.ufo.beans;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;
import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;
import at.fhooe.hgb.wea5.ufo.util.Crypto;
import at.fhooe.hgb.wea5.ufo.web.generated.SessionToken;

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

    private UfoDelegate delegate = ServiceLocator.getInstance().getUfoDelegate();

    private boolean isAuthenticated;
    private SessionToken token;

    public boolean isAuthenticated() {
        return isAuthenticated;
    }

    public boolean authenticate(String email, String password) {
        token = delegate.requestSessionToken(email, Crypto.md5(password));
        return isAuthenticated = delegate.login(token);
    }

    public void logout() {
        delegate.logout(token);
        this.isAuthenticated = false;
        token = null;
    }

    public SessionToken getSessionToken() {
        return token;
    }

}
