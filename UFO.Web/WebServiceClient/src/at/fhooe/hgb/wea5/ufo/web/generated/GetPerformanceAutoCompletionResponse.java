
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
 *         &lt;element name="GetPerformanceAutoCompletionResult" type="{http://ufo.at/}ArrayOfString" minOccurs="0"/>
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
    "getPerformanceAutoCompletionResult"
})
@XmlRootElement(name = "GetPerformanceAutoCompletionResponse")
public class GetPerformanceAutoCompletionResponse {

    @XmlElement(name = "GetPerformanceAutoCompletionResult")
    protected ArrayOfString getPerformanceAutoCompletionResult;

    /**
     * Gets the value of the getPerformanceAutoCompletionResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfString }
     *     
     */
    public ArrayOfString getGetPerformanceAutoCompletionResult() {
        return getPerformanceAutoCompletionResult;
    }

    /**
     * Sets the value of the getPerformanceAutoCompletionResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfString }
     *     
     */
    public void setGetPerformanceAutoCompletionResult(ArrayOfString value) {
        this.getPerformanceAutoCompletionResult = value;
    }

}
