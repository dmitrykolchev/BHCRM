//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DykBits.Crm.Data
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class UserDataAdapter : XmlDataAdapterBase<UserView, User, UserFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1FirstName;
        private int _ordinal1MiddleName;
        private int _ordinal1LastName;
        private int _ordinal1WindowsIdentity;
        private int _ordinal1SqlIdentity;
        private int _ordinal1UserName;
        private int _ordinal1PasswordHash;
        private int _ordinal1Comments;
        private int _ordinal1Created;
        private int _ordinal1CreatedBy;
        private int _ordinal1Modified;
        private int _ordinal1ModifiedBy;
        private int _ordinal1RowVersion;
        private void InitializeBindBrowseResultToItem(SqlDataReader reader)
        {
            if (this._initialized1) return;
            this._ordinal1Id = reader.GetOrdinal("Id");
            this._ordinal1State = reader.GetOrdinal("State");
            this._ordinal1FileAs = reader.GetOrdinal("FileAs");
            this._ordinal1FirstName = reader.GetOrdinal("FirstName");
            this._ordinal1MiddleName = reader.GetOrdinal("MiddleName");
            this._ordinal1LastName = reader.GetOrdinal("LastName");
            this._ordinal1WindowsIdentity = reader.GetOrdinal("WindowsIdentity");
            this._ordinal1SqlIdentity = reader.GetOrdinal("SqlIdentity");
            this._ordinal1UserName = reader.GetOrdinal("UserName");
            this._ordinal1PasswordHash = reader.GetOrdinal("PasswordHash");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(UserView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (UserState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            if(reader.IsDBNull(_ordinal1FirstName)) item.FirstName = null; else item.FirstName = reader.GetString(this._ordinal1FirstName);
            if(reader.IsDBNull(_ordinal1MiddleName)) item.MiddleName = null; else item.MiddleName = reader.GetString(this._ordinal1MiddleName);
            if(reader.IsDBNull(_ordinal1LastName)) item.LastName = null; else item.LastName = reader.GetString(this._ordinal1LastName);
            if(reader.IsDBNull(_ordinal1WindowsIdentity)) item.WindowsIdentity = null; else item.WindowsIdentity = reader.GetString(this._ordinal1WindowsIdentity);
            if(reader.IsDBNull(_ordinal1SqlIdentity)) item.SqlIdentity = null; else item.SqlIdentity = reader.GetString(this._ordinal1SqlIdentity);
            if(reader.IsDBNull(_ordinal1UserName)) item.UserName = null; else item.UserName = reader.GetString(this._ordinal1UserName);
            if(reader.IsDBNull(_ordinal1PasswordHash)) item.PasswordHash = null; else item.PasswordHash = reader.GetSqlBinary(this._ordinal1PasswordHash).Value;
            if(reader.IsDBNull(_ordinal1Comments)) item.Comments = null; else item.Comments = reader.GetString(this._ordinal1Comments);
            item.Created = reader.GetDateTime(this._ordinal1Created);
            item.CreatedBy = reader.GetInt32(this._ordinal1CreatedBy);
            item.Modified = reader.GetDateTime(this._ordinal1Modified);
            item.ModifiedBy = reader.GetInt32(this._ordinal1ModifiedBy);
            item.RowVersion = reader.GetSqlBinary(this._ordinal1RowVersion).Value;
        }
        private bool _initialized2;
        private int _ordinal2Id;
        private int _ordinal2State;
        private int _ordinal2FileAs;
        private int _ordinal2FirstName;
        private int _ordinal2MiddleName;
        private int _ordinal2LastName;
        private int _ordinal2WindowsIdentity;
        private int _ordinal2SqlIdentity;
        private int _ordinal2UserName;
        private int _ordinal2PasswordHash;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2FirstName = reader.GetOrdinal("FirstName");
            this._ordinal2MiddleName = reader.GetOrdinal("MiddleName");
            this._ordinal2LastName = reader.GetOrdinal("LastName");
            this._ordinal2WindowsIdentity = reader.GetOrdinal("WindowsIdentity");
            this._ordinal2SqlIdentity = reader.GetOrdinal("SqlIdentity");
            this._ordinal2UserName = reader.GetOrdinal("UserName");
            this._ordinal2PasswordHash = reader.GetOrdinal("PasswordHash");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(UserView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (UserState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            if(reader.IsDBNull(_ordinal2FirstName)) item.FirstName = null; else item.FirstName = reader.GetString(this._ordinal2FirstName);
            if(reader.IsDBNull(_ordinal2MiddleName)) item.MiddleName = null; else item.MiddleName = reader.GetString(this._ordinal2MiddleName);
            if(reader.IsDBNull(_ordinal2LastName)) item.LastName = null; else item.LastName = reader.GetString(this._ordinal2LastName);
            if(reader.IsDBNull(_ordinal2WindowsIdentity)) item.WindowsIdentity = null; else item.WindowsIdentity = reader.GetString(this._ordinal2WindowsIdentity);
            if(reader.IsDBNull(_ordinal2SqlIdentity)) item.SqlIdentity = null; else item.SqlIdentity = reader.GetString(this._ordinal2SqlIdentity);
            if(reader.IsDBNull(_ordinal2UserName)) item.UserName = null; else item.UserName = reader.GetString(this._ordinal2UserName);
            if(reader.IsDBNull(_ordinal2PasswordHash)) item.PasswordHash = null; else item.PasswordHash = reader.GetSqlBinary(this._ordinal2PasswordHash).Value;
        }
    }
}
