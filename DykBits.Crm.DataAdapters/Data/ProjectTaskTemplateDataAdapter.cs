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
    
    public partial class ProjectTaskTemplateDataAdapter : XmlDataAdapterBase<ProjectTaskTemplateView, ProjectTaskTemplate, ProjectTaskTemplateFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1TaskNo;
        private int _ordinal1FileAs;
        private int _ordinal1ProjectTemplateId;
        private int _ordinal1ProjectMemberRoleId;
        private int _ordinal1IsMilestone;
        private int _ordinal1TaskStartOffset;
        private int _ordinal1TaskDuration;
        private int _ordinal1Importance;
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
            this._ordinal1TaskNo = reader.GetOrdinal("TaskNo");
            this._ordinal1FileAs = reader.GetOrdinal("FileAs");
            this._ordinal1ProjectTemplateId = reader.GetOrdinal("ProjectTemplateId");
            this._ordinal1ProjectMemberRoleId = reader.GetOrdinal("ProjectMemberRoleId");
            this._ordinal1IsMilestone = reader.GetOrdinal("IsMilestone");
            this._ordinal1TaskStartOffset = reader.GetOrdinal("TaskStartOffset");
            this._ordinal1TaskDuration = reader.GetOrdinal("TaskDuration");
            this._ordinal1Importance = reader.GetOrdinal("Importance");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(ProjectTaskTemplateView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (ProjectTaskTemplateState)reader.GetByte(this._ordinal1State);
            item.TaskNo = reader.GetInt32(this._ordinal1TaskNo);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.ProjectTemplateId = reader.GetInt32(this._ordinal1ProjectTemplateId);
            item.ProjectMemberRoleId = reader.GetInt32(this._ordinal1ProjectMemberRoleId);
            item.IsMilestone = reader.GetBoolean(this._ordinal1IsMilestone);
            item.TaskStartOffset = reader.GetInt32(this._ordinal1TaskStartOffset);
            item.TaskDuration = reader.GetInt32(this._ordinal1TaskDuration);
            item.Importance = reader.GetInt32(this._ordinal1Importance);
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
        private int _ordinal2TaskNo;
        private int _ordinal2FileAs;
        private int _ordinal2ProjectTemplateId;
        private int _ordinal2ProjectMemberRoleId;
        private int _ordinal2IsMilestone;
        private int _ordinal2TaskStartOffset;
        private int _ordinal2TaskDuration;
        private int _ordinal2Importance;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2TaskNo = reader.GetOrdinal("TaskNo");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2ProjectTemplateId = reader.GetOrdinal("ProjectTemplateId");
            this._ordinal2ProjectMemberRoleId = reader.GetOrdinal("ProjectMemberRoleId");
            this._ordinal2IsMilestone = reader.GetOrdinal("IsMilestone");
            this._ordinal2TaskStartOffset = reader.GetOrdinal("TaskStartOffset");
            this._ordinal2TaskDuration = reader.GetOrdinal("TaskDuration");
            this._ordinal2Importance = reader.GetOrdinal("Importance");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(ProjectTaskTemplateView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (ProjectTaskTemplateState)reader.GetByte(this._ordinal2State);
            item.TaskNo = reader.GetInt32(this._ordinal2TaskNo);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.ProjectTemplateId = reader.GetInt32(this._ordinal2ProjectTemplateId);
            item.ProjectMemberRoleId = reader.GetInt32(this._ordinal2ProjectMemberRoleId);
            item.IsMilestone = reader.GetBoolean(this._ordinal2IsMilestone);
            item.TaskStartOffset = reader.GetInt32(this._ordinal2TaskStartOffset);
            item.TaskDuration = reader.GetInt32(this._ordinal2TaskDuration);
            item.Importance = reader.GetInt32(this._ordinal2Importance);
        }
    }
}
