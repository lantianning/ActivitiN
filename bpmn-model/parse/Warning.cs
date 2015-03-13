using System;

namespace org.activiti.bpmn.model.parse
{





    public class Warning
    {

        protected String warningMessage;
        protected String resource;
        protected int line;
        protected int column;

        //public Warning(String warningMessage, XMLStreamReader xtr) {
        //  this.warningMessage = warningMessage;
        //  this.resource = xtr.getLocalName();
        //  this.line = xtr.getLocation().getLineNumber();
        //  this.column = xtr.getLocation().getColumnNumber();
        //}

        public Warning(String warningMessage, BaseElement element)
        {
            this.warningMessage = warningMessage;
            this.resource = element.Id;
            line = element.XmlRowNumber;
            column = element.XmlColumnNumber;
        }

        public String toString()
        {
            return warningMessage + (resource != null ? " | " + resource : "") + " | line " + line + " | column " +
                   column;
        }
    }
}