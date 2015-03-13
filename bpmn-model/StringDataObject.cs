using System;

namespace org.activiti.bpmn.model
{


/**
 * //@author Lori Small
 */

    public class StringDataObject : ValuedDataObject
    {

        public override void setValue(Object value)
        {
            Value = value.ToString();
        }

        public override object clone()
        {
            StringDataObject clone = new StringDataObject();
            clone.setValues(this);
            return clone;
        }
    }
}