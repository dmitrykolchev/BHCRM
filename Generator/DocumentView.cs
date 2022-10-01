using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class DocumentView
    {
        public DocumentView()
        {
        }
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string ViewName { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }
        public string DataAdapterTypeName { get; set; }
        public string DataAdapterType { get; set; }
        public string ClrTypeName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
