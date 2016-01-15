
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
 *         &lt;element name="ModifyPerformanceResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "modifyPerformanceResult"
})
@XmlRootElement(name = "ModifyPerformanceResponse")
public class ModifyPerformanceResponse {

    @XmlElement(name = "ModifyPerformanceResult")
    protected boolean modifyPerformanceResult;

    /**
     * Gets the value of the modifyPerformanceResult property.
     * 
     */
    public boolean isModifyPerformanceResult() {
        return modifyPerformanceResult;
    }

    /**
     * Sets the value of the modifyPerformanceResult property.
     * 
     */
    public void setModifyPerformanceResult(boolean value) {
        this.modifyPerformanceResult = value;
    }

}
