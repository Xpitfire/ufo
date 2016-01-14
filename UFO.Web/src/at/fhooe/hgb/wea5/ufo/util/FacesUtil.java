package at.fhooe.hgb.wea5.ufo.util;

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

	/**
	 * Creates a new {@link Failure} object.
	 * 
	 * @param ex
	 * @param logger
	 * @return
	 */
	public static String createFailure(Exception ex, Logger logger) {
		Failure f = new Failure();
		f.setException(ex);
		f.setMessage(ex.getMessage());
		logger.severe(ex.getMessage());
		return "FailureEvent";
	}
	
	/**
	 * Returns the request parameter value defined by "name".
	 * 
	 * @param name
	 * @return
	 */
	public static String getRequestParameterValue(String name) {
		HttpServletRequest request = (HttpServletRequest) FacesContext.getCurrentInstance()
				.getExternalContext().getRequest();
		
		String paramValue = null;
		Enumeration<?> enumeration = request.getParameterNames();
		while (enumeration.hasMoreElements()) {
			String paramName = (String) enumeration.nextElement();
			if (paramName.indexOf(name) > 0) {
				paramValue = request.getParameter(paramName);
			}
		}
		
		return paramValue;
	}
}
