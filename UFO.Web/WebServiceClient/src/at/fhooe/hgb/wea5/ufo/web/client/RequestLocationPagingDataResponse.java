
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
 *         &lt;element name="RequestLocationPagingDataResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}PagingData" minOccurs="0"/>
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
    "requestLocationPagingDataResult"
})
@XmlRootElement(name = "RequestLocationPagingDataResponse")
public class RequestLocationPagingDataResponse {

    @XmlElementRef(name = "RequestLocationPagingDataResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<PagingData> requestLocationPagingDataResult;

    /**
     * Gets the value of the requestLocationPagingDataResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link PagingData }{@code >}
     *     
     */
    public JAXBElement<PagingData> getRequestLocationPagingDataResult() {
        return requestLocationPagingDataResult;
    }

    /**
     * Sets the value of the requestLocationPagingDataResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link PagingData }{@code >}
     *     
     */
    public void setRequestLocationPagingDataResult(JAXBElement<PagingData> value) {
        this.requestLocationPagingDataResult = value;
    }

}
