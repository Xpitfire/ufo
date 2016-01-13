package at.fhooe.hgb.wea5.ufo;

import at.fhooe.hgb.wea5.ufo.backend.UfoDelegate;

import javax.servlet.ServletException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author: Dinu Marius-Constantin
 * @date: 13.01.2016.
 */
public class ServiceLocator {

    private static Logger logger = Logger.getLogger("UFO Web");

    private static ServiceLocator instance;
    private boolean initialized;

    private String wsHost;
    private String wsPort;
    private String wsUri;
    private String delegateClass;

    private ServiceLocator() {
        initialized = false;
    }

    public static synchronized ServiceLocator getInstance() {
        if (instance == null) {
            instance = new ServiceLocator();
        }
        return instance;
    }

    public void init(String wsHost, String wsPort, String wsUri, String delegateClass) {
        this.wsHost = wsHost;
        this.wsPort = wsPort;
        this.wsUri = wsUri;
        this.delegateClass = delegateClass;

        // TODO: initialize WebService

    }


    /*
	 * get those delegate object, which has been defined in the web.xml file
	 * The delegate object is created with the Java reflection mechanism.
	 */
    @SuppressWarnings("unchecked")
    public UfoDelegate getShopDelegate() throws ServletException {

        if (!initialized)
            throw new ServletException("ServiceLocator isn't initialized!");

        Class<UfoDelegate> cls;
        try {
            cls = (Class<UfoDelegate>) Class.forName(this.delegateClass);
            UfoDelegate delegate = (UfoDelegate) cls.getConstructors()[0].newInstance(new Object[] {});
            return delegate;
        } catch (Exception e) {
            logger.log(Level.SEVERE, "ServiceLocator: " + e);
        }
        return null;
    }

}
