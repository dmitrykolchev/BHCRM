using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace DykBits.Crm.Data
{
    public static class DataHelper
    {
        private const string ServiceNamespace = "http://www.dykbits.net/2014/crm/documentservice";
        private static string GetHeaderValue(OperationContext context, string name, string ns)
        {
            int header = context.IncomingMessageHeaders.FindHeader(name, ns);
            if (header >= 0)
            {
                XmlReader r = context.IncomingMessageHeaders.GetReaderAtHeader(header);
                return r.ReadElementContentAsString();
            }
            return string.Empty;
        }
        public static SqlConnection CreateLocalConnection()
        {
            IConnectionManager connectionManager = ServiceManager.GetService<IConnectionManager>();
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionManager.ConnectionString);
            if (OperationContext.Current != null)
            {
                string applicationName = GetHeaderValue(OperationContext.Current, "ApplicationName", ServiceNamespace);
                if (!string.IsNullOrEmpty(applicationName))
                    connectionStringBuilder.ApplicationName = applicationName;

                string workstationId = GetHeaderValue(OperationContext.Current, "WorkstationId", ServiceNamespace);
                if (!string.IsNullOrEmpty(workstationId))
                    connectionStringBuilder.WorkstationID = workstationId;
            }
            return new SqlConnection(connectionStringBuilder.ConnectionString);
        }
        public static SqlCommand CreateProcedure(Type documentType, SqlProcedureType procedureType, SqlConnection connection)
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            return commandManager.GetProcedure(documentType, procedureType, connection);
        }
        public static SqlCommand CreateProcedure(string procedureName, SqlConnection connection)
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            return commandManager.GetProcedure(procedureName, connection);
        }
    }
}
