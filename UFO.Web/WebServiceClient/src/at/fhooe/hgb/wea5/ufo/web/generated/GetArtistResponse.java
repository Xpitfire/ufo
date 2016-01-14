
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
 *         &lt;element name="GetArtistResult" type="{http://ufo.at/}ArrayOfArtist" minOccurs="0"/>
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

    @XmlElement(name = "GetArtistResult")
    protected ArrayOfArtist getArtistResult;

    /**
     * Gets the value of the getArtistResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfArtist }
     *     
     */
    public ArrayOfArtist getGetArtistResult() {
        return getArtistResult;
    }

    /**
     * Sets the value of the getArtistResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfArtist }
     *     
     */
    public void setGetArtistResult(ArrayOfArtist value) {
        this.getArtistResult = value;
    }

}
