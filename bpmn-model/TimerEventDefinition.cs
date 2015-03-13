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

/**
 * //@author Tijs Rademakers
 */

    public class TimerEventDefinition : EventDefinition
    {

        protected String timeDate;
        protected String timeDuration;
        protected String timeCycle;

        public String getTimeDate()
        {
            return timeDate;
        }

        public void setTimeDate(String timeDate)
        {
            this.timeDate = timeDate;
        }

        public String getTimeDuration()
        {
            return timeDuration;
        }

        public void setTimeDuration(String timeDuration)
        {
            this.timeDuration = timeDuration;
        }

        public String getTimeCycle()
        {
            return timeCycle;
        }

        public void setTimeCycle(String timeCycle)
        {
            this.timeCycle = timeCycle;
        }

        public override object clone()
        {
            TimerEventDefinition clone = new TimerEventDefinition();
            clone.setValues(this);
            return clone;
        }

        public void setValues(TimerEventDefinition otherDefinition)
        {
            base.setValues(otherDefinition);
            setTimeDate(otherDefinition.getTimeDate());
            setTimeDuration(otherDefinition.getTimeDuration());
            setTimeCycle(otherDefinition.getTimeCycle());
        }
    }
}