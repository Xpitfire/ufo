
package at.fhooe.hgb.wea5.ufo.web.generated;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for SessionToken complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SessionToken">
 *   &lt;complexContent>
 *     &lt;extension base="{http://ufo.at/}DomainObject">
 *       &lt;sequence>
 *         &lt;element name="SessionId" type="{http://ufo.at/}ArrayOfChar" minOccurs="0"/>
 *         &lt;element name="User" type="{http://ufo.at/}User" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SessionToken", propOrder = {
    "sessionId",
    "user"
})
public class SessionToken
    extends DomainObject
{

    @XmlElement(name = "SessionId")
    protected ArrayOfChar sessionId;
    @XmlElement(name = "User")
    protected User user;

    /**
     * Gets the value of the sessionId property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfChar }
     *     
     */
    public ArrayOfChar getSessionId() {
        return sessionId;
    }

    /**
     * Sets the value of the sessionId property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfChar }
     *     
     */
    public void setSessionId(ArrayOfChar value) {
        this.sessionId = value;
    }

    /**
     * Gets the value of the user property.
     * 
     * @return
     *     possible object is
     *     {@link User }
     *     
     */
    public User getUser() {
        return user;
    }

    /**
     * Sets the value of the user property.
     * 
     * @param value
     *     allowed object is
     *     {@link User }
     *     
     */
    public void setUser(User value) {
        this.user = value;
    }

}
