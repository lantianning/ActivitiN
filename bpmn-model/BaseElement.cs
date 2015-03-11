/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace org.activiti.bpmn.model
{
    public abstract class BaseElement : HasExtensionAttributes
    {

        public String Id { get; set; }
        public int XmlRowNumber { get; set; }
        public int XmlColumnNumber { get; set; }

        protected Dictionary<String, List<ExtensionElement>> _extensionElements =
            new Dictionary<String, List<ExtensionElement>>();

        protected Dictionary<String, List<ExtensionAttribute>> _attributes =
            new Dictionary<String, List<ExtensionAttribute>>();

        public Dictionary<String, List<ExtensionElement>> ExtensionElements
        {
            get { return _extensionElements; }
            set { _extensionElements = value; }
        }

        public Dictionary<String, List<ExtensionAttribute>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public void addExtensionElement(ExtensionElement extensionElement)
        {
            if (extensionElement != null && !String.IsNullOrWhiteSpace(extensionElement.Name))
            {
                List<ExtensionElement> elementList = null;
                if (ExtensionElements.ContainsKey(extensionElement.Name) == false)
                {
                    elementList = new List<ExtensionElement>();
                    ExtensionElements.Add(extensionElement.Name, elementList);
                }
                ExtensionElements[extensionElement.Name].Add(extensionElement);
            }
        }

        public String getAttributeValue(String Namespace, String name)
        {
            List<ExtensionAttribute> attributes = Attributes[name];
            if (attributes != null && attributes.Any())
            {
                foreach (ExtensionAttribute attribute in attributes)
                {
                    if ((Namespace == null && attribute.Namespace == null)
                        || Namespace == attribute.Namespace)
                        return attribute.Value;
                }
            }
            return null;
        }

        public void addAttribute(ExtensionAttribute attribute)
        {
            if (attribute != null && !String.IsNullOrWhiteSpace(attribute.Name))
            {
                List<ExtensionAttribute> attributeList = null;
                if (Attributes.ContainsKey(attribute.Name) == false)
                {
                    attributeList = new List<ExtensionAttribute>();
                    Attributes.Add(attribute.Name, attributeList);
                }
                Attributes[attribute.Name].Add(attribute);
            }
        }

        public void setValues(BaseElement otherElement)
        {
            Id = otherElement.Id;

            ExtensionElements = new Dictionary<String, List<ExtensionElement>>();
            if (otherElement.ExtensionElements != null && otherElement.ExtensionElements.Any())
            {
                foreach (String key in otherElement.ExtensionElements.Keys)
                {
                    List<ExtensionElement> otherElementList = otherElement.ExtensionElements[key];
                    if (otherElementList != null && otherElementList.Any())
                    {
                        List<ExtensionElement> elementList = new List<ExtensionElement>();
                        foreach (ExtensionElement extensionElement in otherElementList)
                        {
                            elementList.Add((ExtensionElement)extensionElement.clone());
                        }
                        ExtensionElements.Add(key, elementList);
                    }
                }
            }

            Attributes = new Dictionary<String, List<ExtensionAttribute>>();
            if (otherElement.Attributes != null && otherElement.Attributes.Any())
            {
                foreach (String key in otherElement.Attributes.Keys)
                {
                    List<ExtensionAttribute> otherAttributeList = otherElement.Attributes[key];
                    if (otherAttributeList != null && otherAttributeList.Any())
                    {
                        List<ExtensionAttribute> attributeList = new List<ExtensionAttribute>();
                        foreach (ExtensionAttribute extensionAttribute in otherAttributeList)
                        {
                            attributeList.Add(extensionAttribute.clone());
                        }
                        Attributes.Add(key, attributeList);
                    }
                }
            }
        }

        public abstract object clone();
    }
}