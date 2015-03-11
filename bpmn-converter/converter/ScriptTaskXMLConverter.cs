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
public class ScriptTaskXMLConverter:BaseBpmnXMLConverter {
  
  protected Map<String, BaseChildElementParser> childParserMap = new HashMap<String, BaseChildElementParser>();
  
	public ScriptTaskXMLConverter() {
		ScriptTextParser scriptTextParser = new ScriptTextParser();
		childParserMap.put(scriptTextParser.getElementName(), scriptTextParser);
	}
	
  public Class<?:BaseElement> getBpmnElementType() {
    return ScriptTask.class;
  }
  
  
  protected String getXMLElementName() {
    return ELEMENT_TASK_SCRIPT;
  }
  
  
  protected BaseElement convertXMLToElement(XMLStreamReader xtr, BpmnModel model) throws Exception {
    ScriptTask scriptTask = new ScriptTask();
    BpmnXMLUtil.addXMLLocation(scriptTask, xtr);
    scriptTask.setScriptFormat(xtr.getAttributeValue(null, ATTRIBUTE_TASK_SCRIPT_FORMAT));
    scriptTask.setResultVariable(xtr.getAttributeValue(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_TASK_SCRIPT_RESULTVARIABLE));
    if (StringUtils.isEmpty(scriptTask.getResultVariable())) {
      scriptTask.setResultVariable(xtr.getAttributeValue(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_TASK_SERVICE_RESULTVARIABLE));
    }
    String autoStoreVariables = xtr.getAttributeValue(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_TASK_SCRIPT_AUTO_STORE_VARIABLE);
    if (StringUtils.isNotEmpty(autoStoreVariables)) {
      scriptTask.setAutoStoreVariables(Boolean.valueOf(autoStoreVariables));
    }
    parseChildElements(getXMLElementName(), scriptTask, childParserMap, model, xtr);
    return scriptTask;
  }

  
  protected void writeAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    ScriptTask scriptTask = (ScriptTask) element;
    writeDefaultAttribute(ATTRIBUTE_TASK_SCRIPT_FORMAT, scriptTask.getScriptFormat(), xtw);
    writeQualifiedAttribute(ATTRIBUTE_TASK_SCRIPT_RESULTVARIABLE, scriptTask.getResultVariable(), xtw);
    writeQualifiedAttribute(ATTRIBUTE_TASK_SCRIPT_AUTO_STORE_VARIABLE, String.valueOf(scriptTask.isAutoStoreVariables()), xtw);
  }
  
  
  protected void writeAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw) throws Exception {
    ScriptTask scriptTask = (ScriptTask) element;
    if (StringUtils.isNotEmpty(scriptTask.getScript())) {
      xtw.writeStartElement(ATTRIBUTE_TASK_SCRIPT_TEXT);
      xtw.writeCharacters(scriptTask.getScript());
      xtw.writeEndElement();
    }
  }
}
