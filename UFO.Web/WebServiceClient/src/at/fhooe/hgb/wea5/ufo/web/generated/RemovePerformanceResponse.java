
package at.fhooe.hgb.wea5.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="RemovePerformanceResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "removePerformanceResult"
})
@XmlRootElement(name = "RemovePerformanceResponse")
public class RemovePerformanceResponse {

    @XmlElement(name = "RemovePerformanceResult")
    protected boolean removePerformanceResult;

    /**
     * Gets the value of the removePerformanceResult property.
     * 
     */
    public boolean isRemovePerformanceResult() {
        return removePerformanceResult;
    }

    /**
     * Sets the value of the removePerformanceResult property.
     * 
     */
    public void setRemovePerformanceResult(boolean value) {
        this.removePerformanceResult = value;
    }

}
