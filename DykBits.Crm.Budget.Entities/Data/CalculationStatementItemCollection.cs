using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementItemCollection: ObservableCollection<CalculationStatementItem>
    {
        private CalculationStatement _owner;
        private bool _initialized;
        internal CalculationStatementItemCollection(CalculationStatement owner)
        {
            this._owner = owner;
        }
        internal void Initialize()
        {
            var owner = this._owner;
            var sections = new Dictionary<int, CalculationStatementSectionItem>();

            foreach (var section in owner.Sections)
            {
                var sectionItem = new CalculationStatementSectionItem(section);
                this.Add(sectionItem);
                sections.Add(sectionItem.Section.CalculationStatementSectionId, sectionItem);
            }
            foreach (var line in owner.Lines)
            {
                this.Add(owner.CreateItem(sections[line.CalculationStatementSectionId], line));
            }
            this.Add(this._owner.SubtotalSectionItem);
            this.Add(this._owner.SubtotalWithDiscountSectionItem);
            this.Add(this._owner.SubtotalWithVATSectionItem);
            this._initialized = true;
        }
        public void MoveUp(CalculationStatementLineItem lineItem)
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
        public void MoveDown(CalculationStatementLineItem lineItem)
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
        public void MoveUp(CalculationStatementSectionItem sectionItem)
        {
            int sectionIndex = this._owner.Items.IndexOf(sectionItem);
            this._owner.Items.Move(sectionIndex, sectionIndex - 1);
            this._owner.Sections.MoveUp(sectionItem.Section);
        }
        public void MoveDown(CalculationStatementSectionItem sectionItem)
        {
            int sectionIndex = this._owner.Items.IndexOf(sectionItem);
            this._owner.Items.Move(sectionIndex, sectionIndex + 1);
            this._owner.Sections.MoveDown(sectionItem.Section);
        }
        public CalculationStatementSectionItem Add(CalculationStatementSection section)
        {
            var sectionItem = new CalculationStatementSectionItem(section);
            this._owner.Sections.Add(section);
            this._owner.Items.Insert(this._owner.Sections.Count - 1, sectionItem);
            return sectionItem;
        }
        public CalculationStatementLineItem Add(CalculationStatementSectionItem section, CalculationStatementLine line)
        {
            this._owner.Lines.Add(line);
            CalculationStatementLineItem item = this._owner.CreateItem(section, line);
            this._owner.Items.Add(item);
            return item;
        }
        public void Remove(CalculationStatementLineItem line)
        {
            this.Remove((CalculationStatementItem)line);
            this._owner.Lines.Remove(line.Line);
        }
        public void Remove(CalculationStatementSectionItem section)
        {
            CalculationStatementLineItem[] lines = this._owner.Items.Where(t => t.ParentId == section.Id).OfType<CalculationStatementLineItem>().ToArray();
            foreach (var line in lines)
                this.Remove((CalculationStatementItem)line);
            this.Remove((CalculationStatementItem)section);
            this._owner.Sections.Remove(section.Section);
        }
        protected override void InsertItem(int index, CalculationStatementItem item)
        {
            base.InsertItem(index, item);
            if (this._initialized)
            {
                if (item is CalculationStatementLineItem)
                    item.SectionItem.InvokeSectionChanged();
            }
            item.PropertyChanged += ItemPropertyChanged;
        }

        void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this._owner.InvokeItemPropertyChanged((CalculationStatementItem)sender, e.PropertyName);
        }
        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);
            if (item is CalculationStatementLineItem)
                item.SectionItem.InvokeSectionChanged();
        }
    }
}
