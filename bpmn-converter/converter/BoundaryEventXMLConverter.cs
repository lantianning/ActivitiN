/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using bpmn_converter.converter;
using bpmn_converter.converter.util;
using org.activiti.bpmn.converter.util;
using org.activiti.bpmn.model;

namespace org.activiti.bpmn.converter{












/**
 * //@author Tijs Rademakers

 */
public class BoundaryEventXMLConverter : BaseBpmnXMLConverter {
  
  public Type getBpmnElementType() {
    return typeof(BoundaryEvent);
  }
  
  //@Override

  protected String getXMLElementName() {
    return ELEMENT_EVENT_BOUNDARY;
  }
  
  //@Override

  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) {
    BoundaryEvent boundaryEvent = new BoundaryEvent();
    BpmnXMLUtil.addXMLLocation(boundaryEvent, xtr);
    if (!String.IsNullOrWhiteSpace(xtr.getAttributeValue(null, ATTRIBUTE_BOUNDARY_CANCELACTIVITY))) {
      String cancelActivity = xtr.getAttributeValue(null, ATTRIBUTE_BOUNDARY_CANCELACTIVITY);
      if (ATTRIBUTE_VALUE_FALSE.equalsIgnoreCase(cancelActivity)) {
        boundaryEvent.setCancelActivity(false);
      }
    }
    boundaryEvent.setAttachedToRefId(xtr.getAttributeValue(null, ATTRIBUTE_BOUNDARY_ATTACHEDTOREF));
    parseChildElements(getXMLElementName(), boundaryEvent, model, xtr);
    
    // Explicitly set cancel activity to false for error boundary events
    if (boundaryEvent.getEventDefinitions().size() == 1) {
      EventDefinition eventDef = boundaryEvent.getEventDefinitions().get(0); 
      
      if (eventDef as ErrorEventDefinition !=null) {
        boundaryEvent.setCancelActivity(false);
      }
    }
    
    return boundaryEvent;
  }

  //@Override

  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) {
    BoundaryEvent boundaryEvent = (BoundaryEvent) element;
    if (boundaryEvent.getAttachedToRef() != null) {
      writeDefaultAttribute(ATTRIBUTE_BOUNDARY_ATTACHEDTOREF, boundaryEvent.getAttachedToRef().getId(), xtw);
    }
    
    if (boundaryEvent.getEventDefinitions().size() == 1) {
      EventDefinition eventDef = boundaryEvent.getEventDefinitions().get(0); 
      
      if (eventDef as ErrorEventDefinition !=null == false) {
        writeDefaultAttribute(ATTRIBUTE_BOUNDARY_CANCELACTIVITY, String.Parse(boundaryEvent.isCancelActivity()).toLowerCase(), xtw);
      }
    }
  }
  
  //@Override

  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) {
    BoundaryEvent boundaryEvent = (BoundaryEvent) element;
    writeEventDefinitions(boundaryEvent, boundaryEvent.getEventDefinitions(), model, xtw);
  }
}
