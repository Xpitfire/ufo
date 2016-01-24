
package at.fhooe.hgb.wea5.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
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
 *         &lt;element name="token" type="{http://ufo.at/}SessionToken" minOccurs="0"/>
 *         &lt;element name="oldPerformance" type="{http://ufo.at/}Performance" minOccurs="0"/>
 *         &lt;element name="newPerformance" type="{http://ufo.at/}Performance" minOccurs="0"/>
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
    "token",
    "oldPerformance",
    "newPerformance"
})
@XmlRootElement(name = "DelayPerformance")
public class DelayPerformance {

    protected SessionToken token;
    protected Performance oldPerformance;
    protected Performance newPerformance;

    /**
     * Gets the value of the token property.
     * 
     * @return
     *     possible object is
     *     {@link SessionToken }
     *     
     */
    public SessionToken getToken() {
        return token;
    }

    /**
     * Sets the value of the token property.
     * 
     * @param value
     *     allowed object is
     *     {@link SessionToken }
     *     
     */
    public void setToken(SessionToken value) {
        this.token = value;
    }

    /**
     * Gets the value of the oldPerformance property.
     * 
     * @return
     *     possible object is
     *     {@link Performance }
     *     
     */
    public Performance getOldPerformance() {
        return oldPerformance;
    }

    /**
     * Sets the value of the oldPerformance property.
     * 
     * @param value
     *     allowed object is
     *     {@link Performance }
     *     
     */
    public void setOldPerformance(Performance value) {
        this.oldPerformance = value;
    }

    /**
     * Gets the value of the newPerformance property.
     * 
     * @return
     *     possible object is
     *     {@link Performance }
     *     
     */
    public Performance getNewPerformance() {
        return newPerformance;
    }

    /**
     * Sets the value of the newPerformance property.
     * 
     * @param value
     *     allowed object is
     *     {@link Performance }
     *     
     */
    public void setNewPerformance(Performance value) {
        this.newPerformance = value;
    }

}
