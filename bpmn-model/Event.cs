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

using System.Collections.Generic;
using System.Linq;

namespace org.activiti.bpmn.model
{

    public abstract class Event : FlowNode
    {

        protected List<EventDefinition> eventDefinitions = new List<EventDefinition>();

        public List<EventDefinition> EventDefinitions
        {
            get{return eventDefinitions;}
            set{this.eventDefinitions = value;}
            
        }

        public void addEventDefinition(EventDefinition eventDefinition)
        {
            eventDefinitions.Add(eventDefinition);
        }

        public void setValues(Event otherEvent)
        {
            base.setValues(otherEvent);

            EventDefinitions = new List<EventDefinition>();
            if (otherEvent.EventDefinitions != null && otherEvent.EventDefinitions.Any())
            {
                foreach (EventDefinition eventDef in otherEvent.EventDefinitions)
                {
                    EventDefinitions.Add((EventDefinition)eventDef.clone());
                }
            }
        }
    }
}