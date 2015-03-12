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

namespace org.activiti.bpmn.model
{
    public class GraphicInfo
    {

        protected double x;
        protected double y;
        protected double height;
        protected double width;
        protected FlowElement element;
        protected Boolean expanded;
        protected int xmlRowNumber;
        protected int xmlColumnNumber;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public FlowElement Element
        {
            get { return element; }
            set { element = value; }
        }

        public bool Expanded
        {
            get { return expanded; }
            set { expanded = value; }
        }

        public int XmlRowNumber
        {
            get { return xmlRowNumber; }
            set { xmlRowNumber = value; }
        }

        public int XmlColumnNumber
        {
            get { return xmlColumnNumber; }
            set { xmlColumnNumber = value; }
        }
    }
}
