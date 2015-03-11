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
public class EndEventXMLConverter:BaseBpmnXMLConverter {
  
  public Class<?:BaseElement> getBpmnElementType() {
    return EndEvent.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_EVENT_END;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    EndEvent endEvent = new EndEvent();
    BpmnXMLUtil.addXMLLocation(endEvent, xtr);
    parseChildElements(getXMLElementName(), endEvent, model, xtr);
    return endEvent;
  }

  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception { 
  }

  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    EndEvent endEvent = (EndEvent) element;
    writeEventDefinitions(endEvent, endEvent.getEventDefinitions(), model, xtw);
  }
}
