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

namespace org.activiti.bpmn.model
{
    public class MessageFlow : BaseElement
    {

        protected String Name { get; set; }
        protected String SourceRef { get; set; }
        protected String TargetRef { get; set; }
        protected String MessageRef { get; set; }

        public MessageFlow()
        {

        }

        public MessageFlow(String sourceRef, String targetRef)
        {
            SourceRef = sourceRef;
            TargetRef = targetRef;
        }

        public String ToString()
        {
            return SourceRef + " --> " + TargetRef;
        }

        public override object clone()
        {
            MessageFlow clone = new MessageFlow();
            clone.setValues(this);
            return clone;
        }

        public void setValues(MessageFlow otherFlow)
        {
            base.setValues(otherFlow);
            Name = otherFlow.Name;
            SourceRef = otherFlow.SourceRef;
            TargetRef = otherFlow.TargetRef;
            MessageRef = otherFlow.MessageRef;
        }
    }
}