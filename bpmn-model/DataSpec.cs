using System;

namespace org.activiti.bpmn.model
{


    public class DataSpec : BaseElement
    {

        public String Name { get; set; }
        public String ItemSubjectRef { get; set; }
        public bool IsCollection { get; set; }


        public override object clone()
        {
            DataSpec clone = new DataSpec();
            clone.setValues(this);
            return clone;
        }

        public void setValues(DataSpec otherDataSpec)
        {
            Name=otherDataSpec.Name;
            ItemSubjectRef=otherDataSpec.ItemSubjectRef;
            IsCollection=otherDataSpec.IsCollection;
        }
    }
}