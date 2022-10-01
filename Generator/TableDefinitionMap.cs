using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Generator
{
    public class TableDefinitionMap: EntityTypeConfiguration<TableDefinition>
    {
        public TableDefinitionMap()
        {
            this.HasKey(t => new { SchemaName = t.SchemaName, TableName = t.TableName });
            this.Property(t => t.SchemaName).HasColumnName("TABLE_SCHEMA").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(t => t.TableName).HasColumnName("TABLE_NAME").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Ignore(t => t.Procedures);
            this.ToTable("TABLES", "INFORMATION_SCHEMA");
        }
    }
}
