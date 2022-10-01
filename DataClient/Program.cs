using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using DykBits.Xml.Serialization;
using DykBits.Crm.Data;
using DykBits.Crm;

namespace DataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteConnectionManager connectionManager = new RemoteConnectionManager("Data Source=net.tcp://as3.bh.local:38734/DykBits.DataService/DocumentService/;Integrated Security=true;", "d.kolchev@bh.local");
            ServiceManager.Instance.AddService(typeof(IConnectionManager), connectionManager);

            RemoteDataService rds = new RemoteDataService();

            try
            {
                using (Stream stream = rds.GetDocumentMetadata())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DocumentMetadataList));
                    DocumentMetadataList list = (DocumentMetadataList)serializer.Deserialize(stream);
                    foreach (var item in list.Items)
                    {
                        Console.WriteLine(item.Caption);
                    }
                }
            }
            finally
            {
                rds.Close();
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            rds = new RemoteDataService();
            try
            {
                using (Stream stream = rds.Browse("BudgetItemView", Filter.EmptyXml))
                {
                    var items = DocumentSerializer.DeserializeCollection<BudgetItemView>(stream);
                    foreach (var item in items.OrderBy(t=>t.Id))
                    {
                        ItemKey key = item.GetKey();
                        using (Stream documentStream = rds.GetDocument(key))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(MyBudgetItem));
                            var document = (MyBudgetItem) serializer.Deserialize(documentStream);
                            serializer.Serialize(Console.Out, document);
                            //DocumentSerializer serializer = new DocumentSerializer(typeof(BudgetItem));
                            //var document = serializer.Deserialize<BudgetItem>(documentStream);
                            Console.WriteLine("[{0}] {1} - {2}", document.Id, document.Code, document.FileAs);
                        }
                    }
                }
            }
            finally
            {
                rds.Close();
            }
        }
    }
}
