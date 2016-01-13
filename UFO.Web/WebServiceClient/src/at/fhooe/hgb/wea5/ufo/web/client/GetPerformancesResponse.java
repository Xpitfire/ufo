
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
 *         &lt;element name="GetPerformancesResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}ArrayOfPerformance" minOccurs="0"/>
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
    "getPerformancesResult"
})
@XmlRootElement(name = "GetPerformancesResponse")
public class GetPerformancesResponse {

    @XmlElementRef(name = "GetPerformancesResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfPerformance> getPerformancesResult;

    /**
     * Gets the value of the getPerformancesResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}
     *     
     */
    public JAXBElement<ArrayOfPerformance> getGetPerformancesResult() {
        return getPerformancesResult;
    }

    /**
     * Sets the value of the getPerformancesResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}
     *     
     */
    public void setGetPerformancesResult(JAXBElement<ArrayOfPerformance> value) {
        this.getPerformancesResult = value;
    }

}
