using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Generator
{
    public class ColumnDefinitionMap: EntityTypeConfiguration<ColumnDefinition>
    {
        public ColumnDefinitionMap()
        {
            this.HasKey(t => new { SchemaName = t.SchemaName, TableName = t.TableName, ColumnName=t.ColumnName });
            this.Property(t => t.SchemaName).HasColumnName("TABLE_SCHEMA").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(t => t.TableName).HasColumnName("TABLE_NAME").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(t => t.ColumnName).HasColumnName("COLUMN_NAME").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(t => t.OrdinalPosition).HasColumnName("ORDINAL_POSITION").HasColumnType("int");
            this.Property(t => t.IsNullable).HasColumnName("IS_NULLABLE").HasColumnType("varchar");
            this.Property(t => t.DataType).HasColumnName("DATA_TYPE").HasColumnType("varchar");
            this.Property(t => t.MaximumLength).HasColumnName("CHARACTER_MAXIMUM_LENGTH").HasColumnType("int").IsOptional();
            this.Property(t => t.DomainName).HasColumnName("DOMAIN_NAME").HasColumnType("nvarchar").IsOptional();
            this.Property(t => t.NumericPrecision).HasColumnName("NUMERIC_PRECISION").HasColumnType("tinyint").IsOptional();
            this.Property(t => t.NumericScale).HasColumnName("NUMERIC_SCALE").HasColumnType("int").IsOptional();
            this.ToTable("COLUMNS", "INFORMATION_SCHEMA");
        }
    }
}
