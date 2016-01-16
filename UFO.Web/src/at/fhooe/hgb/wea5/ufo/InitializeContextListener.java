package at.fhooe.hgb.wea5.ufo;

import at.fhooe.hgb.wea5.ufo.backend.ServiceLocator;

import javax.servlet.ServletContext;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

/**
 * @author: Dinu Marius-Constantin
 * @date: 13.01.2016.
 */
public class InitializeContextListener implements ServletContextListener {
    @Override
    public void contextInitialized(ServletContextEvent servletContextEvent) {
        ServletContext sc = servletContextEvent.getServletContext();
        String wsHost = sc.getInitParameter("WS_HOST");
        String wsPort = sc.getInitParameter("WS_PORT");
        String wsUri = sc.getInitParameter("WS_URI");
        String delegateClass = sc.getInitParameter("UFO_DELEGATE");

        ServiceLocator.getInstance().init(wsHost, wsPort, wsUri, delegateClass);
    }

    @Override
    public void contextDestroyed(ServletContextEvent servletContextEvent) {
        // nothing to do
    }
}
