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
    public abstract class Activity : FlowNode
    {

        public Boolean Asynchronous { get; set; }
        public Boolean NotExclusive { get; set; }
        public String DefaultFlow { get; set; }
        public Boolean ForCompensation { get; set; }
        public MultiInstanceLoopCharacteristics LoopCharacteristics { get; set; }
        public IOSpecification IoSpecification { get; set; }
        protected List<DataAssociation> _dataInputAssociations = new List<DataAssociation>();
        protected List<DataAssociation> _dataOutputAssociations = new List<DataAssociation>();
        protected List<BoundaryEvent> _boundaryEvents = new List<BoundaryEvent>();
        public String FailedJobRetryTimeCycleValue { get; set; }



        public List<BoundaryEvent> BoundaryEvents
        {
            get{return _boundaryEvents;}
            set { _boundaryEvents = value; }           
        }
        public List<DataAssociation> DataInputAssociations
        {
            get{return _dataInputAssociations;}
            set {_dataInputAssociations = value; }
            
        }
        public List<DataAssociation> DataOutputAssociations
        {
            get{return _dataOutputAssociations;}
            set {_dataOutputAssociations = value; }
            
        }
        public void setValues(Activity otherActivity)
        {
            base.setValues(otherActivity);
            Asynchronous = otherActivity.Asynchronous;
            FailedJobRetryTimeCycleValue = otherActivity.FailedJobRetryTimeCycleValue;
            NotExclusive = otherActivity.NotExclusive;
            DefaultFlow = otherActivity.DefaultFlow;
            ForCompensation = otherActivity.ForCompensation;
            if (otherActivity.LoopCharacteristics != null)
            {
                LoopCharacteristics = otherActivity.LoopCharacteristics.clone() as MultiInstanceLoopCharacteristics;
            }
            if (otherActivity.IoSpecification != null)
            {
                IoSpecification = otherActivity.IoSpecification.clone() as IOSpecification;
            }

            _dataInputAssociations = new List<DataAssociation>();
            if (otherActivity.DataInputAssociations != null && otherActivity.DataInputAssociations.Any())
            {
                foreach (DataAssociation association in
                otherActivity.DataInputAssociations)
                {
                    _dataInputAssociations.Add((DataAssociation)association.clone());
                }
            }

            _dataOutputAssociations = new List<DataAssociation>();
            if (otherActivity.DataOutputAssociations != null &&
                otherActivity.DataOutputAssociations.Any())
            {
                foreach (DataAssociation association in
                otherActivity.DataOutputAssociations)
                {
                    _dataOutputAssociations.Add((DataAssociation)association.clone());
                }
            }

            _boundaryEvents = new List<BoundaryEvent>();
            if (otherActivity.BoundaryEvents != null && otherActivity.BoundaryEvents.Any())
            {
                foreach (BoundaryEvent Event in otherActivity.BoundaryEvents)
                {
                    _boundaryEvents.Add((BoundaryEvent)Event.clone())
                    ;
                }
            }
        }
    }
}