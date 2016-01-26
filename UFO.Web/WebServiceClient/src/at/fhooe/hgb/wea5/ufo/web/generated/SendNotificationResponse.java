
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
 *         &lt;element name="SendNotificationResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "sendNotificationResult"
})
@XmlRootElement(name = "SendNotificationResponse")
public class SendNotificationResponse {

    @XmlElement(name = "SendNotificationResult")
    protected boolean sendNotificationResult;

    /**
     * Gets the value of the sendNotificationResult property.
     * 
     */
    public boolean isSendNotificationResult() {
        return sendNotificationResult;
    }

    /**
     * Sets the value of the sendNotificationResult property.
     * 
     */
    public void setSendNotificationResult(boolean value) {
        this.sendNotificationResult = value;
    }

}
