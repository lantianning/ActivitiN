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
public class EventGatewayXMLConverter:BaseBpmnXMLConverter {
  
  public Class<?:BaseElement> getBpmnElementType() {
    return EventGateway.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_GATEWAY_EVENT;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    EventGateway gateway = new EventGateway();
    BpmnXMLUtil.addXMLLocation(gateway, xtr);
    parseChildElements(getXMLElementName(), gateway, model, xtr);
    return gateway;
  }

  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
  }
  
  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    
  }
}
