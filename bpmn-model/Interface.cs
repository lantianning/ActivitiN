using System;
using System.Collections.Generic;
using System.Linq;

namespace org.activiti.bpmn.model
{
    public class Interface : BaseElement
    {

        protected String name;
        protected String implementationRef;
        protected List<Operation> operations = new List<Operation>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ImplementationRef
        {
            get { return implementationRef; }
            set { implementationRef = value; }
        }

        public List<Operation> Operations
        {
            get { return operations; }
            set { operations = value; }
        }

        public override object clone()
        {
            Interface clone = new Interface();
            clone.setValues(this);
            return clone;
        }

        public void setValues(Interface otherElement)
        {
            base.setValues(otherElement);
            Name = otherElement.Name;
            ImplementationRef = otherElement.ImplementationRef;

            operations = new List<Operation>();
            if (otherElement.Operations != null && otherElement.Operations.Any())
            {
                foreach (Operation operation in otherElement.Operations)
                {
                    operations.Add((Operation) operation.clone());
                }
            }
        }
    }
}