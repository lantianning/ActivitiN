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

namespace org.activiti.bpmn.model
{

    public abstract class FlowNode : FlowElement
    {

        protected List<SequenceFlow> incomingFlows = new List<SequenceFlow>();
        protected List<SequenceFlow> outgoingFlows = new List<SequenceFlow>();

        public List<SequenceFlow> IncomingFlows
        {
            get { return incomingFlows; }
            set { incomingFlows = value; }
        }
        public List<SequenceFlow> OutgoingFlows
        {
            get { return outgoingFlows; }
            set { outgoingFlows = value; }
        }
        public void setValues(FlowNode otherNode)
        {
            base.setValues(otherNode);
        }
    }
}