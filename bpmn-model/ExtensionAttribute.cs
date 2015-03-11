using System;
using System.Text;

namespace org.activiti.bpmn.model{}



public class ExtensionAttribute {

  public String Name { get; set; }
  public String Value { get; set; }
  public String NamespacePrefix { get; set; }
  public String Namespace { get; set; }

  public ExtensionAttribute() {
  }

  public ExtensionAttribute( String name) {
    Name = name;
  }

  public ExtensionAttribute(String Namespace, String name) {
    this.Namespace = Namespace;
    Name = name;
  }


  public String toString() {
    StringBuilder sb = new StringBuilder();
    if (NamespacePrefix != null) {
      sb.Append(NamespacePrefix);
      if (Name != null)
        sb.Append(":").Append(Name);
    } else
      sb.Append(Name);
    if (Value != null)
      sb.Append("=").Append(Value);
    return sb.ToString();
  }
  
  public ExtensionAttribute clone() {
    ExtensionAttribute clone = new ExtensionAttribute();
    clone.setValues(this);
    return clone;
  }
  
  public void setValues(ExtensionAttribute otherAttribute) {
    Name = otherAttribute.Name;
    Value = otherAttribute.Value;
    NamespacePrefix = otherAttribute.NamespacePrefix;
    Namespace = otherAttribute.Namespace;
  }
}
