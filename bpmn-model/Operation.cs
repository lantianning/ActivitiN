using System;
using System.Collections.Generic;
using System.Linq;

namespace org.activiti.bpmn.model
{
    public class Operation : BaseElement
    {

        protected String name;
        protected String implementationRef;
        protected String inMessageRef;
        protected String outMessageRef;
        protected List<String> errorMessageRef = new List<String>();

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

        public string InMessageRef
        {
            get { return inMessageRef; }
            set { inMessageRef = value; }
        }

        public string OutMessageRef
        {
            get { return outMessageRef; }
            set { outMessageRef = value; }
        }

        public List<string> ErrorMessageRef
        {
            get { return errorMessageRef; }
            set { errorMessageRef = value; }
        }

        public override object clone()
        {
            Operation clone = new Operation();
            clone.setValues(this);
            return clone;
        }

        public void setValues(Operation otherElement)
        {
            base.setValues(otherElement);
            Name = otherElement.Name;
            ImplementationRef = otherElement.ImplementationRef;
            InMessageRef = otherElement.InMessageRef;
            OutMessageRef = otherElement.OutMessageRef;

            errorMessageRef = new List<String>();
            if (otherElement.ErrorMessageRef != null && otherElement.ErrorMessageRef.Any())
            {
                errorMessageRef.AddRange(otherElement.ErrorMessageRef);
            }
        }
    }
}