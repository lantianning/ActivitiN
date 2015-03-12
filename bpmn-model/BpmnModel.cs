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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace org.activiti.bpmn.model
{
    public class BpmnModel
    {

        protected Dictionary<String, List<ExtensionAttribute>> definitionsAttributes =
            new Dictionary<String, List<ExtensionAttribute>>();

        protected List<Process> processes = new List<Process>();
        protected Dictionary<String, GraphicInfo> locationMap = new Dictionary<String, GraphicInfo>();
        protected Dictionary<String, GraphicInfo> labelLocationMap = new Dictionary<String, GraphicInfo>();
        protected Dictionary<String, List<GraphicInfo>> flowLocationMap = new Dictionary<String, List<GraphicInfo>>();
        protected List<Signal> signals = new List<Signal>();
        protected Dictionary<String, MessageFlow> messageFlowMap = new Dictionary<String, MessageFlow>();
        protected Dictionary<String, Message> messageMap = new Dictionary<String, Message>();
        protected Dictionary<String, String> errorMap = new Dictionary<String, String>();
        protected Dictionary<String, ItemDefinition> itemDefinitionMap = new Dictionary<String, ItemDefinition>();
        protected Dictionary<String, DataStore> dataStoreMap = new Dictionary<String, DataStore>();
        protected List<Pool> pools = new List<Pool>();
        protected List<Import> imports = new List<Import>();
        protected List<Interface> interfaces = new List<Interface>();
        protected List<Artifact> globalArtifacts = new List<Artifact>();
        protected Dictionary<String, String> NamespaceMap = new Dictionary<String, String>();
        protected String targetNamespace;
        protected List<String> userTaskFormTypes;
        protected List<String> startEventFormTypes;
        protected int nextFlowIdCounter = 1;

        public Dictionary<string, List<ExtensionAttribute>> DefinitionsAttributes
        {
            get { return definitionsAttributes; }
            set { definitionsAttributes = value; }
        }

        public List<Process> Processes
        {
            get { return processes; }
            set { processes = value; }
        }

        public Dictionary<string, GraphicInfo> LocationMap
        {
            get { return locationMap; }
            set { locationMap = value; }
        }

        public Dictionary<string, GraphicInfo> LabelLocationMap
        {
            get { return labelLocationMap; }
            set { labelLocationMap = value; }
        }

        public Dictionary<string, List<GraphicInfo>> FlowLocationMap
        {
            get { return flowLocationMap; }
            set { flowLocationMap = value; }
        }

        public List<Signal> Signals
        {
            get { return signals; }
            set { signals = value; }
        }

        public Dictionary<string, MessageFlow> MessageFlowMap
        {
            get { return messageFlowMap; }
            set { messageFlowMap = value; }
        }

        public Dictionary<string, Message> MessageMap
        {
            get { return messageMap; }
            set { messageMap = value; }
        }

        public Dictionary<string, string> ErrorMap
        {
            get { return errorMap; }
            set { errorMap = value; }
        }

        public Dictionary<string, ItemDefinition> ItemDefinitionMap
        {
            get { return itemDefinitionMap; }
            set { itemDefinitionMap = value; }
        }

        public Dictionary<string, DataStore> DataStoreMap
        {
            get { return dataStoreMap; }
            set { dataStoreMap = value; }
        }

        public List<Pool> Pools
        {
            get { return pools; }
            set { pools = value; }
        }

        public List<Import> Imports
        {
            get { return imports; }
            set { imports = value; }
        }

        public List<Interface> Interfaces
        {
            get { return interfaces; }
            set { interfaces = value; }
        }

        public List<Artifact> GlobalArtifacts
        {
            get { return globalArtifacts; }
            set { globalArtifacts = value; }
        }

        public Dictionary<string, string> NamespaceMap1
        {
            get { return NamespaceMap; }
            set { NamespaceMap = value; }
        }

        public string TargetNamespace
        {
            get { return targetNamespace; }
            set { targetNamespace = value; }
        }

        public List<string> UserTaskFormTypes
        {
            get { return userTaskFormTypes; }
            set { userTaskFormTypes = value; }
        }

        public List<string> StartEventFormTypes
        {
            get { return startEventFormTypes; }
            set { startEventFormTypes = value; }
        }

        public int NextFlowIdCounter
        {
            get { return nextFlowIdCounter; }
            set { nextFlowIdCounter = value; }
        }

        public String getDefinitionsAttributeValue(String Namespace, String name)
        {
            List<ExtensionAttribute> attributes = DefinitionsAttributes[name];
            if (attributes != null && attributes.Any())
            {
                foreach (ExtensionAttribute attribute  in  attributes)
                {
                    if (Namespace.Equals(attribute.Namespace))
                        return attribute.Value;
                }
            }
            return null;
        }

        public void addDefinitionsAttribute(ExtensionAttribute attribute)
        {
            if (attribute != null && !String.IsNullOrWhiteSpace(attribute.Name))
            {
                List<ExtensionAttribute> attributeList = null;
                if (this.definitionsAttributes.ContainsKey(attribute.Name) == false)
                {
                    attributeList = new List<ExtensionAttribute>();
                    this.definitionsAttributes.Add(attribute.Name, attributeList);
                }
                this.definitionsAttributes[attribute.Name].Add(attribute);
            }
        }

        public Process getMainProcess()
        {
            if (Pools.Any())
            {
                return getProcess(Pools[0].Id);
            }
            else
            {
                return getProcess(null);
            }
        }

        public Process getProcess(String poolRef)
        {
            foreach (Process process  in  processes)
            {
                bool foundPool = false;
                foreach (Pool pool  in  pools)
                {
                    if (!String.IsNullOrWhiteSpace(pool.ProcessRef) && 
                        String.Equals(pool.ProcessRef, process.Id, StringComparison.CurrentCultureIgnoreCase))
                    {

                        if (poolRef != null)
                        {
                            if (String.Equals(pool.Id.ToLower(),poolRef.ToLower()))
                            {
                                foundPool = true;
                            }
                        }
                        else
                        {
                            foundPool = true;
                        }
                    }
                }

                if (poolRef == null && foundPool == false)
                {
                    return process;
                }
                else if (poolRef != null && foundPool == true)
                {
                    return process;
                }
            }

            return null;
        }

        public void addProcess(Process process)
        {
            processes.Add(process);
        }

        public Pool getPool(String id)
        {
            Pool foundPool = null;
            if (!String.IsNullOrWhiteSpace(id))
            {
                foreach (Pool pool  in  pools)
                {
                    if (id.Equals(pool.Id))
                    {
                        foundPool = pool;
                        break;
                    }
                }
            }
            return foundPool;
        }

        public Lane getLane(String id)
        {
            Lane foundLane = null;
            if (!String.IsNullOrWhiteSpace(id))
            {
                foreach (Process process  in  processes)
                {
                    foreach (Lane lane  in  process.Lanes)
                    {
                        if (id.Equals(lane.Id))
                        {
                            foundLane = lane;
                            break;
                        }
                    }
                    if (foundLane != null)
                    {
                        break;
                    }
                }
            }
            return foundLane;
        }

        public FlowElement getFlowElement(String id)
        {
            FlowElement foundFlowElement = null;
            foreach (Process process  in  processes)
            {
                foundFlowElement = process.getFlowElement(id);
                if (foundFlowElement != null)
                {
                    break;
                }
            }

            if (foundFlowElement == null)
            {
                foreach (Process process  in  processes)
                {
                    foreach (FlowElement flowElement  in  process.findFlowElementsOfType(typeof(SubProcess) ) )
                    {
                        foundFlowElement = getFlowElementInSubProcess(id, (SubProcess) flowElement);
                        if (foundFlowElement != null)
                        {
                            break;
                        }
                    }
                    if (foundFlowElement != null)
                    {
                        break;
                    }
                }
            }

            return foundFlowElement;
        }

        protected FlowElement getFlowElementInSubProcess(String id, SubProcess subProcess)
        {
            FlowElement foundFlowElement = subProcess.getFlowElement(id);
            if (foundFlowElement == null)
            {
                foreach (FlowElement flowElement  in  subProcess.FlowElements)
                {
                    if ((flowElement as SubProcess) != null)
                    {
                        foundFlowElement = getFlowElementInSubProcess(id, (SubProcess) flowElement);
                        if (foundFlowElement != null)
                        {
                            break;
                        }
                    }
                }
            }
            return foundFlowElement;
        }

        public Artifact getArtifact(String id)
        {
            Artifact foundArtifact = null;
            foreach (Process process  in  processes)
            {
                foundArtifact = process.getArtifact(id);
                if (foundArtifact != null)
                {
                    break;
                }
            }

            if (foundArtifact == null)
            {
                foreach (Process process  in  processes)
                {
                    foreach (FlowElement flowElement in process.findFlowElementsOfType(typeof(SubProcess)))
                    {
                        foundArtifact = getArtifactInSubProcess(id, (SubProcess) flowElement);
                        if (foundArtifact != null)
                        {
                            break;
                        }
                    }
                    if (foundArtifact != null)
                    {
                        break;
                    }
                }
            }

            return foundArtifact;
        }

        protected Artifact getArtifactInSubProcess(String id, SubProcess subProcess)
        {
            Artifact foundArtifact = subProcess.getArtifact(id);
            if (foundArtifact == null)
            {
                foreach (FlowElement flowElement  in  subProcess.FlowElements)
                {
                    if ((flowElement as SubProcess)!=null)
                    {
                        foundArtifact = getArtifactInSubProcess(id, (SubProcess) flowElement);
                        if (foundArtifact != null)
                        {
                            break;
                        }
                    }
                }
            }
            return foundArtifact;
        }

        public void addGraphicInfo(String key, GraphicInfo graphicInfo)
        {
            locationMap.Add(key, graphicInfo);
        }

        public GraphicInfo getGraphicInfo(String key)
        {
            return locationMap[key];
        }

        public void removeGraphicInfo(String key)
        {
            locationMap.Remove(key);
        }

        public List<GraphicInfo> getFlowLocationGraphicInfo(String key)
        {
            return flowLocationMap[key];
        }

        public void removeFlowGraphicInfoList(String key)
        {
            flowLocationMap.Remove(key);
        }

        public GraphicInfo getLabelGraphicInfo(String key)
        {
            return labelLocationMap[key];
        }

        public void addLabelGraphicInfo(String key, GraphicInfo graphicInfo)
        {
            labelLocationMap.Add(key, graphicInfo);
        }

        public void removeLabelGraphicInfo(String key)
        {
            labelLocationMap.Remove(key);
        }

        public void addFlowGraphicInfoList(String key, List<GraphicInfo> graphicInfoList)
        {
            flowLocationMap.Add(key, graphicInfoList);
        }

        public void setSignals(Collection<Signal> signalList)
        {
            if (signalList != null)
            {
                signals.Clear();
                signals.AddRange(signalList);
            }
        }

        public void addSignal(Signal signal)
        {
            if (signal != null)
            {
                signals.Add(signal);
            }
        }

        public bool containsSignalId(String signalId)
        {
            return getSignal(signalId) != null;
        }

        public Signal getSignal(String id)
        {
            foreach (Signal signal  in  signals)
            {
                if (id.Equals(signal.Id))
                {
                    return signal;
                }
            }
            return null;
        }

        public void addMessageFlow(MessageFlow messageFlow)
        {
            if (messageFlow != null && !String.IsNullOrWhiteSpace(messageFlow.Id))
            {
                messageFlowMap.Add(messageFlow.Id, messageFlow);
            }
        }

        public MessageFlow getMessageFlow(String id)
        {
            return messageFlowMap[id];
        }

        public bool containsMessageFlowId(String messageFlowId)
        {
            return messageFlowMap.ContainsKey(messageFlowId);
        }

        public void setMessages(Collection<Message> messageList)
        {
            if (messageList != null)
            {
                messageMap.Clear();
                foreach (Message message  in  messageList)
                {
                    addMessage(message);
                }
            }
        }

        public void addMessage(Message message)
        {
            if (message != null && !String.IsNullOrWhiteSpace(message.Id))
            {
                messageMap.Add(message.Id, message);
            }
        }

        public Message getMessage(String id)
        {
            return messageMap[id];
        }

        public bool containsMessageId(String messageId)
        {
            return messageMap.ContainsKey(messageId);
        }

        public void addError(String errorRef, String errorCode)
        {
            if (!String.IsNullOrWhiteSpace(errorRef))
            {
                errorMap.Add(errorRef, errorCode);
            }
        }

        public bool containsErrorRef(String errorRef)
        {
            return errorMap.ContainsKey(errorRef);
        }

        public void addItemDefinition(String id, ItemDefinition item)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                itemDefinitionMap.Add(id, item);
            }
        }

        public bool containsItemDefinitionId(String id)
        {
            return itemDefinitionMap.ContainsKey(id);
        }

        public DataStore getDataStore(String id)
        {
            DataStore dataStore = null;
            if (dataStoreMap.ContainsKey(id))
            {
                dataStore = dataStoreMap[id];
            }
            return dataStore;
        }

        public void addDataStore(String id, DataStore dataStore)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                dataStoreMap.Add(id, dataStore);
            }
        }

        public bool containsDataStore(String id)
        {
            return dataStoreMap.ContainsKey(id);
        }

        public void addNamespace(String prefix, String uri)
        {
            NamespaceMap.Add(prefix, uri);
        }

        public bool containsNamespacePrefix(String prefix)
        {
            return NamespaceMap.ContainsKey(prefix);
        }

        public String getNamespace(String prefix)
        {
            return NamespaceMap[prefix];
        }

    }
}
