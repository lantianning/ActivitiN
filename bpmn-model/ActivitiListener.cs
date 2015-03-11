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

    public class ActivitiListener : BaseElement
    {

        public String Event { get; set; }
        public String ImplementationType { get; set; }
        public String Implementation { get; set; }
        protected List<FieldExtension> _fieldExtensions = new List<FieldExtension>();

        public List<FieldExtension> FieldExtensions
        {
            get { return _fieldExtensions; }
            set { _fieldExtensions = value; }
        }

        public override object clone()
        {
            ActivitiListener clone = new ActivitiListener();
            clone.setValues(this);
            return clone;
        }

        public void setValues(ActivitiListener otherListener)
        {
            Event = otherListener.Event;
            Implementation = otherListener.Implementation;
            ImplementationType = otherListener.ImplementationType;

            FieldExtensions = new List<FieldExtension>();
            if (otherListener.FieldExtensions != null && otherListener.FieldExtensions.Any())
            {
                foreach (FieldExtension extension in otherListener.FieldExtensions)
                {
                    FieldExtensions.Add((FieldExtension)extension.clone());
                }
            }
        }
    }
}