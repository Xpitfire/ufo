package at.ufo.app.util;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * Created by Flow on 27.01.16.
 */
public class Async {
    private static ExecutorService executorService;

    public static ExecutorService getThreadPool() {
        if(executorService == null) {
            int cores = Runtime.getRuntime().availableProcessors();
            executorService = Executors.newFixedThreadPool(cores);
        }
        return executorService;

    }
}
