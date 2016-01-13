
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
 *         &lt;element name="GetPerformancesPerDateResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}ArrayOfPerformance" minOccurs="0"/>
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
    "getPerformancesPerDateResult"
})
@XmlRootElement(name = "GetPerformancesPerDateResponse")
public class GetPerformancesPerDateResponse {

    @XmlElementRef(name = "GetPerformancesPerDateResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfPerformance> getPerformancesPerDateResult;

    /**
     * Gets the value of the getPerformancesPerDateResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}
     *     
     */
    public JAXBElement<ArrayOfPerformance> getGetPerformancesPerDateResult() {
        return getPerformancesPerDateResult;
    }

    /**
     * Sets the value of the getPerformancesPerDateResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfPerformance }{@code >}
     *     
     */
    public void setGetPerformancesPerDateResult(JAXBElement<ArrayOfPerformance> value) {
        this.getPerformancesPerDateResult = value;
    }

}
