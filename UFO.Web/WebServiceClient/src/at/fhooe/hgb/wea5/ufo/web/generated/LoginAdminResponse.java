
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
 *         &lt;element name="LoginAdminResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "loginAdminResult"
})
@XmlRootElement(name = "LoginAdminResponse")
public class LoginAdminResponse {

    @XmlElement(name = "LoginAdminResult")
    protected boolean loginAdminResult;

    /**
     * Gets the value of the loginAdminResult property.
     * 
     */
    public boolean isLoginAdminResult() {
        return loginAdminResult;
    }

    /**
     * Sets the value of the loginAdminResult property.
     * 
     */
    public void setLoginAdminResult(boolean value) {
        this.loginAdminResult = value;
    }

}
