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
using System.Linq;

namespace org.activiti.bpmn.model
{

	public class UserTask : ActivityTask
	{

		protected String assignee;
		protected String owner;
		protected String priority;
		protected String formKey;
		protected String dueDate;
		protected String category;
		protected List<String> candidateUsers = new List<String>();
		protected List<String> candidateGroups = new List<String>();
		protected List<FormProperty> formProperties = new List<FormProperty>();
		protected List<ActivitiListener> taskListeners = new List<ActivitiListener>();
		protected String skipExpression;
		protected Dictionary<String, List<String>> customUserIdentityLinks = new Dictionary<String, List<String>>();
		protected Dictionary<String, List<String>> customGroupIdentityLinks = new Dictionary<String, List<String>>();

		public string Assignee
		{
			get { return assignee; }
			set { assignee = value; }
		}

		public string Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		public string Priority
		{
			get { return priority; }
			set { priority = value; }
		}

		public string FormKey
		{
			get { return formKey; }
			set { formKey = value; }
		}

		public string DueDate
		{
			get { return dueDate; }
			set { dueDate = value; }
		}

		public string Category
		{
			get { return category; }
			set { category = value; }
		}

		public List<string> CandidateUsers
		{
			get { return candidateUsers; }
			set { candidateUsers = value; }
		}

		public List<string> CandidateGroups
		{
			get { return candidateGroups; }
			set { candidateGroups = value; }
		}

		public List<FormProperty> FormProperties
		{
			get { return formProperties; }
			set { formProperties = value; }
		}

		public List<ActivitiListener> TaskListeners
		{
			get { return taskListeners; }
			set { taskListeners = value; }
		}

		public string SkipExpression
		{
			get { return skipExpression; }
			set { skipExpression = value; }
		}

		public Dictionary<string, List<string>> CustomUserIdentityLinks
		{
			get { return customUserIdentityLinks; }
			set { customUserIdentityLinks = value; }
		}

		public Dictionary<string, List<string>> CustomGroupIdentityLinks
		{
			get { return customGroupIdentityLinks; }
			set { customGroupIdentityLinks = value; }
		}

		public void addCustomUserIdentityLink(String userId, String type)
		{
			List<String> userIdentityList = customUserIdentityLinks[type];

			if (userIdentityList == null)
			{
				userIdentityList = new List<String>();
				customUserIdentityLinks.Add(type, userIdentityList);
			}

			userIdentityList.Add(userId);
		}

		public void addCustomGroupIdentityLink(String groupId, String type)
		{
			List<String> groupIdentityList = customGroupIdentityLinks[type];

			if (groupIdentityList == null)
			{
				groupIdentityList = new List<String>();
				customGroupIdentityLinks.Add(type, groupIdentityList);
			}

			groupIdentityList.Add(groupId);
		}


		public override object clone()
		{
			UserTask clone = new UserTask();
			clone.setValues(this);
			return clone;
		}

		public void setValues(UserTask otherElement)
		{
			base.setValues(otherElement);
			Assignee = otherElement.Assignee;
			Owner = otherElement.Owner;
			FormKey = otherElement.FormKey;
			DueDate = otherElement.DueDate;
			Priority = otherElement.Priority;
			Category = otherElement.Category;

			CandidateGroups = new List<String>(otherElement.CandidateGroups);
			CandidateUsers = new List<String>(otherElement.CandidateUsers);

			CustomGroupIdentityLinks = otherElement.customGroupIdentityLinks;
			CustomUserIdentityLinks = otherElement.customUserIdentityLinks;

			
			if (otherElement.FormProperties != null && otherElement.FormProperties.Any())
			{
			    formProperties = otherElement.FormProperties.Select(act => (FormProperty) act.clone()).ToList();
			}


			if (otherElement.TaskListeners != null && otherElement.TaskListeners.Any())
			{
			    taskListeners = otherElement.TaskListeners.Select(act => (ActivitiListener) act.clone()).ToList();
			}
		}
	}
}