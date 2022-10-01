using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class ReportDataSourceConverter
    {
        private IDataItem _source;
        protected ReportDataSourceConverter(IDataItem source)
        {
            this._source = source;
        }
        protected IDataItem Source
        {
            get { return this._source; }
        }
        public abstract DataSet[] GetReportData();
        public static DataSet[] GetReportData<M,D>(M master, D detals)
        {
            return new ReportDataSourceConverter.DataSet[] {
                new ReportDataSourceConverter.DataSet { Name = "DataSet1", Value = new M[] { master }},
                new ReportDataSourceConverter.DataSet { Name = "DataSet2", Value = detals }
            };
        }
        public string EmployeeName
        {
            get
            {
                IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
                return employee.FullName;
            }
        }
        public class DataSet
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}
