package at.fhooe.hgb.wea5.ufo.util;

import javax.faces.context.FacesContext;

/**
 * @author: Dinu Marius-Constantin
 * @date: 14.01.2016
 */
public class ContextHelper {

    public static void setSessionVariable(String name, Object value) {
        FacesContext.getCurrentInstance().getExternalContext().getSessionMap().put(name, value);
    }

    public static Object getSessionVariable(String name) {
        return FacesContext.getCurrentInstance().getExternalContext().getSessionMap().get(name);
    }

    public static String getRequestParameterValue(String name) {
        return FacesContext.getCurrentInstance().getExternalContext().getRequestParameterMap().get(name);
    }

}
