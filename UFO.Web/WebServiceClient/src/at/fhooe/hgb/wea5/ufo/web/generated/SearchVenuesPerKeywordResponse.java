
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
 *         &lt;element name="SearchVenuesPerKeywordResult" type="{http://ufo.at/}ArrayOfVenue" minOccurs="0"/>
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
    "searchVenuesPerKeywordResult"
})
@XmlRootElement(name = "SearchVenuesPerKeywordResponse")
public class SearchVenuesPerKeywordResponse {

    @XmlElement(name = "SearchVenuesPerKeywordResult")
    protected ArrayOfVenue searchVenuesPerKeywordResult;

    /**
     * Gets the value of the searchVenuesPerKeywordResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfVenue }
     *     
     */
    public ArrayOfVenue getSearchVenuesPerKeywordResult() {
        return searchVenuesPerKeywordResult;
    }

    /**
     * Sets the value of the searchVenuesPerKeywordResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfVenue }
     *     
     */
    public void setSearchVenuesPerKeywordResult(ArrayOfVenue value) {
        this.searchVenuesPerKeywordResult = value;
    }

}
