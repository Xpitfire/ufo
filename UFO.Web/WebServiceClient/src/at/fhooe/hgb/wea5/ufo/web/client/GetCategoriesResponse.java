
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
 *         &lt;element name="GetCategoriesResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}ArrayOfCategory" minOccurs="0"/>
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
    "getCategoriesResult"
})
@XmlRootElement(name = "GetCategoriesResponse")
public class GetCategoriesResponse {

    @XmlElementRef(name = "GetCategoriesResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfCategory> getCategoriesResult;

    /**
     * Gets the value of the getCategoriesResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfCategory }{@code >}
     *     
     */
    public JAXBElement<ArrayOfCategory> getGetCategoriesResult() {
        return getCategoriesResult;
    }

    /**
     * Sets the value of the getCategoriesResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfCategory }{@code >}
     *     
     */
    public void setGetCategoriesResult(JAXBElement<ArrayOfCategory> value) {
        this.getCategoriesResult = value;
    }

}
