
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
 *         &lt;element name="GetArtistsResult" type="{http://ufo.at/}ArrayOfArtist" minOccurs="0"/>
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
    "getArtistsResult"
})
@XmlRootElement(name = "GetArtistsResponse")
public class GetArtistsResponse {

    @XmlElement(name = "GetArtistsResult")
    protected ArrayOfArtist getArtistsResult;

    /**
     * Gets the value of the getArtistsResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfArtist }
     *     
     */
    public ArrayOfArtist getGetArtistsResult() {
        return getArtistsResult;
    }

    /**
     * Sets the value of the getArtistsResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfArtist }
     *     
     */
    public void setGetArtistsResult(ArrayOfArtist value) {
        this.getArtistsResult = value;
    }

}
