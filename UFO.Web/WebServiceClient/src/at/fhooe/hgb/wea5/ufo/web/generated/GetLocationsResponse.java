
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
 *         &lt;element name="GetLocationsResult" type="{http://ufo.at/}ArrayOfLocation" minOccurs="0"/>
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
    "getLocationsResult"
})
@XmlRootElement(name = "GetLocationsResponse")
public class GetLocationsResponse {

    @XmlElement(name = "GetLocationsResult")
    protected ArrayOfLocation getLocationsResult;

    /**
     * Gets the value of the getLocationsResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfLocation }
     *     
     */
    public ArrayOfLocation getGetLocationsResult() {
        return getLocationsResult;
    }

    /**
     * Sets the value of the getLocationsResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfLocation }
     *     
     */
    public void setGetLocationsResult(ArrayOfLocation value) {
        this.getLocationsResult = value;
    }

}
