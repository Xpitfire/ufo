
package at.fhooe.hgb.wea5.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for PagingData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PagingData">
 *   &lt;complexContent>
 *     &lt;extension base="{http://ufo.at/}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="Offset" type="{http://www.w3.org/2001/XMLSchema}long"/>
 *         &lt;element name="Request" type="{http://www.w3.org/2001/XMLSchema}long"/>
 *         &lt;element name="Size" type="{http://www.w3.org/2001/XMLSchema}long"/>
 *         &lt;element name="Remaining" type="{http://www.w3.org/2001/XMLSchema}long"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PagingData", propOrder = {
    "offset",
    "request",
    "size",
    "remaining"
})
public class PagingData
    extends DomainObject
{

    @XmlElement(name = "Offset")
    protected long offset;
    @XmlElement(name = "Request")
    protected long request;
    @XmlElement(name = "Size")
    protected long size;
    @XmlElement(name = "Remaining")
    protected long remaining;

    /**
     * Gets the value of the offset property.
     * 
     */
    public long getOffset() {
        return offset;
    }

    /**
     * Sets the value of the offset property.
     * 
     */
    public void setOffset(long value) {
        this.offset = value;
    }

    /**
     * Gets the value of the request property.
     * 
     */
    public long getRequest() {
        return request;
    }

    /**
     * Sets the value of the request property.
     * 
     */
    public void setRequest(long value) {
        this.request = value;
    }

    /**
     * Gets the value of the size property.
     * 
     */
    public long getSize() {
        return size;
    }

    /**
     * Sets the value of the size property.
     * 
     */
    public void setSize(long value) {
        this.size = value;
    }

    /**
     * Gets the value of the remaining property.
     * 
     */
    public long getRemaining() {
        return remaining;
    }

    /**
     * Sets the value of the remaining property.
     * 
     */
    public void setRemaining(long value) {
        this.remaining = value;
    }

}
