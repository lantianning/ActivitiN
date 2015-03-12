using System;

namespace org.activiti.bpmn.model{
public class DoubleDataObject : ValuedDataObject {

  public override void setValue(Object value) {
    Value = Double.Parse(value.ToString());
  }

  public override object clone() {
    DoubleDataObject clone = new DoubleDataObject();
    clone.setValues(this);
    return clone;
  }
}
}