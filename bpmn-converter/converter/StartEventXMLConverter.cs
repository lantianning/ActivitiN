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
namespace org.activiti.bpmn.converter{











/**
 * @author Tijs Rademakers
 */
public class StartEventXMLConverter:BaseBpmnXMLConverter {
  
  public Class<?:BaseElement> getBpmnElementType() {
    return StartEvent.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_EVENT_START;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    String formKey = xtr.getAttributeValue(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_FORM_FORMKEY);
    StartEvent startEvent = null;
    if (StringUtils.isNotEmpty(formKey)) {
      if (model.getStartEventFormTypes() != null && model.getStartEventFormTypes().contains(formKey)) {
        startEvent = new AlfrescoStartEvent();
      }
    }
    if (startEvent == null) {
      startEvent = new StartEvent();
    }
    BpmnXMLUtil.addXMLLocation(startEvent, xtr);
    startEvent.setInitiator(xtr.getAttributeValue(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_EVENT_START_INITIATOR));
    startEvent.setFormKey(formKey);
    
    parseChildElements(getXMLElementName(), startEvent, model, xtr);
    
    return startEvent;
  }
  
  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    StartEvent startEvent = (StartEvent) element;
    writeQualifiedAttribute(ATTRIBUTE_EVENT_START_INITIATOR, startEvent.getInitiator(), xtw);
    writeQualifiedAttribute(ATTRIBUTE_FORM_FORMKEY, startEvent.getFormKey(), xtw);
  }
  
  
  protected boolean writeExtensionChildElements(BaseElement element, boolean didWriteExtensionStartElement, XMLStreamWriter xtw) throws Exception {
    StartEvent startEvent = (StartEvent) element;
    didWriteExtensionStartElement = writeFormProperties(startEvent, didWriteExtensionStartElement, xtw);
    return didWriteExtensionStartElement;
  }
  
  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    StartEvent startEvent = (StartEvent) element;
    writeEventDefinitions(startEvent, startEvent.getEventDefinitions(), model, xtw);
  }
}
