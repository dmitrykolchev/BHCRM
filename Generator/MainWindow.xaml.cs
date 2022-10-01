using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using IO = System.IO;
using System.Xml;

namespace Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TableDefinition> _tables;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SchemaModelContext db = new SchemaModelContext();
            this._tables = db.Tables.OrderBy(t => t.TableName).ToList();
            this.DataContext = this._tables;
        }

        private void comboTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TableDefinition td = this.comboTable.SelectedItem as TableDefinition;
            int count = td.Columns.Count;
        }

        private void textScript_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textScript.SelectAll();
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            TableDefinition table = this.comboTable.SelectedItem as TableDefinition;
            string path = @"..\..\..\CrmDb\New Stored Procedures";
            path = IO.Path.Combine(path, table.TableName);
            if (!IO.Directory.Exists(path))
            {
                IO.Directory.CreateDirectory(path);
            }
            foreach (var item in table.Procedures)
            {
                string filePath = IO.Path.Combine(path, item.GetFileName());
                if ((item.ProcedureType == ProcedureType.Create || item.ProcedureType == ProcedureType.Update) && IO.File.Exists(filePath))
                {
                    continue;
                }
                using (IO.StreamWriter writer = IO.File.CreateText(filePath))
                {
                    writer.Write(item.Script);
                }
            }
            MessageBox.Show("Stored procedures successfully generated");
        }

        private void buttonGenerateDataAdapter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SchemaModelContext db = new SchemaModelContext())
                {

                    foreach (var item in db.DocumentTypes)
                    {
                        DataAdapterGenerator generator = new DataAdapterGenerator(item.ClassName);
                        generator.Generate();
                    }

                    foreach (var view in db.DocumentViews)
                    {
                        ViewDataAdapterGenerator generator = new ViewDataAdapterGenerator(view);
                        generator.Generate();
                    }
                }
                MessageBox.Show("Generation complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void buttonPublishMetadata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMetadataGenerator metadataGenerator = new DocumentMetadataGenerator();
                metadataGenerator.Generate();
                MessageBox.Show("Publish complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void buttonGenerateListProcs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SchemaModelContext db = new SchemaModelContext())
                {

                    foreach (var item in db.DocumentTypes)
                    {
                        TableDefinition table = this._tables.Where(t => t.TableName == item.TableName).Single();
                        ProcedureDefinition listProc = table.Procedures[1];
                        string path = @"..\..\..\CrmDb\Stored Procedures";
                        path = IO.Path.Combine(path, table.TableName);
                        if (!IO.Directory.Exists(path))
                        {
                            IO.Directory.CreateDirectory(path);
                        }
                        string filePath = IO.Path.Combine(path, listProc.GetFileName());
                        if (!IO.File.Exists(filePath))
                        {
                            using (IO.StreamWriter writer = IO.File.CreateText(filePath))
                            {
                                writer.Write(listProc.Script);
                            }
                        }
                    }
                }
                MessageBox.Show("Generation complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void buttonMetadataExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentMetadataGenerator metadataGenerator = new DocumentMetadataGenerator();
                metadataGenerator.ExportMetadata();
                MessageBox.Show("Export complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }
    }
}
