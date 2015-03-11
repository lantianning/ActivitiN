using System;

namespace org.activiti.bpmn.model { 


public class Assignment : BaseElement {

  public String From { get; set; }
  public String To { get; set; }
  
  public override object clone() {
    Assignment clone = new Assignment();
    clone.setValues(this);
    return clone;
  }
  
  public void setValues(Assignment otherAssignment) {
    From=otherAssignment.From;
    To=otherAssignment.To;
  }
}
}