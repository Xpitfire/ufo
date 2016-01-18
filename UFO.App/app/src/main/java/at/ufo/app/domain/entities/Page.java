package at.ufo.app.domain.entities;

import at.ufo.app.util.Constants;

/**
 * Created by Marius-Constantin on 1/18/2016.
 */
public class Page {

    private int offset;
    private int requestSize;

    public Page() {
        this(0);
    }
    public Page(int offset) {
        this(offset, Constants.REQUEST_SIZE);
    }
    public Page(int offset, int requestSize) {
        this.offset = offset;
        this.requestSize = requestSize;
    }

    public int getOffset() {
        return offset;
    }

    public void setOffset(int offset) {
        this.offset = offset;
    }

    public int getRequestSize() {
        return requestSize;
    }

    public void setRequestSize(int requestSize) {
        this.requestSize = requestSize;
    }

    public void next() {
        offset += requestSize;
    }

    public void reset() {
        offset = 0;
    }
}
