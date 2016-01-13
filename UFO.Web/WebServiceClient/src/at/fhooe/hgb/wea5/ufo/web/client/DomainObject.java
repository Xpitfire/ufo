
package at.fhooe.hgb.wea5.ufo.web.client;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for DomainObject complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="DomainObject">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "DomainObject", namespace = "http://schemas.datacontract.org/2004/07/UFO.Server.Domain")
@XmlSeeAlso({
    PagingData.class,
    Artist.class,
    Category.class,
    Venue.class,
    Country.class,
    BlobData.class,
    Performance.class,
    Location.class
})
public class DomainObject {


}
