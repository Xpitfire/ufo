
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
 *         &lt;element name="GetPerformancesPerArtistResult" type="{http://ufo.at/}ArrayOfPerformance" minOccurs="0"/>
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
    "getPerformancesPerArtistResult"
})
@XmlRootElement(name = "GetPerformancesPerArtistResponse")
public class GetPerformancesPerArtistResponse {

    @XmlElement(name = "GetPerformancesPerArtistResult")
    protected ArrayOfPerformance getPerformancesPerArtistResult;

    /**
     * Gets the value of the getPerformancesPerArtistResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public ArrayOfPerformance getGetPerformancesPerArtistResult() {
        return getPerformancesPerArtistResult;
    }

    /**
     * Sets the value of the getPerformancesPerArtistResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfPerformance }
     *     
     */
    public void setGetPerformancesPerArtistResult(ArrayOfPerformance value) {
        this.getPerformancesPerArtistResult = value;
    }

}
