
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
 *         &lt;element name="IsUserAuthenticatedResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "isUserAuthenticatedResult"
})
@XmlRootElement(name = "IsUserAuthenticatedResponse")
public class IsUserAuthenticatedResponse {

    @XmlElement(name = "IsUserAuthenticatedResult")
    protected boolean isUserAuthenticatedResult;

    /**
     * Gets the value of the isUserAuthenticatedResult property.
     * 
     */
    public boolean isIsUserAuthenticatedResult() {
        return isUserAuthenticatedResult;
    }

    /**
     * Sets the value of the isUserAuthenticatedResult property.
     * 
     */
    public void setIsUserAuthenticatedResult(boolean value) {
        this.isUserAuthenticatedResult = value;
    }

}
