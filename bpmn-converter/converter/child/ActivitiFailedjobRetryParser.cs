namespace org.activiti.bpmn.converter.child{







public class ActivitiFailedjobRetryParser : BaseChildElementParser {

	@Override
	public String getElementName() {
		return FAILED_JOB_RETRY_TIME_CYCLE;
	}

	@Override
	public void parseChildElement(XMLStreamReader xtr,
         BaseElement parentElement, BpmnModel model) throws Exception {
		 if (!(parentElement instanceof Activity)) 
            return;
		 String cycle = xtr.getElementText();
		 if (cycle == null | cycle.isEmpty())
			 return;
		 ((Activity) parentElement).setFailedJobRetryTimeCycleValue(cycle);
	}

}
