package at.fhooe.hgb.wea5.ufo.util;

import at.fhooe.hgb.wea5.ufo.beans.FailureBean;

import java.util.Enumeration;
import java.util.logging.Logger;

import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;

/**
 * Util class for common JSF methods.
 * 
 * @author snadschlaeger
 */
public class FacesUtil {

	public static Logger getLogger() {
		return Logger.getLogger("UFO Web");
	}

	/**
	 * Creates a new {@link FailureBean} object.
	 * 
	 * @param ex
	 * @param logger
	 * @return
	 */
	public static String createFailure(Exception ex, Logger logger) {
		FailureBean f = new FailureBean();
		f.setException(ex);
		f.setMessage(ex.getMessage());
		logger.severe(ex.getMessage());
		return "FailureEvent";
	}

	public static String redirect(String eventName) {
		return eventName + "Event";
	}

	/**
	 * Returns the request parameter value defined by "name".
	 * 
	 * @param name
	 * @return
	 */
	public static String getRequestParameterValue(String name) {
		HttpServletRequest request = (HttpServletRequest) FacesContext.getCurrentInstance().getExternalContext().getRequest();
		return (request != null) ? request.getParameter(name) : "";
	}
}
