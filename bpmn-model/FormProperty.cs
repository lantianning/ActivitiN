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

namespace org.activiti.bpmn.model
{


    public class FormProperty : BaseElement
    {

        protected String name;
        protected String expression;
        protected String variable;
        protected String type;
        protected String defaultExpression;
        protected String datePattern;
        protected bool readable = true;
        protected bool writeable = true;
        protected bool required;
        protected List<FormValue> formValues = new List<FormValue>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public string Variable
        {
            get { return variable; }
            set { variable = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string DefaultExpression
        {
            get { return defaultExpression; }
            set { defaultExpression = value; }
        }

        public string DatePattern
        {
            get { return datePattern; }
            set { datePattern = value; }
        }

        public bool Readable
        {
            get { return readable; }
            set { readable = value; }
        }

        public bool Writeable
        {
            get { return writeable; }
            set { writeable = value; }
        }

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public List<FormValue> FormValues
        {
            get { return formValues; }
            set { formValues = value; }
        }

        public override object clone()
        {
            FormProperty clone = new FormProperty();
            clone.setValues(this);
            return clone;
        }

        public void setValues(FormProperty otherProperty)
        {
            base.setValues(otherProperty);
            Name = otherProperty.Name;
            Expression = otherProperty.Expression;
            Variable = otherProperty.Variable;
            Type = otherProperty.Type;
            DefaultExpression = otherProperty.DefaultExpression;
            DatePattern = otherProperty.DatePattern;
            Readable = otherProperty.Readable;
            Writeable = otherProperty.Writeable;
            Required = otherProperty.Required;

            if (otherProperty.FormValues != null)
            {
                formValues = otherProperty.FormValues.Select(f => (FormValue) f.clone()).ToList();
            }
        }
    }
}