using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Generator
{
    public class ColumnInfo
    {
        public int Ordinal { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int IsNullable { get; set; }
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }

    }
}
