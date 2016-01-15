
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
 *         &lt;element name="RequestSessionTokenResult" type="{http://ufo.at/}SessionToken" minOccurs="0"/>
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
    "requestSessionTokenResult"
})
@XmlRootElement(name = "RequestSessionTokenResponse")
public class RequestSessionTokenResponse {

    @XmlElement(name = "RequestSessionTokenResult")
    protected SessionToken requestSessionTokenResult;

    /**
     * Gets the value of the requestSessionTokenResult property.
     * 
     * @return
     *     possible object is
     *     {@link SessionToken }
     *     
     */
    public SessionToken getRequestSessionTokenResult() {
        return requestSessionTokenResult;
    }

    /**
     * Sets the value of the requestSessionTokenResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link SessionToken }
     *     
     */
    public void setRequestSessionTokenResult(SessionToken value) {
        this.requestSessionTokenResult = value;
    }

}
