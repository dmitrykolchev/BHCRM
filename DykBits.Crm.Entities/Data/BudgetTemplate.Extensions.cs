using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(BudgetTemplateLine))]
    partial class BudgetTemplate
    {
        private BudgetTemplateLineCollection _lines;
        private DocumentRecordCollection _budgetItems;
        private DocumentRecordCollection _budgetItemsGroups;

        public BudgetTemplateLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                    this._lines = new BudgetTemplateLineCollection(this);
                return this._lines;
            }
        }

        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }

        [XmlIgnore]
        public DocumentRecordCollection BudgetItems
        {
            get
            {
                if (this._budgetItems == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._budgetItems = listManager.GetList("BudgetItem");
                }
                return this._budgetItems;
            }
        }

        [XmlIgnore]
        public DocumentRecordCollection BudgetItemGroups
        {
            get
            {
                if (this._budgetItemsGroups == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._budgetItemsGroups = listManager.GetList("BudgetItemGroup");
                }
                return this._budgetItemsGroups;
            }
        }

        private BudgetTemplateLineProxyCollection _items;
        [XmlIgnore]
        public BudgetTemplateLineProxyCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new BudgetTemplateLineProxyCollection();
                    foreach (var line in Lines.OrderBy(t => t.BudgetItem.Code))
                    {
                        this._items.Add(line);
                    }
                    this._items.RecalculateFixedLines();
                }
                return this._items;
            }
        }

        public void RefreshItems()
        {
            BudgetTemplate budget = DocumentManager.GetItem<BudgetTemplate>(this.Id);
            foreach (var line in budget.Lines)
            {
                BudgetTemplateLineProxy itemProxy = FindItemForLine(line);
                itemProxy.StandardValue = line.StandardValue;
            }
            this._items.RecalculateFixedLines();
        }

        private BudgetTemplateLineProxy FindItemForLine(BudgetTemplateLine line)
        {
            foreach (var item in Items)
            {
                if (item.BudgetItemId == line.BudgetItemId)
                    return item;
            }
            throw new InvalidOperationException();
        }
    }

    public class BudgetTemplateLineProxyCollection : Collection<BudgetTemplateLineProxy>
    {
        public BudgetTemplateLineProxyCollection()
        {
            Add(new BudgetTemplateLineProxy { Id = 1, ParentId = 0, Level = 0, FileAs = "Основной" });
            Add(new BudgetTemplateLineProxy { Id = 2, ParentId = 1, Level = 1, FileAs = "Доходы" });
            Add(new BudgetTemplateLineProxy { Id = 3, ParentId = 1, Level = 1, FileAs = "Расходы" });
            Add(new BudgetTemplateLineProxy { Id = 4, ParentId = 1, Level = 1, FileAs = "Рентабельность" });
        }
        internal void RecalculateFixedLines()
        {
            RecalculateLine(this[1]);
            RecalculateLine(this[2]);
            this[3].StandardValue = this[1].StandardValue - this[2].StandardValue;
            if (this[2].StandardValue != 0)
                this[3].StandardPercentage = this[3].StandardValue / this[2].StandardValue;
            else
                this[3].StandardPercentage = null;
        }

        private void RecalculateLine(BudgetTemplateLineProxy line)
        {
            Nullable<decimal> standard = null;
            foreach (var item in this.Where(t => t.ParentId == line.Id))
            {
                if (item.StandardValue.HasValue)
                {
                    if (!standard.HasValue)
                        standard = 0;
                    standard += item.StandardValue.Value;
                }
            }
            line.StandardValue = standard;
        }

        private static int[] parentIds = new int[] { 0, 2, 3 };
        public void Add(BudgetTemplateLine line)
        {
            this.Add(new BudgetTemplateLineProxy
            {
                Id = line.BudgetTemplateLineId + 100,
                BudgetItemId = line.BudgetItemId,
                ParentId = parentIds[line.BudgetItemGroup.Id],
                Level = 2,
                FileAs = line.FileAs,
                StandardValue = line.StandardValue,
            });
        }
    }

    public class BudgetTemplateLineCollection : Collection<BudgetTemplateLine>
    {
        private BudgetTemplate _owner;
        public BudgetTemplateLineCollection(BudgetTemplate owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, BudgetTemplateLine item)
        {
            item.Parent = this._owner;
            base.InsertItem(index, item);
        }
    }

}
