package at.fhooe.hgb.wea5.ufo.beans;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.ManagedProperty;
import javax.faces.bean.RequestScoped;
import javax.faces.context.FacesContext;
import java.io.Serializable;

/**
 * @author: Dinu Marius-Constantin
 * @date: 14.01.2016
 */
@ManagedBean(name = "loginBean")
@RequestScoped
public class LoginBean implements Serializable {

    @ManagedProperty(value = "#{sessionBean}")
    private SessionBean sessionBean;

    public void setSessionBean(SessionBean sessionBean) {
        this.sessionBean = sessionBean;
    }

    private String email;
    private String password;
    private String errorMessage;

    public void login() {
        if(password != null && !password.isEmpty()
                && email != null && !email.isEmpty()) {
            if(sessionBean.authenticate(email, password)) {
                FacesContext facesContext = FacesContext.getCurrentInstance();
                facesContext.getApplication().getNavigationHandler().handleNavigation(facesContext, null, "index?faces-redirect=true");
                errorMessage = "";
            } else {
                errorMessage = "Ungültige EMail Adresse oder falsches Passwort.";
            }
        }
    }

    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
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
