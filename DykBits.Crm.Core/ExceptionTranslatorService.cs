using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class ExceptionTranslatorService : IExceptionTranslatorService
    {
        private Dictionary<string, IErrorMessage> _messages = new Dictionary<string, IErrorMessage>();
        private Exception _lastException;
        public ExceptionInformation Translate(Exception exception)
        {
            ExceptionInformation exceptionInformation = new ExceptionInformation(exception);
            this._lastException = exception;
            if (exception is SqlException)
            {
                SqlException sqlException = (SqlException)exception;
                switch (sqlException.Number)
                {
                    case 547:
                        if (sqlException.Message.IndexOf("DELETE", StringComparison.InvariantCultureIgnoreCase) >= 0)
                            exceptionInformation.Message = "Произошла ошибка при удалении документа. Возможно документ связан с другими документами в базе данных.";
                        else if (sqlException.Message.IndexOf("INSERT", StringComparison.InvariantCultureIgnoreCase) >= 0)
                            exceptionInformation.Message = "Произошла ошибка при создании документа. Возможно не указано одно из обязательных полей.";
                        else if (sqlException.Message.IndexOf("UPDATE", StringComparison.InvariantCultureIgnoreCase) >= 0)
                            exceptionInformation.Message = "Произошла ошибка при сохранении документа. Возможно не указано одно из обязательных полей.";
                        else
                            exceptionInformation.Message = sqlException.Message;
                        break;
                    case 50000:
                    case 50489:
                        IErrorMessage message = GetMessage(sqlException.Message);
                        if(message != null)
                            exceptionInformation.Message = message.Message;
                        else
                            exceptionInformation.Message = sqlException.Message;
                        break;
                }
            }
            else if (exception is CrmApplicationException)
            {
                switch (exception.Message)
                {
                    case CrmApplicationException.EmployeeNotFoundMessage:
                        exceptionInformation.Description = "В карточке сотрудника необходимо указать учетную запись.";
                        exceptionInformation.Message = "Недостаточно прав для доступа в систему. Обратитесь к администратору.";
                        break;
                }
            }
            return exceptionInformation;
        }

        public void RefreshMessages()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy("ErrorMessage");
            this._messages.Clear();
            foreach (IErrorMessage message in dataAdapter.Browse(Filter.EmptyXml))
            {
                Add(message);
            }
        }

        private IErrorMessage GetMessage(string code)
        {
            IErrorMessage message;
            StringBuilder buffer = new StringBuilder();
            if (code[0] == '#')
            {
                buffer.Append('#');
                for (int index = 1; index < code.Length; ++index)
                {
                    if (Char.IsLetterOrDigit(code[index]))
                        buffer.Append(code[index]);
                    else
                        break;
                }
            }
            code = buffer.ToString();
            if (this._messages.TryGetValue(code, out message))
                return message;
            RefreshMessages();
            if (this._messages.TryGetValue(code, out message))
                return message;
            return null;
        }

        private void Add(IErrorMessage message)
        {
            this._messages.Add(message.Code, message);
        }

        public Exception LastException
        {
            get
            {
                return this._lastException;
            }
        }
    }
}
