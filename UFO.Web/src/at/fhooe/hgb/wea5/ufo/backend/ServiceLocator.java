package at.fhooe.hgb.wea5.ufo.backend;

import at.fhooe.hgb.wea5.ufo.util.FacesUtil;

import java.util.logging.Level;

/**
 * @author: Dinu Marius-Constantin
 * @date: 13.01.2016.
 */
public class ServiceLocator {

    private static ServiceLocator instance;

    private String delegateClass;

    private ServiceLocator() {
    }

    public static synchronized ServiceLocator getInstance() {
        if (instance == null) {
            instance = new ServiceLocator();
        }
        return instance;
    }

    public void init(String delegateClass) {
        this.delegateClass = delegateClass;
    }

    /*
	 * get those delegate object, which has been defined in the web.xml file
	 * The delegate object is created with the Java reflection mechanism.
	 */
    public UfoDelegate getUfoDelegate() {
        Class<UfoDelegate> cls;
        try {
            cls = (Class<UfoDelegate>) Class.forName(this.delegateClass);
            UfoDelegate delegate = (UfoDelegate) cls.getConstructors()[0].newInstance(new Object[] {});
            return delegate;
        } catch (Exception e) {
            FacesUtil.getLogger().log(Level.SEVERE, "ServiceLocator: " + e);
        }
        return null;
    }

}
