
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
 *         &lt;element name="GetAutoCompletionResult" type="{http://ufo.at/}ArrayOfString" minOccurs="0"/>
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
    "getAutoCompletionResult"
})
@XmlRootElement(name = "GetAutoCompletionResponse")
public class GetAutoCompletionResponse {

    @XmlElement(name = "GetAutoCompletionResult")
    protected ArrayOfString getAutoCompletionResult;

    /**
     * Gets the value of the getAutoCompletionResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfString }
     *     
     */
    public ArrayOfString getGetAutoCompletionResult() {
        return getAutoCompletionResult;
    }

    /**
     * Sets the value of the getAutoCompletionResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfString }
     *     
     */
    public void setGetAutoCompletionResult(ArrayOfString value) {
        this.getAutoCompletionResult = value;
    }

}
