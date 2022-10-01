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
    [TypeMapping(typeof(PriceListLine))]
    partial class PriceList
    {
        private PriceListLineCollection _lines;
        private DocumentRecordCollection _margins;
        private DocumentRecordCollection _products;

        public PriceListLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new PriceListLineCollection(this);
                    this._lines.CollectionChanged +=_lines_CollectionChanged;
                }
                return this._lines;
            }
        }
        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }

        public void Generate(int productCategoryId)
        {
            IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<Product>();
            ProductFilter filter = (ProductFilter)dataAdapter.CreateFilter(null, null);
            filter.States = new byte[] { (byte)ProductState.Active };
            filter.ProductCategoryId = productCategoryId;
            var products = dataAdapter.Browse(filter.ToXml());
            Lines.Clear();
            foreach (ProductView product in products)
            {
                Lines.Add(new PriceListLine(product));
            }
        }

        [XmlIgnore]
        public DocumentRecordCollection Products
        {
            get
            {
                if (this._products == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._products = listManager.GetList(Product.DataItemClassName);
                }
                return this._products;
            }
        }

        [XmlIgnore]
        public DocumentRecordCollection Margins
        {
            get
            {
                if(this._margins == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._margins = listManager.GetList(PriceMargin.DataItemClassName);
                }
                return this._margins;
            }
        }
    }

    public class PriceListLineCollection : ObservableCollection<PriceListLine>
    {
        private PriceList _owner;
        internal PriceListLineCollection(PriceList owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, PriceListLine item)
        {
            item.PriceList = this._owner;
            base.InsertItem(index, item);
        }
    }
}
