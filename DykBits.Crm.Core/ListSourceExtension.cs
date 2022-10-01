using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    [MarkupExtensionReturnType(typeof(IList))]
    public class ListSourceExtension : MarkupExtension
    {
        private static readonly SimpleDataItemView[] _fakeList = {
                                                                     new SimpleDataItemView { Id = 1, State = 1,  FileAs= "Simple Data Item #1" },
                                                                     new SimpleDataItemView { Id = 2, State = 1,  FileAs= "Simple Data Item #2" },
                                                                     new SimpleDataItemView { Id = 3, State = 1,  FileAs= "Simple Data Item #3" }
                                                                 };
        public ListSourceExtension()
        {
        }

        public ListSourceExtension(string dataSourceName)
        {
            this.DataSourceName = dataSourceName;
        }
        public byte State
        {
            get;
            set;
        }
        [DefaultValue(null)]
        public string DataSourceName { get; set; }
        [DefaultValue(null)]
        public bool OrderById { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationManager.IsInitialized)
            {
                DocumentRecordCollection result;
                ListManager listManager = ServiceManager.GetService<ListManager>();
                if (OrderById)
                    result = listManager.GetListOrderById(DataSourceName);
                else
                    result = listManager.GetList(DataSourceName);
                if (State != 0)
                    return result.Where(t => t.State == State);
                return result;
            }
            return _fakeList;
        }
    }
}
