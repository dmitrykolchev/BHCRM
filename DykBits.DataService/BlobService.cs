using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace DykBits.DataService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, Namespace = ServiceParameters.ServiceNamespace)]
    public class BlobService : IBlobService
    {
        private static string GetIdentity()
        {
            if (ServiceSecurityContext.Current != null && ServiceSecurityContext.Current.PrimaryIdentity != null)
                return ServiceSecurityContext.Current.PrimaryIdentity.Name;
            return string.Empty;
        }

        private void EnterProc(object parameter = null, [CallerMemberName] string methodName = "")
        {
            Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: --->>> {2}, {3}, {4}",
                System.Threading.Thread.CurrentThread.ManagedThreadId,
                DateTime.Now,
                methodName,
                parameter,
                GetIdentity());
        }

        private void ExitProc(object parameter = null, [CallerMemberName] string methodName = "")
        {
            Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: <<<--- {2}, {3}, {4}",
                System.Threading.Thread.CurrentThread.ManagedThreadId,
                DateTime.Now,
                methodName,
                parameter,
                GetIdentity());
        }

        private void LogError(Exception ex, object parameter = null, [CallerMemberName] string methodName = "")
        {
            Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}: Error* {2}, {3}, {4}, {5}",
                System.Threading.Thread.CurrentThread.ManagedThreadId,
                DateTime.Now,
                methodName,
                parameter,
                GetIdentity(),
                ex.Message);
            Console.WriteLine("{0}", ex.ToString());
        }

        public string CreateMessageId()
        {
            EnterProc();
            try
            {
                Random rand = new Random();
                string path = string.Empty;
                for (int index = 0; index < 2; ++index)
                {
                    path = System.IO.Path.Combine(path, (rand.Next(64) + 1).ToString());
                }
                string fileName = string.Format("{0:N}", Guid.NewGuid());
                path = System.IO.Path.Combine(path, fileName);
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
            finally
            {
                ExitProc();
            }
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public void UploadBlob(UploadBlobRequest message)
        {
            EnterProc(message.MessageId);
            try
            {
                string path = GetPathFromMessageId(message.MessageId);
                string directory = System.IO.Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (FileStream stream = File.Create(path))
                {
                    message.Data.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, message.MessageId);
                throw;
            }
            finally
            {
                ExitProc(message.MessageId);
            }
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public DownloadBlobResponse DownloadBlob(DownloadBlobRequest message)
        {
            EnterProc(message.MessageId);
            try
            {
                DownloadBlobResponse response = new DownloadBlobResponse { MessageId = message.MessageId };
                string path = GetPathFromMessageId(message.MessageId);
                if (!File.Exists(path))
                    throw new ArgumentException("invalid path");
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                response.BlobLength = stream.Length;
                response.Data = stream;
                return response;
            }
            catch (Exception ex)
            {
                LogError(ex, message.MessageId);
                throw;
            }
            finally
            {
                ExitProc(message.MessageId);
            }
        }

        private string GetPathFromMessageId(string messageId)
        {
            string path = Encoding.UTF8.GetString(Convert.FromBase64String(messageId));
            return System.IO.Path.Combine(DykBits.DataService.Properties.Settings.Default.PathToStorage, path);
        }
    }
}
