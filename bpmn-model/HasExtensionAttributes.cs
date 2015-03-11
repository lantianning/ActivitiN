using System;
using System.Collections.Generic;

namespace org.activiti.bpmn.model
{
    public interface HasExtensionAttributes
    {
        Dictionary<String, List<ExtensionAttribute>> Attributes { get; set; }
        String getAttributeValue(String Namespace, String name);
        void addAttribute(ExtensionAttribute attribute);
    }
}