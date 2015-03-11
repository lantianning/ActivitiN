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


    public class SubProcess : Activity, FlowElementsContainer
    {

        protected List<FlowElement> flowElementList = new List<FlowElement>();
        protected List<Artifact> artifactList = new List<Artifact>();
        protected List<ValuedDataObject> dataObjects = new List<ValuedDataObject>();

        public List<FlowElement> FlowElements
        {
            get { return flowElementList; }
            set { flowElementList = value; }
        }

        public List<Artifact> Artifacts
        {
            get { return artifactList; }
            set { artifactList = value; }
        }

        public List<ValuedDataObject> DataObjects
        {
            get { return dataObjects; }
            set { dataObjects = value; }
        }

        public FlowElement getFlowElement(String id)
        {
            FlowElement foundElement = null;
            if (!String.IsNullOrWhiteSpace(id))
            {
                foreach (FlowElement element  in  flowElementList)
                {
                    if (id.Equals(element.Id))
                    {
                        foundElement = element;
                        break;
                    }
                }
            }
            return foundElement;
        }

        public void addFlowElement(FlowElement element)
        {
            flowElementList.Add(element);
        }

        public void removeFlowElement(String elementId)
        {
            FlowElement element = getFlowElement(elementId);
            if (element != null)
            {
                flowElementList.Remove(element);
            }
        }

        public Artifact getArtifact(String id)
        {
            Artifact foundArtifact = null;
            foreach (Artifact artifact  in  artifactList)
            {
                if (id.Equals(artifact.Id))
                {
                    foundArtifact = artifact;
                    break;
                }
            }
            return foundArtifact;
        }

 
        public void addArtifact(Artifact artifact)
        {
            artifactList.Add(artifact);
        }

        public void removeArtifact(String artifactId)
        {
            Artifact artifact = getArtifact(artifactId);
            if (artifact != null)
            {
                artifactList.Remove(artifact);
            }
        }

        public override object clone()
        {
            SubProcess clone = new SubProcess();
            clone.setValues(this);
            return clone;
        }

        public void setValues(SubProcess otherElement)
        {
            base.setValues(otherElement);

            /*
     * This is required because data objects in Designer have no DI info
     * and are added as properties, not flow elements
     *
     * Determine the differences between the 2 elements' data object
     */
            foreach (ValuedDataObject thisObject  in DataObjects)
            {
                bool exists = false;
                foreach (ValuedDataObject otherObject  in  otherElement.DataObjects)
                {
                    if (thisObject.Id.Equals(otherObject.Id))
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    // missing object
                    removeFlowElement(thisObject.Id);
                }
            }

            dataObjects = new List<ValuedDataObject>();
            if (otherElement.DataObjects != null && otherElement.DataObjects.Any())
            {
                foreach (ValuedDataObject dataObject  in  otherElement.DataObjects)
                {
                    ValuedDataObject clone = (ValuedDataObject)dataObject.clone();
                    dataObjects.Add(clone);
                    // add it to the list of FlowElements
                    // if it is already there, remove it first so order is same as data object list
                    removeFlowElement(clone.Id);
                    addFlowElement(clone);
                }
            }

            /*flowElementList = new List<FlowElement>();
    if (otherElement.getFlowElements() != null && otherElement.getFlowElements().size() > 0) {
      for (FlowElement element : otherElement.getFlowElements()) {
        flowElementList.Add(element.clone());
      }
    }
    
    artifactList = new List<Artifact>();
    if (otherElement.getArtifacts() != null && otherElement.getArtifacts().size() > 0) {
      for (Artifact artifact : otherElement.getArtifacts()) {
        artifactList.Add(artifact.clone());
      }
    }*/
        }

        public List<ValuedDataObject> getDataObjects()
        {
            return dataObjects;
        }

        public void setDataObjects(List<ValuedDataObject> dataObjects)
        {
            this.dataObjects = dataObjects;
        }
    }
}