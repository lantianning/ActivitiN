using System;

namespace org.activiti.bpmn.model
{
    public class Import : BaseElement
    {

        protected String ImportType { get; set; }
        protected String Location { get; set; }
        protected String Namespace { get; set; }

        public override object clone()
        {
            Import clone = new Import();
            clone.setValues(this);
            return clone;
        }

        public void setValues(Import otherElement)
        {
            base.setValues(otherElement);
            ImportType = otherElement.ImportType;
            Location = otherElement.Location;
            Namespace = otherElement.Namespace;
        }
    }
}