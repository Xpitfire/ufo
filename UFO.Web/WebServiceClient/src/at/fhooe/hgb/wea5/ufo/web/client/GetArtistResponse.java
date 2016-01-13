
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
 *         &lt;element name="GetArtistResult" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}ArrayOfArtist" minOccurs="0"/>
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
    "getArtistResult"
})
@XmlRootElement(name = "GetArtistResponse")
public class GetArtistResponse {

    @XmlElementRef(name = "GetArtistResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArtist> getArtistResult;

    /**
     * Gets the value of the getArtistResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArtist }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArtist> getGetArtistResult() {
        return getArtistResult;
    }

    /**
     * Sets the value of the getArtistResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArtist }{@code >}
     *     
     */
    public void setGetArtistResult(JAXBElement<ArrayOfArtist> value) {
        this.getArtistResult = value;
    }

}
