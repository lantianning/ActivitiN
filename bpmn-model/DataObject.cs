using System;

namespace org.activiti.bpmn.model
{

    public class DataObject : FlowElement
{

    protected ItemDefinition _itemSubjectRef;

        public ItemDefinition ItemSubjectRef
        {
            get { return _itemSubjectRef; }
            set { _itemSubjectRef = value; }
        }


        public override object clone()
    {
        DataObject clone = new DataObject();
        clone.setValues(this);
        return clone;
    }

    public void setValues(DataObject otherElement)
    {
        base.setValues(otherElement);

        Id = otherElement.Id;
        Name = otherElement.Name;
        ItemSubjectRef = otherElement.ItemSubjectRef;
    }
}
}