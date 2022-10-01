using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Globalization;

namespace DykBits.Crm.Data
{
    public class RemoteConnectionStringBuilder : DbConnectionStringBuilder
    {
        private const string ApplicationNameProperty = "Application Name";
        private const string WorkstationIDProperty = "Workstation ID";
        private const string UserIDProperty = "User ID";
        private const string PasswordProperty = "Password";
        private const string DataSourceProperty = "Data Source";
        private const string CurrentLanguageProperty = "Current Language";
        private const string IntegratedSecurityProperty = "Integrated Security";
        private enum Keywords
        {
            ApplicationName,
            WorkstationID,
            UserID,
            Password,
            DataSource,
            CurrentLanguage,
            IntegratedSecurity
        }
        private static readonly string[] _validKeywords = new string[] { 
            ApplicationNameProperty, 
            WorkstationIDProperty, 
            UserIDProperty, 
            PasswordProperty, 
            DataSourceProperty, 
            CurrentLanguageProperty, 
            IntegratedSecurityProperty
        };
        private static readonly Dictionary<string, Keywords> _keywords = new Dictionary<string, Keywords>(32, StringComparer.OrdinalIgnoreCase) {
                                                                             { ApplicationNameProperty, Keywords.ApplicationName},
                                                                             { WorkstationIDProperty, Keywords.WorkstationID},
                                                                             { UserIDProperty, Keywords.UserID},
                                                                             { PasswordProperty, Keywords.Password},
                                                                             { DataSourceProperty, Keywords.DataSource},
                                                                             { CurrentLanguageProperty, Keywords.CurrentLanguage},
                                                                             { IntegratedSecurityProperty, Keywords.IntegratedSecurity}
                                                                         };
        private string _applicationName;
        private string _workstationId;
        private string _userId;
        private string _password;
        private string _dataSource;
        private string _currentLanguage;
        private bool _integratedSecurity;
        static RemoteConnectionStringBuilder()
        {
        }
        public RemoteConnectionStringBuilder()
            : this(null)
        {
        }
        public RemoteConnectionStringBuilder(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
                base.ConnectionString = connectionString;
        }
        public override ICollection Keys
        {
            get
            {
                return new ReadOnlyCollection<string>(_validKeywords);
            }
        }
        public override ICollection Values
        {
            get
            {
                object[] array = new object[_validKeywords.Length];
                for (int index = 0; index < array.Length; index++)
                {
                    array[index] = this.GetAt((Keywords)index);
                }
                return new ReadOnlyCollection<object>(array);
            }
        }
        private Keywords GetIndex(string keyword)
        {
            Keywords result;
            if (_keywords.TryGetValue(keyword, out result))
            {
                return result;
            }
            throw new ArgumentOutOfRangeException();
        }
        public override object this[string keyword]
        {
            get
            {
                Keywords index = this.GetIndex(keyword);
                return this.GetAt(index);
            }
            set
            {
                if (value == null)
                {
                    Remove(keyword);
                }
                else
                {
                    switch (GetIndex(keyword))
                    {
                        case Keywords.ApplicationName:
                            this.ApplicationName = (string)value;
                            break;
                        case Keywords.CurrentLanguage:
                            this.CurrentLanguage = (string)value;
                            break;
                        case Keywords.DataSource:
                            this.DataSource = (string)value;
                            break;
                        case Keywords.IntegratedSecurity:
                            this.IntegratedSecurity = ConvertToBoolean(value);
                            break;
                        case Keywords.Password:
                            this.Password = (string)value;
                            break;
                        case Keywords.UserID:
                            this.UserID = (string)value;
                            break;
                        case Keywords.WorkstationID:
                            this.WorkstationID = (string)value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }
        public override void Clear()
        {
            base.Clear();
            for (int index = 0; index < _validKeywords.Length; ++index)
                Reset((Keywords)index);
        }
        public override bool ContainsKey(string keyword)
        {
            return _keywords.ContainsKey(keyword);
        }
        private object GetAt(Keywords index)
        {
            switch (index)
            {
                case Keywords.ApplicationName:
                    return this.ApplicationName;
                case Keywords.CurrentLanguage:
                    return this.CurrentLanguage;
                case Keywords.DataSource:
                    return this.DataSource;
                case Keywords.IntegratedSecurity:
                    return this.IntegratedSecurity;
                case Keywords.Password:
                    return this.Password;
                case Keywords.UserID:
                    return this.UserID;
                case Keywords.WorkstationID:
                    return this.WorkstationID;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void Reset(Keywords index)
        {
            switch (index)
            {
                case Keywords.ApplicationName:
                    this._applicationName = string.Empty;
                    break;
                case Keywords.CurrentLanguage:
                    this._currentLanguage = string.Empty;
                    break;
                case Keywords.DataSource:
                    this._dataSource = string.Empty;
                    break;
                case Keywords.IntegratedSecurity:
                    this._integratedSecurity = false;
                    break;
                case Keywords.Password:
                    this._password = string.Empty;
                    break;
                case Keywords.UserID:
                    this._userId = string.Empty;
                    break;
                case Keywords.WorkstationID:
                    this._workstationId = string.Empty;
                    break;
            }
        }
        public override bool Remove(string keyword)
        {
            Keywords index;
            if (_keywords.TryGetValue(keyword, out index) && base.Remove(_validKeywords[(int)index]))
            {
                this.Reset(index);
                return true;
            }
            return false;
        }

        [DisplayName(ApplicationNameProperty)]
        public string ApplicationName
        {
            get { return this._applicationName; }
            set
            {
                SetValue(ApplicationNameProperty, value);
                this._applicationName = value;
            }
        }
        [DisplayName(WorkstationIDProperty)]
        public string WorkstationID
        {
            get { return this._workstationId; }
            set
            {
                SetValue(WorkstationIDProperty, value);
                this._workstationId = value;
            }
        }
        [DisplayName(UserIDProperty)]
        public string UserID
        {
            get { return this._userId; }
            set
            {
                SetValue(UserIDProperty, value);
                this._userId = value;
            }
        }
        [DisplayName(PasswordProperty)]
        public string Password
        {
            get { return this._password; }
            set
            {
                SetValue(PasswordProperty, value);
                this._password = value;
            }
        }
        [DisplayName(DataSourceProperty)]
        public string DataSource
        {
            get { return this._dataSource; }
            set
            {
                SetValue(DataSourceProperty, value);
                this._dataSource = value;
            }
        }
        [DisplayName(CurrentLanguageProperty)]
        public string CurrentLanguage
        {
            get { return this._currentLanguage; }
            set
            {
                SetValue(CurrentLanguageProperty, value);
                this._currentLanguage = value;
            }
        }
        [DisplayName(IntegratedSecurityProperty)]
        public bool IntegratedSecurity
        {
            get { return this._integratedSecurity; }
            set
            {
                SetValue(IntegratedSecurityProperty, value);
                this._integratedSecurity = value;
            }
        }
        private void SetValue(string propertyName, string value)
        {
            base[propertyName] = value;
        }
        private void SetValue(string propertyName, bool value)
        {
            base[propertyName] = value.ToString(null);
        }
        internal static bool ConvertToBoolean(object value)
        {
            string text = value as string;
            if (text == null)
            {
                return ((IConvertible)value).ToBoolean(CultureInfo.InvariantCulture);
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(text, "true") || StringComparer.OrdinalIgnoreCase.Equals(text, "yes"))
            {
                return true;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(text, "false") || StringComparer.OrdinalIgnoreCase.Equals(text, "no"))
            {
                return false;
            }
            string x = text.Trim();
            return StringComparer.OrdinalIgnoreCase.Equals(x, "true") || StringComparer.OrdinalIgnoreCase.Equals(x, "yes") || (!StringComparer.OrdinalIgnoreCase.Equals(x, "false") && !StringComparer.OrdinalIgnoreCase.Equals(x, "no") && bool.Parse(text));
        }
    }
}
