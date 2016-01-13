
package at.fhooe.hgb.wea5.ufo.web.client;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Artist complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Artist">
 *   &lt;complexContent>
 *     &lt;extension base="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="ArtistId" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *         &lt;element name="Category" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}Category" minOccurs="0"/>
 *         &lt;element name="Country" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}Country" minOccurs="0"/>
 *         &lt;element name="EMail" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Name" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Picture" type="{http://schemas.datacontract.org/2004/07/UFO.Server.Domain}BlobData" minOccurs="0"/>
 *         &lt;element name="PromoVideo" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Artist", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", propOrder = {
    "artistId",
    "category",
    "country",
    "eMail",
    "name",
    "picture",
    "promoVideo"
})
public class Artist
    extends DomainObject
{

    @XmlElement(name = "ArtistId")
    protected Integer artistId;
    @XmlElementRef(name = "Category", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<Category> category;
    @XmlElementRef(name = "Country", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<Country> country;
    @XmlElementRef(name = "EMail", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<String> eMail;
    @XmlElementRef(name = "Name", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<String> name;
    @XmlElementRef(name = "Picture", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<BlobData> picture;
    @XmlElementRef(name = "PromoVideo", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain", type = JAXBElement.class, required = false)
    protected JAXBElement<String> promoVideo;

    /**
     * Gets the value of the artistId property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getArtistId() {
        return artistId;
    }

    /**
     * Sets the value of the artistId property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setArtistId(Integer value) {
        this.artistId = value;
    }

    /**
     * Gets the value of the category property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Category }{@code >}
     *     
     */
    public JAXBElement<Category> getCategory() {
        return category;
    }

    /**
     * Sets the value of the category property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Category }{@code >}
     *     
     */
    public void setCategory(JAXBElement<Category> value) {
        this.category = value;
    }

    /**
     * Gets the value of the country property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Country }{@code >}
     *     
     */
    public JAXBElement<Country> getCountry() {
        return country;
    }

    /**
     * Sets the value of the country property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Country }{@code >}
     *     
     */
    public void setCountry(JAXBElement<Country> value) {
        this.country = value;
    }

    /**
     * Gets the value of the eMail property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getEMail() {
        return eMail;
    }

    /**
     * Sets the value of the eMail property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setEMail(JAXBElement<String> value) {
        this.eMail = value;
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
     * Gets the value of the picture property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link BlobData }{@code >}
     *     
     */
    public JAXBElement<BlobData> getPicture() {
        return picture;
    }

    /**
     * Sets the value of the picture property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link BlobData }{@code >}
     *     
     */
    public void setPicture(JAXBElement<BlobData> value) {
        this.picture = value;
    }

    /**
     * Gets the value of the promoVideo property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getPromoVideo() {
        return promoVideo;
    }

    /**
     * Sets the value of the promoVideo property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setPromoVideo(JAXBElement<String> value) {
        this.promoVideo = value;
    }

}
