using System;

namespace org.activiti.bpmn.model.parse
{

    public class Problem
    {

        protected String errorMessage;
        protected String resource;
        protected int line;
        protected int column;

        //public Problem(String errorMessage, XMLStreamReader xtr)
        //{
        //    this.errorMessage = errorMessage;
        //    this.resource = xtr.LocalName;
        //    this.line = xtr.Location.getLineNumber();
        //    this.column = xtr.Location.getColumnNumber();
        //}

        public Problem(String errorMessage, BaseElement element)
        {
            this.errorMessage = errorMessage;
            this.resource = element.Id;
            line = element.XmlRowNumber;
            column = element.XmlColumnNumber;
        }

        public Problem(String errorMessage, GraphicInfo graphicInfo)
        {
            this.errorMessage = errorMessage;
            line = graphicInfo.XmlRowNumber;
            column = graphicInfo.XmlColumnNumber;
        }

        public String toString()
        {
            return errorMessage + (resource != null ? " | " + resource : "") + " | line " + line + " | column " + column;
        }
    }
}