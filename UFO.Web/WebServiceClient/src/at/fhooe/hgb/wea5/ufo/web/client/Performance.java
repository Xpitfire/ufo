
package at.fhooe.hgb.wea5.ufo.web.client;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for Performance complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Performance">
 *   &lt;complexContent>
 *     &lt;extension base="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="Artist" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}Artist" minOccurs="0"/>
 *         &lt;element name="DateTime" type="{http://www.w3.org/2001/XMLSchema}dateTime" minOccurs="0"/>
 *         &lt;element name="Venue" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}Venue" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Performance", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", propOrder = {
    "artist",
    "dateTime",
    "venue"
})
public class Performance
    extends DomainObject
{

    @XmlElementRef(name = "Artist", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<Artist> artist;
    @XmlElement(name = "DateTime")
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar dateTime;
    @XmlElementRef(name = "Venue", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<Venue> venue;

    /**
     * Gets the value of the artist property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Artist }{@code >}
     *     
     */
    public JAXBElement<Artist> getArtist() {
        return artist;
    }

    /**
     * Sets the value of the artist property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Artist }{@code >}
     *     
     */
    public void setArtist(JAXBElement<Artist> value) {
        this.artist = value;
    }

    /**
     * Gets the value of the dateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getDateTime() {
        return dateTime;
    }

    /**
     * Sets the value of the dateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setDateTime(XMLGregorianCalendar value) {
        this.dateTime = value;
    }

    /**
     * Gets the value of the venue property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Venue }{@code >}
     *     
     */
    public JAXBElement<Venue> getVenue() {
        return venue;
    }

    /**
     * Sets the value of the venue property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Venue }{@code >}
     *     
     */
    public void setVenue(JAXBElement<Venue> value) {
        this.venue = value;
    }

}
