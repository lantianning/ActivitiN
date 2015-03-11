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
public class CatchEventXMLConverter:BaseBpmnXMLConverter {
  
  public Class<?:BaseElement> getBpmnElementType() {
    return IntermediateCatchEvent.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_EVENT_CATCH;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    IntermediateCatchEvent catchEvent = new IntermediateCatchEvent();
    BpmnXMLUtil.addXMLLocation(catchEvent, xtr);
    parseChildElements(getXMLElementName(), catchEvent, model, xtr);
    return catchEvent;
  }

  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    
  }
  
  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    IntermediateCatchEvent catchEvent = (IntermediateCatchEvent) element;
    writeEventDefinitions(catchEvent, catchEvent.getEventDefinitions(), model, xtw);
  }
}
