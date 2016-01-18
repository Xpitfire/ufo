package at.ufo.app.domain;

import at.ufo.app.db.DbAccess;
import at.ufo.app.dummy.DummyDomainDelegate;

/**
 * Created by dinum_000 on 18.01.2016.
 */
public final class DomainFactory {

    public enum DomainDelegateType {
        DUMMY,
        DATABASE,
        WEB_SERVICE
    }

    private DomainFactory() {}

    public static DomainDelegate getDelegate(DomainDelegateType type) {
        switch (type) {
            case DUMMY:
                return new DummyDomainDelegate();
            case DATABASE:
                return new DbAccess();
            case WEB_SERVICE:
                throw new UnsupportedOperationException("This type is not yet supported!");
            default:
                throw new UnsupportedOperationException("Unknown type!");
        }
    }

    public static DomainDelegate getDefaultDelegate() {
        return getDelegate(DomainDelegateType.DATABASE);
    }

}
