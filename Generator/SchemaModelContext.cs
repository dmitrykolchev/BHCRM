using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Generator
{
    public class SchemaModelContext: DbContext
    {
        static SchemaModelContext()
        {
            Database.SetInitializer<SchemaModelContext>(null);
        }

        public SchemaModelContext()
            : base("name=SchemaModelContainer")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TableDefinitionMap());
            modelBuilder.Configurations.Add(new ColumnDefinitionMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new DocumentStateMap());
            modelBuilder.Configurations.Add(new DocumentViewMap());
        }

        public DbSet<TableDefinition> Tables { get; set; }
        public DbSet<ColumnDefinition> Columns { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentState> DocumentStates { get; set; }
        public DbSet<DocumentView> DocumentViews { get; set; }
    }
}
