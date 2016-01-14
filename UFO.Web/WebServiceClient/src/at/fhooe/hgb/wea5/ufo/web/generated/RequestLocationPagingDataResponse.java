
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
 *         &lt;element name="RequestLocationPagingDataResult" type="{http://ufo.at/}PagingData" minOccurs="0"/>
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

    @XmlElement(name = "RequestLocationPagingDataResult")
    protected PagingData requestLocationPagingDataResult;

    /**
     * Gets the value of the requestLocationPagingDataResult property.
     * 
     * @return
     *     possible object is
     *     {@link PagingData }
     *     
     */
    public PagingData getRequestLocationPagingDataResult() {
        return requestLocationPagingDataResult;
    }

    /**
     * Sets the value of the requestLocationPagingDataResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link PagingData }
     *     
     */
    public void setRequestLocationPagingDataResult(PagingData value) {
        this.requestLocationPagingDataResult = value;
    }

}
