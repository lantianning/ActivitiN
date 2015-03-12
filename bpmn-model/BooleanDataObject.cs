using System;

namespace org.activiti.bpmn.model
{

    public class BooleanDataObject : ValuedDataObject
    {

        public override void setValue(Object value)
        {
            Value = Boolean.Parse(value.ToString());
        }

        public override object clone()
        {
            BooleanDataObject clone = new BooleanDataObject();
            clone.setValues(this);
            return clone;
        }
    }
}