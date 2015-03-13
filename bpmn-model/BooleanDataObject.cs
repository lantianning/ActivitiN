using System;

namespace org.activiti.bpmn.model
{

    public class boolDataObject : ValuedDataObject
    {

        public override void setValue(Object value)
        {
            Value = bool.Parse(value.ToString());
        }

        public override object clone()
        {
            boolDataObject clone = new boolDataObject();
            clone.setValues(this);
            return clone;
        }
    }
}