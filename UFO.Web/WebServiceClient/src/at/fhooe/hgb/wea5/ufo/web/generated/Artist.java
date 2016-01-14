
package at.fhooe.hgb.wea5.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Artist complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Artist">
 *   &lt;complexContent>
 *     &lt;extension base="{http://ufo.at/}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="ArtistId" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *         &lt;element name="Name" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="EMail" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Category" type="{http://ufo.at/}Category" minOccurs="0"/>
 *         &lt;element name="Country" type="{http://ufo.at/}Country" minOccurs="0"/>
 *         &lt;element name="Picture" type="{http://ufo.at/}BlobData" minOccurs="0"/>
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
@XmlType(name = "Artist", propOrder = {
    "artistId",
    "name",
    "eMail",
    "category",
    "country",
    "picture",
    "promoVideo"
})
public class Artist
    extends DomainObject
{

    @XmlElement(name = "ArtistId")
    protected int artistId;
    @XmlElement(name = "Name")
    protected String name;
    @XmlElement(name = "EMail")
    protected String eMail;
    @XmlElement(name = "Category")
    protected Category category;
    @XmlElement(name = "Country")
    protected Country country;
    @XmlElement(name = "Picture")
    protected BlobData picture;
    @XmlElement(name = "PromoVideo")
    protected String promoVideo;

    /**
     * Gets the value of the artistId property.
     * 
     */
    public int getArtistId() {
        return artistId;
    }

    /**
     * Sets the value of the artistId property.
     * 
     */
    public void setArtistId(int value) {
        this.artistId = value;
    }

    /**
     * Gets the value of the name property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getName() {
        return name;
    }

    /**
     * Sets the value of the name property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setName(String value) {
        this.name = value;
    }

    /**
     * Gets the value of the eMail property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEMail() {
        return eMail;
    }

    /**
     * Sets the value of the eMail property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEMail(String value) {
        this.eMail = value;
    }

    /**
     * Gets the value of the category property.
     * 
     * @return
     *     possible object is
     *     {@link Category }
     *     
     */
    public Category getCategory() {
        return category;
    }

    /**
     * Sets the value of the category property.
     * 
     * @param value
     *     allowed object is
     *     {@link Category }
     *     
     */
    public void setCategory(Category value) {
        this.category = value;
    }

    /**
     * Gets the value of the country property.
     * 
     * @return
     *     possible object is
     *     {@link Country }
     *     
     */
    public Country getCountry() {
        return country;
    }

    /**
     * Sets the value of the country property.
     * 
     * @param value
     *     allowed object is
     *     {@link Country }
     *     
     */
    public void setCountry(Country value) {
        this.country = value;
    }

    /**
     * Gets the value of the picture property.
     * 
     * @return
     *     possible object is
     *     {@link BlobData }
     *     
     */
    public BlobData getPicture() {
        return picture;
    }

    /**
     * Sets the value of the picture property.
     * 
     * @param value
     *     allowed object is
     *     {@link BlobData }
     *     
     */
    public void setPicture(BlobData value) {
        this.picture = value;
    }

    /**
     * Gets the value of the promoVideo property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPromoVideo() {
        return promoVideo;
    }

    /**
     * Sets the value of the promoVideo property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPromoVideo(String value) {
        this.promoVideo = value;
    }

}