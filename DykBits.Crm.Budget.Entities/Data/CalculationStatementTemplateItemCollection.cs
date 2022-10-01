using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateItemCollection: ObservableCollection<CalculationStatementTemplateItem>
    {
        private CalculationStatementTemplate _owner;
        private bool _initialized;
        internal CalculationStatementTemplateItemCollection(CalculationStatementTemplate owner)
        {
            this._owner = owner;
        }
        internal void Initialize()
        {
            var owner = this._owner;
            var sections = new Dictionary<int, CalculationStatementTemplateSectionItem>();

            foreach (var section in owner.Sections)
            {
                var sectionItem = new CalculationStatementTemplateSectionItem(section);
                this.Add(sectionItem);
                sections.Add(sectionItem.Section.CalculationStatementTemplateSectionId, sectionItem);
            }
            foreach (var line in owner.Lines)
            {
                this.Add(new CalculationStatementTemplateLineItem(sections[line.CalculationStatementTemplateSectionId], line));
            }
            this.Add(this._owner.SubtotalSectionItem);
            this._initialized = true;
        }
        public void MoveUp(CalculationStatementTemplateLineItem lineItem)
        {
            var children = lineItem.SectionItem.GetChildren();
            int currIndex = children.IndexOf(lineItem);
            int currGlobalIndex = this._owner.Items.IndexOf(lineItem);
            int prevGlobalIndex = this._owner.Items.IndexOf(children[currIndex - 1]);
            this._owner.Items.Move(currGlobalIndex, prevGlobalIndex);
            currGlobalIndex = this._owner.Lines.IndexOf(lineItem.Line);
            prevGlobalIndex = this._owner.Lines.IndexOf(children[currIndex - 1].Line);
            this._owner.Lines.Move(currGlobalIndex, prevGlobalIndex);
        }
        public void MoveDown(CalculationStatementTemplateLineItem lineItem)
        {
            var children = lineItem.SectionItem.GetChildren();
            int currIndex = children.IndexOf(lineItem);
            int currGlobalIndex = this._owner.Items.IndexOf(lineItem);
            int nextGlobalIndex = this._owner.Items.IndexOf(children[currIndex + 1]);
            this._owner.Items.Move(currGlobalIndex, nextGlobalIndex);
            currGlobalIndex = this._owner.Lines.IndexOf(lineItem.Line);
            nextGlobalIndex = this._owner.Lines.IndexOf(children[currIndex + 1].Line);
            this._owner.Lines.Move(currGlobalIndex, nextGlobalIndex);
        }
        public void MoveUp(CalculationStatementTemplateSectionItem sectionItem)
        {
            int sectionIndex = this._owner.Items.IndexOf(sectionItem);
            this._owner.Items.Move(sectionIndex, sectionIndex - 1);
            this._owner.Sections.MoveUp(sectionItem.Section);
        }
        public void MoveDown(CalculationStatementTemplateSectionItem sectionItem)
        {
            int sectionIndex = this._owner.Items.IndexOf(sectionItem);
            this._owner.Items.Move(sectionIndex, sectionIndex + 1);
            this._owner.Sections.MoveDown(sectionItem.Section);
        }
        public CalculationStatementTemplateSectionItem Add(CalculationStatementTemplateSection section)
        {
            var sectionItem = new CalculationStatementTemplateSectionItem(section);
            this._owner.Sections.Add(section);
            this._owner.Items.Insert(this._owner.Sections.Count - 1, sectionItem);
            return sectionItem;
        }
        public CalculationStatementTemplateLineItem Add(CalculationStatementTemplateSectionItem section, CalculationStatementTemplateLine line)
        {
            this._owner.Lines.Add(line);
            CalculationStatementTemplateLineItem item = new CalculationStatementTemplateLineItem(section, line);
            this._owner.Items.Add(item);
            return item;
        }
        public void Remove(CalculationStatementTemplateLineItem line)
        {
            this.Remove((CalculationStatementTemplateItem)line);
            this._owner.Lines.Remove(line.Line);
        }
        public void Remove(CalculationStatementTemplateSectionItem section)
        {
            CalculationStatementTemplateLineItem[] lines = this._owner.Items.Where(t => t.ParentId == section.Id).OfType<CalculationStatementTemplateLineItem>().ToArray();
            foreach (var line in lines)
                this.Remove((CalculationStatementTemplateItem)line);
            this.Remove((CalculationStatementTemplateItem)section);
            this._owner.Sections.Remove(section.Section);
        }
        protected override void InsertItem(int index, CalculationStatementTemplateItem item)
        {
            base.InsertItem(index, item);
            if (this._initialized)
            {
                if (item is CalculationStatementTemplateLineItem)
                    item.SectionItem.InvokeSectionChanged();
            }
            item.PropertyChanged += ItemPropertyChanged;
        }

        void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this._owner.InvokeItemPropertyChanged((CalculationStatementTemplateItem)sender, e.PropertyName);
        }
        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);
            if (item is CalculationStatementTemplateLineItem)
                item.SectionItem.InvokeSectionChanged();
        }
    }
}
