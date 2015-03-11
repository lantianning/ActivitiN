using System;
using System.Collections.Generic;
using System.Linq;
using org.activiti.bpmn.model;

namespace org.activiti.bpmn.model{}

public class ExtensionElement : BaseElement {

  public String Name { get; set; }
  public String NamespacePrefix { get; set; }
  public String Namespace { get; set; }
  public String ElementText { get; set; }
  protected Dictionary<String, List<ExtensionElement>> _childElements = new Dictionary<String, List<ExtensionElement>>();

  public Dictionary<String, List<ExtensionElement>> ChildElements { 
      get{return _childElements;} 
      set{_childElements = value;} 
  }

  public void addChildElement(ExtensionElement childElement) {
    if (childElement != null && !string.IsNullOrWhiteSpace(childElement.Name)) {
      List<ExtensionElement> elementList = null;
      if (this.ChildElements.ContainsKey(childElement.Name) == false) {
        elementList = new List<ExtensionElement>();
        this.ChildElements.Add(childElement.Name, elementList);
      }
      this.ChildElements[childElement.Name].Add(childElement);
    }
  }
  
  public override object clone() {
    var clone = new ExtensionElement();
    clone.setValues(this);
    return clone;
  }
  
  public void setValues(ExtensionElement otherElement) {
    Name = otherElement.Name;
    NamespacePrefix = otherElement.NamespacePrefix;
    Namespace = otherElement.Namespace;
    ElementText = otherElement.ElementText;
    Attributes = otherElement.Attributes;
    
    ChildElements = new Dictionary<String, List<ExtensionElement>>();
    if (otherElement.ChildElements != null && otherElement.ChildElements.Any()) {
      foreach (String key in otherElement.ChildElements.Keys) {
        List<ExtensionElement> otherElementList = otherElement.ChildElements[key];
        if (otherElementList != null && otherElementList.Any()) {
          List<ExtensionElement> elementList = new List<ExtensionElement>();
          foreach (ExtensionElement extensionElement in otherElementList) {
              elementList.Add((ExtensionElement)extensionElement.clone());
          }
          ChildElements.Add(key, elementList);
        }
      }
    }
  }
}
