using System;

namespace org.activiti.bpmn.model
{

    public class ItemDefinition : BaseElement
    {

        protected String _structureRef;
        protected String _itemKind;

        public string StructureRef
        {
            get { return _structureRef; }
            set { _structureRef = value; }
        }

        public string ItemKind
        {
            get { return _itemKind; }
            set { _itemKind = value; }
        }

        public override object clone()
        {
            ItemDefinition clone = new ItemDefinition();
            clone.setValues(this);
            return clone;
        }

        public void setValues(ItemDefinition otherElement)
        {
            base.setValues(otherElement);
            StructureRef = otherElement.StructureRef;
            ItemKind = otherElement.ItemKind;
        }
    }
}