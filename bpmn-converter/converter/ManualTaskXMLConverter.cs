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
public class ManualTaskXMLConverter:BaseBpmnXMLConverter {

  public Class<?:BaseElement> getBpmnElementType() {
    return ManualTask.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_TASK_MANUAL;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    ManualTask manualTask = new ManualTask();
    BpmnXMLUtil.addXMLLocation(manualTask, xtr);
    parseChildElements(getXMLElementName(), manualTask, model, xtr);
    return manualTask;
  }

  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
  }
  
  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    
  }
}
