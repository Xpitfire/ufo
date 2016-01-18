package at.ufo.app.domain.entities;

import at.ufo.app.util.Constants;

/**
 * Created by Marius-Constantin on 1/18/2016.
 */
public class Page {

    private int offset;
    private int request = Constants.REQUEST_SIZE;

    public int getOffset() {
        return offset;
    }

    public void setOffset(int offset) {
        this.offset = offset;
    }

    public int getRequest() {
        return request;
    }

    public void setRequest(int request) {
        this.request = request;
    }

    public void next() {
        offset += request;
    }

    public void reset() {
        offset = 0;
    }
}
