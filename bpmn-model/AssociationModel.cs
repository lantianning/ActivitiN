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
    public class AssociationModel
    {

        protected String id;
        protected AssociationDirection associationDirection;
        protected String sourceRef;
        protected String targetRef;
        protected Process parentProcess;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public AssociationDirection AssociationDirection
        {
            get { return associationDirection; }
            set { associationDirection = value; }
        }

        public string SourceRef
        {
            get { return sourceRef; }
            set { sourceRef = value; }
        }

        public string TargetRef
        {
            get { return targetRef; }
            set { targetRef = value; }
        }

        public Process ParentProcess
        {
            get { return parentProcess; }
            set { parentProcess = value; }
        }
    }
}