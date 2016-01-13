
package at.fhooe.hgb.wea5.ufo.web.client;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
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
 *         &lt;element name="GetCountriesResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}ArrayOfCountry" minOccurs="0"/>
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
    "getCountriesResult"
})
@XmlRootElement(name = "GetCountriesResponse")
public class GetCountriesResponse {

    @XmlElementRef(name = "GetCountriesResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfCountry> getCountriesResult;

    /**
     * Gets the value of the getCountriesResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfCountry }{@code >}
     *     
     */
    public JAXBElement<ArrayOfCountry> getGetCountriesResult() {
        return getCountriesResult;
    }

    /**
     * Sets the value of the getCountriesResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfCountry }{@code >}
     *     
     */
    public void setGetCountriesResult(JAXBElement<ArrayOfCountry> value) {
        this.getCountriesResult = value;
    }

}
