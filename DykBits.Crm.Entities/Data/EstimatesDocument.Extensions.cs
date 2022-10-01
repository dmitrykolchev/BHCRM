using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(EstimatesDocumentSection))]
    [TypeMapping(typeof(EstimatesDocumentLine))]
    [ReportDataSource(typeof(Reports.EstimatesDocumentReport))]
    partial class EstimatesDocument
    {
        private EstimatesDocumentLineCollection _lines;
        private EstimatesDocumentSectionCollection _sections;
        private EstimatesDocumentItemCollection _items;
        private VATRateView _vatRate;
        private ExtraCostRateView _extraCostRate;

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == ExtraCostRateIdProperty)
            {
                if (this.ExtraCostRateId == 0)
                    return "Необходимо указать ставку доп. расходов";
            }
            else if (propertyInfo.Name == ServiceRequestIdProperty)
            {
                if (this.ServiceRequestId == 0)
                    return "Выберите заказ покупателя";
            }
            else if (propertyInfo.Name == OrganizationIdProperty)
            {
                if (this.OrganizationId == 0)
                    return "Выберите организацию";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }

        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == VATRateIdProperty)
            {
                this._vatRate = null;
                InvokePropertyChanged("VATRate");
                this.VATItem.InvokeLineChanged();
                this.SubtotalWithVATItem.InvokeSectionChanged();
            }
            else if (propertyName == ExtraCostRateIdProperty)
            {
                this._extraCostRate = null;
                InvokePropertyChanged("ExtraCostRate");
                if (this._items != null)
                {
                    foreach (var item in this._items)
                    {
                        if (item.Level == 1 && !item.ReadOnly)
                            item.CashCost = item.CashCost;
                    }
                }
            }
            else if (propertyName == CommissionProperty)
            {
                this.CommissionItem.InvokeLineChanged();
                this.SubtotalWithCommissionItem.InvokeSectionChanged();
                this.VATItem.InvokeLineChanged();
                this.SubtotalWithVATItem.InvokeSectionChanged();
            }
        }

        [XmlIgnore]
        public ExtraCostRateView ExtraCostRate
        {
            get
            {
                if (this._extraCostRate == null)
                {
                    this._extraCostRate = ListManager.GetItem<ExtraCostRateView>(this.ExtraCostRateId);
                }
                return this._extraCostRate;
            }
        }

        [XmlIgnore]
        public VATRateView VATRate
        {
            get
            {
                if (this._vatRate == null)
                {
                    this._vatRate = ListManager.GetItem<VATRateView>(this.VATRateId);
                }
                return this._vatRate;
            }
        }

        public EstimatesDocumentLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new EstimatesDocumentLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }

        public EstimatesDocumentSectionCollection Sections
        {
            get
            {
                if (this._sections == null)
                {
                    this._sections = new EstimatesDocumentSectionCollection(this);
                    this._sections.CollectionChanged += _sections_CollectionChanged;
                }
                return this._sections;
            }
        }

        private EstimatesDocumentSection.Subtotal _subtotalSection;
        private EstimatesDocumentSection.SubtotalWithCommission _subtotalWithCommissionSection;
        private EstimatesDocumentSection.SubtotalWithVAT _subtotalWithVATSection;
        private EstimatesDocumentLine.Commission _commissionLine;
        private EstimatesDocumentLine.VAT _vatLine;

        [XmlIgnore]
        public EstimatesDocumentSection SubtotalSection
        {
            get
            {
                if (this._subtotalSection == null)
                {
                    this._subtotalSection = new EstimatesDocumentSection.Subtotal();
                    this._subtotalSection.Parent = this;
                }
                return this._subtotalSection;
            }
        }
        [XmlIgnore]
        public EstimatesDocumentLine CommissionLine
        {
            get
            {
                if (this._commissionLine == null)
                {
                    this._commissionLine = new EstimatesDocumentLine.Commission();
                    this._commissionLine.Parent = this;
                }
                return this._commissionLine;
            }
        }
        [XmlIgnore]
        public EstimatesDocumentSection SubtotalWithCommissionSection
        {
            get
            {
                if (this._subtotalWithCommissionSection == null)
                {
                    this._subtotalWithCommissionSection = new EstimatesDocumentSection.SubtotalWithCommission();
                    this._subtotalWithCommissionSection.Parent = this;
                }
                return this._subtotalWithCommissionSection;
            }
        }
        [XmlIgnore]
        public EstimatesDocumentLine VATLine
        {
            get
            {
                if (this._vatLine == null)
                {
                    this._vatLine = new EstimatesDocumentLine.VAT();
                    this._vatLine.Parent = this;
                }
                return this._vatLine;
            }
        }
        [XmlIgnore]
        public EstimatesDocumentSection SubtotalWithVATSection
        {
            get
            {
                if (this._subtotalWithVATSection == null)
                {
                    this._subtotalWithVATSection = new EstimatesDocumentSection.SubtotalWithVAT();
                    this._subtotalWithVATSection.Parent = this;
                }
                return this._subtotalWithVATSection;
            }
        }

        private EstimatesDocumentSectionItem _subtotalItem;
        private EstimatesDocumentSectionItem _subtotalWithCommissionItem;
        private EstimatesDocumentSectionItem _subtotalWithVATItem;
        private EstimatesDocumentLineItem _commissionItem;
        private EstimatesDocumentLineItem _vatItem;

        internal EstimatesDocumentSectionItem SubtotalItem
        {
            get
            {
                if (this._subtotalItem == null)
                    this._subtotalItem = new EstimatesDocumentSubtotalSectionItem(this.SubtotalSection);
                return this._subtotalItem;
            }
        }

        internal EstimatesDocumentSectionItem SubtotalWithCommissionItem
        {
            get
            {
                if (this._subtotalWithCommissionItem == null)
                    this._subtotalWithCommissionItem = new EstimatesDocumentSubtotalWithCommissionSectionItem(this.SubtotalWithCommissionSection);
                return this._subtotalWithCommissionItem;
            }
        }
        internal EstimatesDocumentSectionItem SubtotalWithVATItem
        {
            get
            {
                if (this._subtotalWithVATItem == null)
                    this._subtotalWithVATItem = new EstimatesDocumentSubtotalWithVATSectionItem(this.SubtotalWithVATSection);
                return this._subtotalWithVATItem;
            }
        }
        internal EstimatesDocumentLineItem CommissionItem
        {
            get
            {
                if (this._commissionItem == null)
                {
                    this._commissionItem = new EstimatesDocumentCommissionLineItem(this.SubtotalItem, this.CommissionLine);
                }
                return this._commissionItem;
            }
        }
        internal EstimatesDocumentLineItem VATItem
        {
            get
            {
                if (this._vatItem == null)
                {
                    this._vatItem = new EstimatesDocumentVATLineItem(this.SubtotalWithCommissionItem, this.VATLine);
                }
                return this._vatItem;
            }
        }
        [XmlIgnore]
        public EstimatesDocumentItemCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new EstimatesDocumentItemCollection(this);
                    this._items.Initialize();
                    this._items.CollectionChanged += _items_CollectionChanged;
                }
                return this._items;
            }
        }
        void _items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Items");
        }
        void _sections_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < this.Sections.Count; ++index)
                this.Sections[index].OrdinalPosition = index + 1;
            InvokePropertyChanged("Sections");
        }
        void _lines_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < this.Lines.Count; ++index)
                this.Lines[index].OrdinalPosition = index + 1;
            InvokePropertyChanged("Lines");
        }
    }

    public class EstimatesDocumentLineCollection : ObservableCollection<EstimatesDocumentLine>
    {
        private EstimatesDocument _owner;
        internal EstimatesDocumentLineCollection(EstimatesDocument owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, EstimatesDocumentLine item)
        {
            base.InsertItem(index, item);
            item.Parent = this._owner;
        }
    }

    public class EstimatesDocumentSectionCollection : ObservableCollection<EstimatesDocumentSection>
    {
        private EstimatesDocument _owner;

        internal EstimatesDocumentSectionCollection(EstimatesDocument owner)
        {
            this._owner = owner;
        }

        protected override void InsertItem(int index, EstimatesDocumentSection item)
        {
            base.InsertItem(index, item);
            item.Parent = this._owner;
        }

        internal void MoveUp(EstimatesDocumentSection section)
        {
            int index = this.IndexOf(section);
            this.Move(index, index - 1);
        }

        internal void MoveDown(EstimatesDocumentSection section)
        {
            int index = this.IndexOf(section);
            this.Move(index, index + 1);
        }
    }

    public class EstimatesDocumentItemCollection : ObservableCollection<EstimatesDocumentItem>
    {
        private EstimatesDocument _owner;
        internal EstimatesDocumentItemCollection(EstimatesDocument owner)
        {
            this._owner = owner;
        }

        public EstimatesDocumentSectionItem FirstSection
        {
            get
            {
                if(this._owner.Sections.Count > 0)
                    return (EstimatesDocumentSectionItem)this.Items[0];
                return null;
            }
        }

        public EstimatesDocumentSectionItem LastSection
        {
            get
            {
                if (this._owner.Sections.Count > 0)
                    return (EstimatesDocumentSectionItem)this.Items[this._owner.Sections.Count - 1];
                return null;
            }
        }

        public EstimatesDocumentLineItem Add(EstimatesDocumentSectionItem section, EstimatesDocumentLine line)
        {
            this._owner.Lines.Add(line);
            EstimatesDocumentLineItem item = new EstimatesDocumentLineItem(section, line);
            this._owner.Items.Add(item);
            return item;
        }

        public void Remove(EstimatesDocumentSectionItem section, EstimatesDocumentLineItem item)
        {
            this._owner.Items.Remove(item);
            this._owner.Lines.Remove(item.Line);
        }

        public void Remove(EstimatesDocumentSectionItem section)
        {
            EstimatesDocumentLineItem[] lines = this._owner.Items.Where(t => t.ParentId == section.Id).OfType<EstimatesDocumentLineItem>().ToArray();
            foreach (var line in lines)
                Remove(section, line);
            base.Remove(section);
            this._owner.Sections.Remove(section.Section);
        }

        public void MoveUp(EstimatesDocumentSectionItem section)
        {
            int sectionIndex = this._owner.Items.IndexOf(section);
            this._owner.Items.Move(sectionIndex, sectionIndex - 1);
            this._owner.Sections.MoveUp(section.Section);
        }

        public void MoveDown(EstimatesDocumentSectionItem section)
        {
            int sectionIndex = this._owner.Items.IndexOf(section);
            this._owner.Items.Move(sectionIndex, sectionIndex + 1);
            this._owner.Sections.MoveDown(section.Section);
        }

        public void MoveUp(EstimatesDocumentLineItem line)
        {
            var children = line.SectionItem.GetChildren();
            int currIndex = children.IndexOf(line);
            int currGlobalIndex = this._owner.Items.IndexOf(line);
            int prevGlobalIndex = this._owner.Items.IndexOf(children[currIndex - 1]);
            this._owner.Items.Move(currGlobalIndex, prevGlobalIndex);
            currGlobalIndex = this._owner.Lines.IndexOf(line.Line);
            prevGlobalIndex = this._owner.Lines.IndexOf(children[currIndex - 1].Line);
            this._owner.Lines.Move(currGlobalIndex, prevGlobalIndex);
        }

        public void MoveDown(EstimatesDocumentLineItem line)
        {
            var children = line.SectionItem.GetChildren();
            int currIndex = children.IndexOf(line);
            int currGlobalIndex = this._owner.Items.IndexOf(line);
            int nextGlobalIndex = this._owner.Items.IndexOf(children[currIndex + 1]);
            this._owner.Items.Move(currGlobalIndex, nextGlobalIndex);
            currGlobalIndex = this._owner.Lines.IndexOf(line.Line);
            nextGlobalIndex = this._owner.Lines.IndexOf(children[currIndex + 1].Line);
            this._owner.Lines.Move(currGlobalIndex, nextGlobalIndex);
        }

        internal void Initialize()
        {
            EstimatesDocument owner = this._owner;
            Dictionary<int, EstimatesDocumentSectionItem> sections = new Dictionary<int, EstimatesDocumentSectionItem>();

            foreach (var section in owner.Sections)
            {
                var sectionItem = new EstimatesDocumentSectionItem(section);
                this.Add(sectionItem);
                sections.Add(sectionItem.Section.EstimatesDocumentSectionId, sectionItem);
            }
            foreach (var line in owner.Lines)
            {
                this.Add(new EstimatesDocumentLineItem(sections[line.EstimatesDocumentSectionId], line));
            }
            this.Add(owner.SubtotalItem);
            this.Add(owner.CommissionItem);
            this.Add(owner.SubtotalWithCommissionItem);
            this.Add(owner.VATItem);
            this.Add(owner.SubtotalWithVATItem);
        }

        protected override void InsertItem(int index, EstimatesDocumentItem item)
        {
            base.InsertItem(index, item);
            if (item is EstimatesDocumentLineItem)
                item.SectionItem.InvokeSectionChanged();
        }

        protected override void RemoveItem(int index)
        {
            EstimatesDocumentItem item = this[index];
            base.RemoveItem(index);
            if (item is EstimatesDocumentLineItem)
                item.SectionItem.InvokeSectionChanged();
        }
    }
}
