using System;

namespace org.activiti.bpmn.model{
public class DateDataObject : ValuedDataObject {

  public override void setValue(Object value) {
    Value = (DateTime) value;
  }

  public override object clone() {
    DateDataObject clone = new DateDataObject();
    clone.setValues(this);
    return clone;
  }
}
}