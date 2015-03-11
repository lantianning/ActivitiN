using System;

namespace org.activiti.bpmn.model
{


    public abstract class ValuedDataObject : DataObject
    {
        public Object _value;

        public object Value
        {
            get { return _value; }
            set { setValue(value); }
        }

        public abstract void setValue(Object value);

        public abstract override object clone();

        public void setValues(ValuedDataObject otherElement)
        {
            base.setValues(otherElement);
            if (otherElement.Value != null)
            {
                setValue(otherElement.Value);
            }
        }

        public bool equals(ValuedDataObject otherObject)
        {

            if (!otherObject.ItemSubjectRef.StructureRef.Equals(ItemSubjectRef.StructureRef))
                return false;
            if (!otherObject.Id.Equals(Id)) return false;
            if (!otherObject.Name.Equals(Name)) return false;
            if (!otherObject.Value.Equals(_value.ToString())) return false;

            return true;
        }
    }
}