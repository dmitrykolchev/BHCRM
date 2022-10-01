using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class FinanceReportItem
    {
        private Nullable<int> _level;
        protected FinanceReportItem()
        {
        }
        internal FinanceReportItem ParentInternal { get; set; }
        public int Id { get; internal set; }
        public int ParentId { get { return ParentInternal == null ? 0 : ParentInternal.Id; } }
        public int Level
        {
            get
            {
                if (_level.HasValue)
                    return _level.Value;
                if (ParentInternal != null)
                    return ParentInternal.Level + 1;
                return 0;
            }
            set
            {
                _level = value;
            }
        }
        public string FileAs { get; set; }
        public virtual bool IsEmpty
        {
            get { return false; }
        }
    }

    public abstract class FinanceReportItemFactory<T> where T: FinanceReportItem, new()
    {
        private List<T> _list = new List<T>();
        protected FinanceReportItemFactory()
        {
        }
        public T CreateInstance(string fileAs = null, T parent = default(T), Nullable<int> level = null)
        {
            var item = new T() { FileAs = fileAs, ParentInternal = parent, Id = this._list.Count + 1 };
            if (level.HasValue)
                item.Level = level.Value;
            this._list.Add(item);
            return item;
        }
        public IList<T> List
        {
            get { return this._list; }
        }
    }
}
