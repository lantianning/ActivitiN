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

	public class Process : BaseElement, FlowElementsContainer, HasExecutionListeners
	{

		public String Name { get; set; }
		public String Documentation { get; set; }
		public IOSpecification IoSpecification { get; set; }
		protected Boolean _executable = true;
		protected List<ActivitiListener> _executionListeners = new List<ActivitiListener>();
		protected List<Lane> _lanes = new List<Lane>();
		protected List<FlowElement> _flowElementList = new List<FlowElement>();
		protected List<ValuedDataObject> _dataObjects = new List<ValuedDataObject>();
		protected List<Artifact> _artifactList = new List<Artifact>();
		protected List<String> _candidateStarterUsers = new List<String>();
		protected List<String> _candidateStarterGroups = new List<String>();
		protected List<EventListener> _eventListeners = new List<EventListener>();

		public bool Executable
		{
			get { return _executable; }
			set { _executable = value; }
		}

		public List<ActivitiListener> ExecutionListeners
		{
			get { return _executionListeners; }
			set { _executionListeners = value; }
		}

		public List<Lane> Lanes
		{
			get { return _lanes; }
			set { _lanes = value; }
		}

		public List<FlowElement> FlowElements
		{
			get { return _flowElementList; }
			set { _flowElementList = value; }
		}

		public List<ValuedDataObject> DataObjects
		{
			get { return _dataObjects; }
			set { _dataObjects = value; }
		}

		public List<Artifact> Artifacts
		{
			get { return _artifactList; }
			set { _artifactList = value; }
		}

		public List<string> CandidateStarterUsers
		{
			get { return _candidateStarterUsers; }
			set { _candidateStarterUsers = value; }
		}

		public List<string> CandidateStarterGroups
		{
			get { return _candidateStarterGroups; }
			set { _candidateStarterGroups = value; }
		}

		public List<EventListener> EventListeners
		{
			get { return _eventListeners; }
			set { _eventListeners = value; }
		}

		public Dictionary<string, List<ExtensionElement>> ExtensionElements1
		{
			get { return _extensionElements; }
			set { _extensionElements = value; }
		}

		public Dictionary<string, List<ExtensionAttribute>> Attributes1
		{
			get { return _attributes; }
			set { _attributes = value; }
		}


		public Process()
		{

		}

		public FlowElement getFlowElement(String flowElementId)
		{
			return findFlowElementInList(flowElementId);
		}

		/**
   * Searches the whole process, including subprocesses (unlike {@link getFlowElements(String)}
   */

		public FlowElement getFlowElementRecursive(String flowElementId)
		{
			return getFlowElementRecursive(this, flowElementId);
		}

		protected FlowElement getFlowElementRecursive(FlowElementsContainer flowElementsContainer, String flowElementId)
		{
			foreach (FlowElement flowElement in
			flowElementsContainer.FlowElements)
			{
				if (flowElement.Id != null && flowElement.Id.Equals(flowElementId))
				{
					return flowElement;
				}
				else if (flowElement is FlowElementsContainer)
				{
					FlowElement result = getFlowElementRecursive((FlowElementsContainer) flowElement, flowElementId);
					if (result != null)
					{
						return result;
					}
				}
			}
			return null;
		}

		/**
   * Searches the whole process, including subprocesses
   */

		public FlowElementsContainer getFlowElementsContainerRecursive(String flowElementId)
		{
			return getFlowElementsContainerRecursive(this, flowElementId);
		}

		protected FlowElementsContainer getFlowElementsContainerRecursive(FlowElementsContainer flowElementsContainer,
			String flowElementId)
		{
			foreach (FlowElement flowElement in
			flowElementsContainer.FlowElements)
			{
				if (flowElement.Id != null && flowElement.Id.Equals(flowElementId))
				{
					return flowElementsContainer;
				}
				else if (flowElement
				is FlowElementsContainer)
				{
					FlowElementsContainer result = getFlowElementsContainerRecursive(
						(FlowElementsContainer) flowElement, flowElementId);
					if (result != null)
					{
						return result;
					}
				}
			}
			return null;
		}

		protected FlowElement findFlowElementInList(String flowElementId)
		{
			foreach (FlowElement f in
			_flowElementList)
			{
				if (f.Id != null && f.Id.Equals(flowElementId))
				{
					return f;
				}
			}
			return null;
		}

		public void addFlowElement(FlowElement element)
		{
			_flowElementList.Add(element);
		}

		public void removeFlowElement(String elementId)
		{
			FlowElement element = findFlowElementInList(elementId);
			if (element != null)
			{
				_flowElementList.Remove(element);
			}
		}

		public Artifact getArtifact(String id)
		{
			return _artifactList.SingleOrDefault(a => a.Id == id);
		}

		public void addArtifact(Artifact artifact)
		{
			_artifactList.Add(artifact);
		}

		public void removeArtifact(String artifactId)
		{
			Artifact artifact = getArtifact(artifactId);
			if (artifact != null)
			{
				_artifactList.Remove(artifact);
			}
		}

		public List<FlowElement> findFlowElementsOfType(Type type, Boolean goIntoSubprocesses = true)
		{
			List<FlowElement> foundFlowElements = new List<FlowElement>();
			foreach (FlowElement flowElement in FlowElements)
			{
				if (type == flowElement.GetType())
				{
					foundFlowElements.Add((FlowElement) flowElement);
				}
				if (flowElement
				is SubProcess)
				{
					if (goIntoSubprocesses)
					{
						foundFlowElements.AddRange(findFlowElementsInSubProcessOfType((SubProcess) flowElement, type));
					}
				}
			}
			return foundFlowElements;
		}


		private List<FlowElement> findFlowElementsInSubProcessOfType(SubProcess subProcess,
			Type type, Boolean goIntoSubprocesses = true)
		{
			List<FlowElement> foundFlowElements = new List<FlowElement>();
			foreach (FlowElement flowElement in
			subProcess.FlowElements)
			{
				if (type== flowElement.GetType())
				{
					foundFlowElements.Add((FlowElement) flowElement);
				}
				if (flowElement
				is SubProcess)
				{
					if (goIntoSubprocesses)
					{
						foundFlowElements.AddRange(findFlowElementsInSubProcessOfType((SubProcess) flowElement, type));
					}
				}
			}
			return foundFlowElements;
		}

		public FlowElementsContainer findParent(FlowElement childElement)
		{
			return findParent(childElement, this);
		}

		public FlowElementsContainer findParent(FlowElement childElement, FlowElementsContainer flowElementsContainer)
		{
			foreach (FlowElement flowElement in flowElementsContainer.FlowElements)
			{
				if (childElement.Id != null && childElement.Id.Equals(flowElement.Id))
				{
					return flowElementsContainer;
				}
				var element = flowElement as FlowElementsContainer;
				if (element != null)
				{
					var result = findParent(childElement, element);
					if (result != null)
					{
						return result;
					}
				}
			}
			return null;
		}

		public override object clone()
		{
			Process clone = new Process();
			clone.setValues(this);
			return clone;
		}

		public void setValues(Process otherElement)
		{
			base.setValues(otherElement);

			Name = otherElement.Name;
			Executable = otherElement.Executable;
			Documentation = otherElement.Documentation;
			if (otherElement.IoSpecification != null)
			{
				IoSpecification = (IOSpecification)otherElement.IoSpecification.clone();
			}

			_executionListeners = new List<ActivitiListener>();
			if (otherElement.ExecutionListeners != null && otherElement.ExecutionListeners.Any())
			{
				foreach (ActivitiListener listener in
				otherElement.ExecutionListeners)
				{
					_executionListeners.Add((ActivitiListener)listener.clone());
				}
			}

			_candidateStarterUsers = new List<String>();
			if (otherElement.CandidateStarterUsers != null && otherElement.CandidateStarterUsers.Any())
			{
				_candidateStarterUsers.AddRange(otherElement.CandidateStarterUsers);
			}

			_candidateStarterGroups = new List<String>();
			if (otherElement.CandidateStarterGroups != null && otherElement.CandidateStarterGroups.Any())
			{
				_candidateStarterGroups.AddRange(otherElement.CandidateStarterGroups);
			}

			if (otherElement.EventListeners != null && otherElement.EventListeners.Any())
			{
				_eventListeners = otherElement.EventListeners.Select(evt => (EventListener) evt.clone()).ToList();
			}

			/*
	 * This is required because data objects in Designer have no DI info
	 * and are added as properties, not flow elements
	 *
	 * Determine the differences between the 2 elements' data object
	 */
			foreach (ValuedDataObject thisObject in DataObjects)
			{
				Boolean exists = false;
				foreach (ValuedDataObject otherObject in otherElement.DataObjects)
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

			_dataObjects = new List<ValuedDataObject>();
			if (otherElement.DataObjects != null && otherElement.DataObjects.Any())
			{
				foreach (ValuedDataObject dataObject in otherElement.DataObjects)
				{
					ValuedDataObject clone = (ValuedDataObject)dataObject.clone();
					_dataObjects.Add(clone);
					// add it to the list of FlowElements
					// if it is already there, remove it first so order is same as data object list
					removeFlowElement(clone.Id);
					addFlowElement(clone);
				}
			}
		}

		public List<ValuedDataObject> getDataObjects()
		{
			return _dataObjects;
		}

		public void setDataObjects(List<ValuedDataObject> dataObjects)
		{
			this._dataObjects = dataObjects;
		}
	}
}