using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using DykBits.Crm;
using DykBits.Crm.Data;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace DykBits.DataService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DocumentService : IDocumentService
    {
        private static string GetIdentity()
        {
            if (ServiceSecurityContext.Current != null && ServiceSecurityContext.Current.PrimaryIdentity != null)
                return ServiceSecurityContext.Current.PrimaryIdentity.Name;
            return string.Empty;
        }

        private void EnterProc(object parameter = null, [CallerMemberName] string methodName = "")
        {
            var identity = GetIdentity();
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Task.Run(() =>
            {
                Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: --->>> {2}, {3}, {4}",
                    threadId,
                    DateTime.Now,
                    methodName,
                    parameter,
                    identity);
            });
        }

        private void ExitProc(object parameter = null, [CallerMemberName] string methodName = "")
        {
            var identity = GetIdentity();
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Task.Run(() =>
            {
                Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: <<<--- {2}, {3}, {4}",
                    threadId,
                    DateTime.Now,
                    methodName,
                    parameter,
                    identity);
            });
        }

        private void LogError(Exception ex, object parameter = null, [CallerMemberName] string methodName = "")
        {
            var identity = GetIdentity();
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Task.Run(() =>
            {
                Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: Error* {2}, {3}, {4}, {5}",
                    threadId,
                    DateTime.Now,
                    methodName,
                    parameter,
                    identity,
                    ex.Message);
                Console.WriteLine("{0}", ex.ToString());
            });
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream Browse(string viewType, XElement filter)
        {
            EnterProc(viewType);
            try
            {
                ViewDataManager viewDataManager = ServiceManager.GetService<ViewDataManager>();
                IViewDataAdapter adapter = viewDataManager.CreateDataAdapter(viewType);
                IList data = adapter.Browse(filter);
                MemoryStream stream = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartElement("BrowseResponse");
                foreach (IXmlSerializable item in data)
                {
                    item.WriteXml(writer);
                }
                writer.WriteEndElement();
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                LogError(ex, viewType);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc(viewType);
            }
        }
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream GetList(string viewType, XElement filter)
        {
            EnterProc(viewType);
            try
            {
                ViewDataManager viewDataManager = ServiceManager.GetService<ViewDataManager>();
                IViewDataAdapter adapter = viewDataManager.CreateDataAdapter(viewType);

                IList data = adapter.GetList(filter);
                MemoryStream stream = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartElement("GetListResponse");
                foreach (IXmlSerializable item in data)
                {
                    item.WriteXml(writer);
                }
                writer.WriteEndElement();
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                LogError(ex, viewType);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc(viewType);
            }
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream GetDocument(ItemKey key)
        {
            EnterProc(key);
            try
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter adapter = documentManager.CreateDataAdapter(key.DocumentType);
                IDataItem dataItem = adapter.GetItem(key);
                MemoryStream stream = new MemoryStream();
                using (XmlWriter writer = XmlWriter.Create(stream))
                {
                    ((IXmlSerializable)dataItem).WriteXml(writer);
                }
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                LogError(ex, key);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc(key);
            }
        }
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public void DeleteDocument(ItemKey key)
        {
            EnterProc(key);
            try
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter adapter = documentManager.CreateDataAdapter(key.DocumentType);
                adapter.Delete(key);
            }
            catch (Exception ex)
            {
                LogError(ex, key);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc(key);
            }
        }
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public void ChangeDocumentState(ItemKey key, byte newState, System.Xml.Linq.XElement applicationData)
        {
            EnterProc(key);
            try
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter adapter = documentManager.CreateDataAdapter(key.DocumentType);
                adapter.ChangeState(key, newState, applicationData);
            }
            catch (Exception ex)
            {
                LogError(ex, key);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc(key);
            }
        }
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream Save(Stream documentData)
        {
            EnterProc();
            try
            {
                XmlReader reader = XmlReader.Create(documentData);
                reader.MoveToContent();
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter adapter = documentManager.CreateDataAdapter(reader.LocalName);
                IDataItem dataItem = adapter.FromXml(reader);
                dataItem = adapter.Save(dataItem);
                MemoryStream stream = new MemoryStream();
                using (XmlWriter writer = XmlWriter.Create(stream))
                {
                    ((IXmlSerializable)dataItem).WriteXml(writer);
                }
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate)
        {
            EnterProc();
            try
            {
                LocalDatabaseContext db = new LocalDatabaseContext();
                return db.GetDocumentNumberInfo(className, organizationId, documentDate);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }

        public Stream GetDocumentMetadata()
        {
            EnterProc();
            try
            {
                LocalDatabaseContext db = new LocalDatabaseContext();
                return db.GetDocumentMetadata();
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream GetCurrentEmployee()
        {
            EnterProc();
            try
            {
                IDatabaseContext db = new LocalDatabaseContext();
                IEmployeeInfo employee = db.GetCurrentEmployee();
                MemoryStream stream = new MemoryStream();
                using (XmlWriter writer = XmlWriter.Create(stream))
                {
                    ((IXmlSerializable)employee).WriteXml(writer);
                }
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public int ExecuteNonQuery(Stream stream)
        {
            EnterProc();
            try
            {
                LocalDatabaseContext db = new LocalDatabaseContext();
                return db.ExecuteNonQuery(stream);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public Stream ExecuteQuery(Stream stream)
        {
            EnterProc();
            try
            {
                LocalDatabaseContext db = new LocalDatabaseContext();
                return db.ExecuteQuery(stream);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ExceptionUtils.CreateFault(ex);
            }
            finally
            {
                ExitProc();
            }
        }
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public string Ping(string message)
        {
            EnterProc();
            try
            {
                return message;
            }
            finally
            {
                ExitProc();
            }
        }
    }
}
