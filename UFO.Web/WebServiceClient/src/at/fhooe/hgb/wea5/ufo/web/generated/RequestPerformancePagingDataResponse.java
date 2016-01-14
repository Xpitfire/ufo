
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
 *         &lt;element name="RequestPerformancePagingDataResult" type="{http://ufo.at/}PagingData" minOccurs="0"/>
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
    "requestPerformancePagingDataResult"
})
@XmlRootElement(name = "RequestPerformancePagingDataResponse")
public class RequestPerformancePagingDataResponse {

    @XmlElement(name = "RequestPerformancePagingDataResult")
    protected PagingData requestPerformancePagingDataResult;

    /**
     * Gets the value of the requestPerformancePagingDataResult property.
     * 
     * @return
     *     possible object is
     *     {@link PagingData }
     *     
     */
    public PagingData getRequestPerformancePagingDataResult() {
        return requestPerformancePagingDataResult;
    }

    /**
     * Sets the value of the requestPerformancePagingDataResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link PagingData }
     *     
     */
    public void setRequestPerformancePagingDataResult(PagingData value) {
        this.requestPerformancePagingDataResult = value;
    }

}
