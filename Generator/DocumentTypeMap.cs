using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generator
{
    public class DocumentTypeMap: EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(t => t.ClassName).HasColumnName("ClassName").HasColumnType("varchar").HasMaxLength(256).IsRequired();
            this.Property(t => t.TableName).HasColumnName("TableName").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            this.Property(t => t.SchemaName).HasColumnName("SchemaName").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(t => t.ClrTypeName).HasColumnName("ClrTypeName").HasColumnType("varchar").HasMaxLength(1024).IsOptional();
            this.Property(t => t.DataAdapterTypeName).HasColumnName("DataAdapterTypeName").HasColumnType("varchar").HasMaxLength(1024).IsOptional();
            this.Property(t => t.DataAdapterType).HasColumnName("DataAdapterType").HasColumnType("varchar").HasMaxLength(32).IsOptional();
            this.Property(t => t.IsNumbered).HasColumnName("IsNumbered").HasColumnType("bit").IsRequired();
            this.Property(t => t.Description).HasColumnName("Description").HasColumnType("nvarchar(max)").IsOptional();
            this.Property(t => t.SupportsTransitionTemplates).HasColumnName("SupportsTransitionTemplates").HasColumnType("bit").IsRequired();
            this.Property(t => t.Caption).HasColumnName("Caption").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            this.Property(t => t.SmallImage).HasColumnName("SmallImage").HasColumnType("varbinary(max)").IsOptional();
            this.Property(t => t.LargeImage).HasColumnName("LargeImage").HasColumnType("varbinary(max)").IsOptional();

            this.Property(t => t.Created)
                .HasColumnName("Created")
                .HasColumnType("datetime")
                .IsRequired();
            
            this.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("int")
                .IsRequired();

            this.Property(t => t.Modified)
                .HasColumnName("Modified")
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(t => t.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasColumnType("int")
                .IsRequired();

            this.Property(t => t.RowVersion)
                .HasColumnName("RowVersion")
                .HasColumnType("timestamp")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.ToTable("DocumentType", "dbo");
        }
    }
}
