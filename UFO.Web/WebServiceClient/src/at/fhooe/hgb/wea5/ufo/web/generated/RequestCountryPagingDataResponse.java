
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
 *         &lt;element name="RequestCountryPagingDataResult" type="{http://ufo.at/}PagingData" minOccurs="0"/>
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
    "requestCountryPagingDataResult"
})
@XmlRootElement(name = "RequestCountryPagingDataResponse")
public class RequestCountryPagingDataResponse {

    @XmlElement(name = "RequestCountryPagingDataResult")
    protected PagingData requestCountryPagingDataResult;

    /**
     * Gets the value of the requestCountryPagingDataResult property.
     * 
     * @return
     *     possible object is
     *     {@link PagingData }
     *     
     */
    public PagingData getRequestCountryPagingDataResult() {
        return requestCountryPagingDataResult;
    }

    /**
     * Sets the value of the requestCountryPagingDataResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link PagingData }
     *     
     */
    public void setRequestCountryPagingDataResult(PagingData value) {
        this.requestCountryPagingDataResult = value;
    }

}
