using System;
using System.Collections.Generic;
using System.Linq;

namespace org.activiti.bpmn.model
{

    public class DataAssociation : BaseElement
    {

        public String SourceRef { get; set; }
        public String TargetRef { get; set; }
        public String Transformation { get; set; }
        protected List<Assignment> _assignments = new List<Assignment>();

        public List<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }
        public override object clone()
        {
            DataAssociation clone = new DataAssociation();
            clone.setValues(this);
            return clone;
        }

        public void setValues(DataAssociation otherAssociation)
        {
            SourceRef = otherAssociation.SourceRef;
            TargetRef = otherAssociation.TargetRef;
            Transformation = otherAssociation.Transformation;

            _assignments = new List<Assignment>();
            if (otherAssociation.Assignments != null && !otherAssociation.Assignments.Any())
            {
                foreach (Assignment assignment in
                otherAssociation.Assignments)
                {
                    _assignments.Add((Assignment)assignment.clone());
                }
            }
        }
    }
}