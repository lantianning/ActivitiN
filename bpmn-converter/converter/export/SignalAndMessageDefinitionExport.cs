namespace org.activiti.bpmn.converter.export{















public class SignalAndMessageDefinitionExport : BpmnXMLConstants {

  public static void writeSignalsAndMessages(BpmnModel model, XMLStreamWriter xtw) throws Exception {
    
    for (Process process : model.getProcesses()) {
      for (FlowElement flowElement : process.findFlowElementsOfType(Event.class)) {
        Event Event = (Event) flowElement;
        if (!Event.getEventDefinitions().isEmpty()) {
          EventDefinition eventDefinition = Event.getEventDefinitions().get(0);
          if (eventDefinition instanceof SignalEventDefinition) {
            SignalEventDefinition signalEvent = (SignalEventDefinition) eventDefinition;
            if (model.containsSignalId(signalEvent.getSignalRef()) == false) {
              Signal signal = new Signal(signalEvent.getSignalRef(), signalEvent.getSignalRef());
              model.addSignal(signal);
            }

          } else if (eventDefinition instanceof MessageEventDefinition) {
            MessageEventDefinition messageEvent = (MessageEventDefinition) eventDefinition;
            if (model.containsMessageId(messageEvent.getMessageRef()) == false) {
              Message message = new Message(messageEvent.getMessageRef(), messageEvent.getMessageRef(), null);
              model.addMessage(message);
            }
          }
        }
      }
    }
    
    for (Signal signal : model.getSignals()) {
      xtw.writeStartElement(ELEMENT_SIGNAL);
      xtw.writeAttribute(ATTRIBUTE_ID, signal.getId());
      xtw.writeAttribute(ATTRIBUTE_NAME, signal.getName());
      if (signal.getScope() != null) {
        xtw.writeAttribute(ACTIVITI_EXTENSIONS_NAMESPACE, ATTRIBUTE_SCOPE, signal.getScope());
      }
      xtw.writeEndElement();
    }
    
    for (Message message : model.getMessages()) {
      xtw.writeStartElement(ELEMENT_MESSAGE);
      String messageId = message.getId();
      // remove the namespace from the message id if set
      if (model.getTargetNamespace() != null && messageId.startsWith(model.getTargetNamespace())) {
        messageId = messageId.replace(model.getTargetNamespace(), "");
        messageId = messageId.replaceFirst(":", "");
      } else {
        for (String prefix : model.getNamespaces().keySet()) {
          String Namespace = model.getNamespace(prefix);
          if (messageId.startsWith(Namespace)) {
            messageId = messageId.replace(model.getTargetNamespace(), "");
            messageId = prefix + messageId;
          }
        }
      }
      xtw.writeAttribute(ATTRIBUTE_ID, messageId);
      if (StringUtils.isNotEmpty(message.getName())) {
        xtw.writeAttribute(ATTRIBUTE_NAME, message.getName());
      }
      if (StringUtils.isNotEmpty(message.getItemRef())) {
        // replace the namespace by the right prefix
        String itemRef = message.getItemRef();
        for (String prefix : model.getNamespaces().keySet()) {
            String Namespace = model.getNamespace(prefix);
            if (itemRef.startsWith(Namespace)) {
                if (prefix.isEmpty()) {
                    itemRef = itemRef.replace(Namespace + ":", "");
                } else {
                    itemRef = itemRef.replace(Namespace, prefix);
                }
                break;
            }
        }
        xtw.writeAttribute(ATTRIBUTE_ITEM_REF, itemRef);
      }
      xtw.writeEndElement();
    }
  }
}
