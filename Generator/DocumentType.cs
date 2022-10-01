using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class DocumentType
    {
        public DocumentType()
        {
            States = new List<DocumentState>();
        }
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }
        public string DataAdapterTypeName { get; set; }
        public string DataAdapterType { get; set; }
        public bool IsNumbered { get; set; }
        public string ClrTypeName { get; set; }
        public string Caption { get; set; }
        public byte[] SmallImage { get; set; }
        public byte[] LargeImage { get; set; }
        public string Description { get; set; }
        public bool SupportsTransitionTemplates { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual IList<DocumentState> States { get; set; }
    }
}
