
package at.fhooe.hgb.wea5.ufo.web.client;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Venue complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Venue">
 *   &lt;complexContent>
 *     &lt;extension base="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="Location" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}Location" minOccurs="0"/>
 *         &lt;element name="Name" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="VenueId" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Venue", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", propOrder = {
    "location",
    "name",
    "venueId"
})
public class Venue
    extends DomainObject
{

    @XmlElementRef(name = "Location", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<Location> location;
    @XmlElementRef(name = "Name", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<String> name;
    @XmlElementRef(name = "VenueId", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<String> venueId;

    /**
     * Gets the value of the location property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Location }{@code >}
     *     
     */
    public JAXBElement<Location> getLocation() {
        return location;
    }

    /**
     * Sets the value of the location property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Location }{@code >}
     *     
     */
    public void setLocation(JAXBElement<Location> value) {
        this.location = value;
    }

    /**
     * Gets the value of the name property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getName() {
        return name;
    }

    /**
     * Sets the value of the name property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setName(JAXBElement<String> value) {
        this.name = value;
    }

    /**
     * Gets the value of the venueId property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getVenueId() {
        return venueId;
    }

    /**
     * Sets the value of the venueId property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setVenueId(JAXBElement<String> value) {
        this.venueId = value;
    }

}
