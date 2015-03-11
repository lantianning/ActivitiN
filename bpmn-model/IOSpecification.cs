using System;
using System.Collections.Generic;
using System.Linq;

namespace org.activiti.bpmn.model
{

    public class IOSpecification : BaseElement
    {

        protected List<DataSpec> _dataInputs = new List<DataSpec>();
        protected List<DataSpec> _dataOutputs = new List<DataSpec>();
        protected List<String> _dataInputRefs = new List<String>();
        protected List<String> _dataOutputRefs = new List<String>();
        public List<DataSpec> DataInputs {get { return _dataInputs; }set { _dataInputs = value; }}
        public List<DataSpec> DataOutputs { get { return _dataOutputs; } set { _dataOutputs = value; } }
        public List<String> DataInputRefs { get { return _dataInputRefs; } set { _dataInputRefs = value; } }
        public List<String> DataOutputRefs { get { return _dataOutputRefs; } set { _dataOutputRefs = value; } }

        public override object clone()
        {
            IOSpecification clone = new IOSpecification();
            clone.setValues(this);
            return clone;
        }

        public void setValues(IOSpecification otherSpec)
        {
            DataInputs = new List<DataSpec>();
            if (otherSpec.DataInputs != null && otherSpec.DataInputs.Any())
            {
                foreach (DataSpec dataSpec in
                otherSpec.DataInputs)
                {
                    DataInputs.Add((DataSpec)dataSpec.clone());
                }
            }

            DataOutputs = new List<DataSpec>();
            if (otherSpec.DataOutputs != null && otherSpec.DataOutputs.Any())
            {
                foreach (DataSpec dataSpec in
                otherSpec.DataOutputs)
                {
                    DataOutputs.Add((DataSpec)dataSpec.clone());
                }
            }

            DataInputRefs = new List<String>(otherSpec.DataInputRefs);
            DataOutputRefs = new List<String>(otherSpec.DataOutputRefs);
        }
    }
}