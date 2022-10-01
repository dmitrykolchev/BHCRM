using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generator
{
    public class DocumentStateMap : EntityTypeConfiguration<DocumentState>
    {
        public DocumentStateMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(t => t.DocumentTypeId).HasColumnName("DocumentTypeId").HasColumnType("int").IsRequired();
            this.Property(t => t.State).HasColumnName("State").HasColumnType("tinyint").IsRequired();
            this.Property(t => t.OrdinalPosition).HasColumnName("OrdinalPosition").HasColumnType("int").IsRequired();
            this.Property(t => t.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            this.Property(t => t.Caption).HasColumnName("Caption").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            this.Property(t => t.OverlayImage).HasColumnName("OverlayImage").HasColumnType("varbinary(max)").IsOptional();
            this.Property(t => t.Description).HasColumnName("Description").HasColumnType("nvarchar(max)").IsOptional();

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
            this.ToTable("DocumentState", "dbo");
        }
    }
}
