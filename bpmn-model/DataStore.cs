using System;

namespace org.activiti.bpmn.model{
public class DataStore : BaseElement {
  
  protected String Name { get; set; }
  protected String DataState { get; set; }
  protected String ItemSubjectRef { get; set; }
  

  public override object clone() {
    DataStore clone = new DataStore();
    clone.setValues(this);
    return clone;
  }
  
  public void setValues(DataStore otherElement) {
    base.setValues(otherElement);
    Name=otherElement.Name;
    DataState=otherElement.DataState;
    ItemSubjectRef=otherElement.ItemSubjectRef;
  }

}
