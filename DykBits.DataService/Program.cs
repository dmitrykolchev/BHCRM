using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using DykBits.Crm;
using DykBits.Crm.Data;

namespace DykBits.DataService
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Certificate2Collection coll = new X509Certificate2Collection();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Program), "crm.pfx"))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    byte[] buffer = reader.ReadBytes((int)stream.Length);
                    coll.Import(buffer, "1cer4ber", X509KeyStorageFlags.PersistKeySet);
                }
            }
            X509Certificate2 certificate = coll[0];

            ServiceManager.Instance.AddService(typeof(ITypeResolver), new TypeResolver());

            LocalConnectionManager connectionManager = new LocalConnectionManager(Properties.Settings.Default.CrmDbConnection);

            ServiceManager.Instance.AddService(typeof(IConnectionManager), connectionManager);

            ServiceManager.Instance.AddService(typeof(DykBits.Crm.Data.SqlProcedureManager), new DykBits.Crm.Data.SqlProcedureManager());
            ServiceManager.Instance.AddService(typeof(IDatabaseContext), new LocalDatabaseContext());
            ServiceManager.Instance.AddService(typeof(DocumentManager), DocumentManager.Create());
            ServiceManager.Instance.AddService(typeof(IDataQueryManager), DataQueryManager.Create());
            ServiceManager.Instance.AddService(typeof(ListManager), new ListManager());
            
            ViewDataManager.Register<MoneyOperationReportByOperationTypeDataAdapter>();
            ViewDataManager.Register<ConsolidatedBudgetLineDataAdapter>();
            ViewDataManager.Register<ConsolidatedOperatingBudgetLineDataAdapter>();
            ViewDataManager.Register<ConsolidatedAccrualLineDataAdapter>();
            ViewDataManager.Register<ConsolidatedMoneyOperationLineDataAdapter>();
            ViewDataManager.Register<PresentationNodeApplicationRoleDataAdapter>();
            ViewDataManager.Register<AdvanceItemDataAdapter>();
            ViewDataManager.Register<ConsolidatedInventoryOperationLineDataAdapter>();
            ViewDataManager.Register<BalanceSheetLineDataAdapter>();
            ViewDataManager.Register<InvoiceByContragentItemDataAdapter>();
            ViewDataManager.Register<InvoicePaymentByContragentItemDataAdapter>();
            ViewDataManager.Register<InvoiceByBudgetItemItemDataAdapter>();
            ViewDataManager.Register<CreditMoneyOperationDataAdapter>();

            ServiceHost dataServiceHost = CreateServiceHost(typeof(IDocumentService), typeof(DocumentService), Properties.Settings.Default.ServiceBaseAddess, certificate);
            ServiceHost blobServiceHost = CreateServiceHost(typeof(IBlobService), typeof(BlobService), Properties.Settings.Default.BlobServiceBaseAddress, certificate);

            dataServiceHost.Open();
            Console.WriteLine("DocumentService started successfully");
            foreach (var item in dataServiceHost.Description.Endpoints)
                Console.WriteLine("\t{0}", item.Address);
            blobServiceHost.Open();
            Console.WriteLine("BlobService started successfully");
            foreach (var item in blobServiceHost.Description.Endpoints)
                Console.WriteLine("\t{0}", item.Address);
            Console.Write("press any key to exit...");
            Console.ReadKey(true);
            Console.WriteLine();
            dataServiceHost.Close();
            blobServiceHost.Close();
        }

        static ServiceHost CreateServiceHost(Type contractType, Type serviceType, string serviceBaseAddress, X509Certificate2 certificate)
        {
            Uri baseUri = new Uri(serviceBaseAddress);
            ServiceHost host = new ServiceHost(serviceType, baseUri);
            host.Description.Behaviors.Remove<ServiceMetadataBehavior>();
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = false, HttpsGetEnabled = false });
            host.Description.Behaviors.Remove<ServiceDebugBehavior>();
            host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            ServiceCredentials credentials = new ServiceCredentials();
            credentials.UserNameAuthentication.CacheLogonTokens = true;
            host.Description.Behaviors.Add(credentials);

            host.AddServiceEndpoint(contractType, CreateBinding(false), new Uri(baseUri, "Basic"));
            host.AddServiceEndpoint(contractType, CreateBinding(true), new Uri(baseUri, "Windows"));
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            host.Credentials.ServiceCertificate.Certificate = certificate;
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Windows;
            return host;
        }

        static CustomBinding CreateBinding(bool integratedSecurity)
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.TransportWithMessageCredential, false);
            netTcpBinding.MaxReceivedMessageSize = 67108864;
            netTcpBinding.TransferMode = TransferMode.Streamed;
            if (integratedSecurity)
            {
                netTcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            }
            else
            {
                netTcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            }
            BindingElementCollection bec = netTcpBinding.CreateBindingElements();
            SslStreamSecurityBindingElement sbe = bec.Find<SslStreamSecurityBindingElement>();
            CustomBinding customBinding = new CustomBinding();
            foreach (BindingElement e in bec)
            {
                if (e is MessageEncodingBindingElement)
                    customBinding.Elements.Add(new GZipMessageEncodingBindingElement(new BinaryMessageEncodingBindingElement()));
                else
                    customBinding.Elements.Add(e);
            }
            return customBinding;
        }
    }
}
