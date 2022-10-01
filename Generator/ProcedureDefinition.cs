using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public enum ProcedureType
    {
        Browse,
        List,
        Get,
        Create,
        CreateInternal,
        Update,
        UpdateInternal,
        Delete,
        ChangeState
    }

    public abstract class ProcedureDefinition
    {
        private string _script;

        protected ProcedureDefinition()
        {
        }

        public static ProcedureDefinition CreateProcedure(TableDefinition table, ProcedureType procedureType)
        {
            ProcedureDefinition procedure;
            switch (procedureType)
            {
                case ProcedureType.Browse:
                    procedure = new BrowseProcedureDefinition();
                    break;
                case ProcedureType.List:
                    procedure = new ListProcedureDefinition();
                    break;
                case ProcedureType.Get:
                    procedure = new GetItemProcedureDefinition();
                    break;
                case ProcedureType.Create:
                    procedure = new CreateProcedureDefinition();
                    break;
                case ProcedureType.CreateInternal:
                    procedure = new CreateInternalProcedureDefinition();
                    break;
                case ProcedureType.Update:
                    procedure = new UpdateProcedureDefinition();
                    break;
                case ProcedureType.UpdateInternal:
                    procedure = new UpdateInternalProcedureDefinition();
                    break;
                case ProcedureType.Delete:
                    procedure = new DeleteProcedureDefinition();
                    break;
                case ProcedureType.ChangeState:
                    procedure = new ChangeStateProcedureDefinition();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("procedureType");
            }
            procedure.Table = table;
            return procedure;
        }

        public string GetFileName()
        {
            return Table.TableName + ProcedureType.ToString() + ".sql";
        }

        public TableDefinition Table { get; private set; }

        public abstract ProcedureType ProcedureType { get; }

        public string Script
        {
            get
            {
                if (this._script == null)
                {
                    this._script = GenerateScript();
                }
                return this._script;
            }
        }

        internal static string GetParameter(ColumnDefinition column, bool showType)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@");
            builder.Append(column.ColumnName);
            if (showType)
            {
                builder.Append(" ");
                if (string.IsNullOrEmpty(column.DomainName))
                {
                    if (string.Compare(column.DataType, "timestamp", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        builder.Append("binary(8)");
                    }
                    else
                    {
                        builder.Append(column.DataType);
                        if (string.Compare(column.DataType, "decimal", StringComparison.InvariantCultureIgnoreCase) == 0)
                        {
                            builder.AppendFormat("({0},{1})", column.NumericPrecision, column.NumericScale);
                        }
                        else if (column.MaximumLength.HasValue)
                        {
                            if (column.MaximumLength == -1)
                                builder.Append("(max)");
                            else
                                builder.AppendFormat("({0})", column.MaximumLength.Value);
                        }
                    }
                }
                else
                {
                    builder.Append(column.DomainName);
                }
            }
            return builder.ToString();
        }

        internal static string GetValueAssignment(ColumnDefinition column)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("@{0} = T.c.value('@{0}', '", column.ColumnName);
            if (string.IsNullOrEmpty(column.DomainName))
            {
                if (string.Compare(column.DataType, "timestamp", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    builder.Append("binary(8)");
                }
                else
                {
                    builder.Append(column.DataType);
                    if (string.Compare(column.DataType, "decimal", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        builder.AppendFormat("({0},{1})", column.NumericPrecision, column.NumericScale);
                    }
                    else if (column.MaximumLength.HasValue)
                    {
                        if (column.MaximumLength == -1)
                            builder.Append("(max)");
                        else
                            builder.AppendFormat("({0})", column.MaximumLength.Value);
                    }
                }
            }
            else
            {
                builder.Append(column.DomainName);
            }
            builder.Append("')");
            return builder.ToString();
        }


        internal static readonly string[] AuditFileds = new string[] { "Created", "CreatedBy", "Modified", "ModifiedBy" };
        internal static readonly string RowVersionField = "RowVersion";
        internal static readonly string[] ListIgnoreFileds = new string[] { "Comments", "Created", "CreatedBy", "Modified", "ModifiedBy", "RowVersion" };


        protected abstract string GenerateScript();
    }

    class ListProcedureDefinition : ProcedureDefinition
    {
        public ListProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.List; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @filter xml\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();

            builder.AppendLine("\tdeclare @AllStates bit, @Id TIdentifier;");
            builder.AppendLine();
            builder.AppendLine("\tselect");
            builder.AppendLine("\t\t@AllStates = T.c.value('AllStates[1]', 'bit'),");
            builder.AppendLine("\t\t@Id = T.c.value('Id[1]', 'TIdentifier')");
            builder.AppendLine("\tfrom");
            builder.AppendLine("\t\t@filter.nodes('/Filter') as T(c);");
            builder.AppendLine();

            builder.AppendLine("\tselect");
            string columns = string.Join(",\r\n\t\t", Table.Columns.Where(t => !ListIgnoreFileds.Contains(t.ColumnName)).OrderBy(t => t.OrdinalPosition).Select(t => "[" + t.ColumnName + "]").ToArray());
            builder.AppendFormat("\t\t{0}\r\n", columns);
            builder.AppendLine("\tfrom");
            builder.AppendFormat("\t\t[{0}].[{1}]\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\twhere");
            builder.AppendLine("\t\t(@Id is null or [Id] = @Id)");
            builder.AppendLine("\t\tand");
            builder.AppendLine("\t\t(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));");

            builder.AppendLine();
            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    class BrowseProcedureDefinition : ProcedureDefinition
    {
        public BrowseProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.Browse; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @filter xml\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();

            builder.AppendLine("\tdeclare @AllStates bit, @Id TIdentifier, @Presentation varchar(256);");
            builder.AppendLine();
            builder.AppendLine("\tselect");
            builder.AppendLine("\t\t@AllStates = T.c.value('AllStates[1]', 'bit'),");
            builder.AppendLine("\t\t@Id = T.c.value('Id[1]', 'TIdentifier'),");
            builder.AppendLine("\t\t@Presentation = T.c.value('Presentation[1]', 'varchar(256)')");
            builder.AppendLine("\tfrom");
            builder.AppendLine("\t\t@filter.nodes('/Filter') as T(c);");
            builder.AppendLine();

            builder.AppendLine("\tselect");
            string columns = string.Join(",\r\n\t\t", Table.Columns.OrderBy(t => t.OrdinalPosition).Select(t => "[" + t.ColumnName + "]").ToArray());
            builder.AppendFormat("\t\t{0}\r\n", columns);
            builder.AppendLine("\tfrom");
            builder.AppendFormat("\t\t[{0}].[{1}]\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\twhere");
            builder.AppendLine("\t\t(@Id is null or [Id] = @Id)");
            builder.AppendLine("\t\tand");
            builder.AppendLine("\t\t(@AllStates = 1 or [State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)));");

            builder.AppendLine();
            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    class GetItemProcedureDefinition : ProcedureDefinition
    {
        public GetItemProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.Get; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @Id TIdentifier\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();
            builder.AppendLine("\tdeclare @DocumentTypeId int;");
            builder.AppendLine();
            builder.AppendFormat("\tselect @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = '{0}';\r\n", Table.TableName);
            builder.AppendLine();

            builder.AppendLine("\tselect");

            string columns = string.Join(",\r\n\t\t", Table.Columns.OrderBy(t => t.OrdinalPosition).Select(t => "[" + t.ColumnName + "]").ToArray());
            builder.AppendFormat("\t\t{0},\r\n", columns);
            builder.AppendLine("\t\t(select");
            builder.AppendLine("\t\t\t[Id], [BlobId], [BlobName] as [Name]");
            builder.AppendLine("\t\tfrom");
            builder.AppendLine("\t\t\t[DocumentAttachment] as [AttachmentItem]");
            builder.AppendLine("\t\twhere");
            builder.AppendLine("\t\t\t[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]");

            builder.AppendLine("\tfrom");
            builder.AppendFormat("\t\t[{0}].[{1}] as [{1}]\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\twhere");
            builder.AppendLine("\t\t[Id] = @Id");
            builder.AppendLine("\t\tfor xml auto, binary base64;");
            builder.AppendLine();
            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    abstract class SaveProcedureDefinition : ProcedureDefinition
    {
        protected SaveProcedureDefinition()
        {
        }
    }

    class CreateProcedureDefinition : SaveProcedureDefinition
    {
        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.Create; }
        }

        protected override string GenerateScript()
        {
            string template = @"CREATE PROCEDURE [dbo].[{0}{1}] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[{0}{1}Internal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[{0}Get] @Id;

	return 0;
end
";
            return string.Format(template, this.Table.TableName, ProcedureType.ToString());
        }
    }

    class CreateInternalProcedureDefinition : SaveProcedureDefinition
    {
        public CreateInternalProcedureDefinition()
        {

        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.CreateInternal; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @xml xml, @Id TIdentifier out\r\n", Table.SchemaName, Table.TableName, ProcedureType);

            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();

            var parameterList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, RowVersionField, StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => GetParameter(t, true));

            string parameters = string.Join(",\r\n\t\t\t", parameterList.ToArray());
            builder.AppendFormat("\tdeclare\t{0};\r\n", parameters);

            var assignmentList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, RowVersionField, StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => GetValueAssignment(t));

            string assignments = string.Join(",\r\n\t\t", assignmentList.ToArray());

            builder.AppendFormat("\tselect\r\n\t\t{0}\r\n\tfrom\r\n\t\t@xml.nodes('{1}') as T(c);\r\n", assignments, Table.TableName);

            builder.AppendLine();

            builder.AppendLine("\tif @@error <> 0");
            builder.AppendLine("\t\treturn 1;");

            builder.AppendLine();

            builder.AppendLine("\tdeclare @CurrentUserId int;");
            builder.AppendLine();
            builder.AppendLine("\tset @CurrentUserId = [dbo].[GetCurrentUserId]();");
            builder.AppendLine();

            var columnList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, RowVersionField, StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => "[" + t.ColumnName + "]");

            builder.AppendFormat("\tinsert into [{0}].[{1}]\r\n", Table.SchemaName, Table.TableName);
            string text = string.Format("[State], {0}, [Created], [CreatedBy], [Modified], [ModifiedBy]", string.Join(", ", columnList.ToArray()));
            text = text.WordWrap(100, "\t\t");
            builder.AppendFormat("\t\t({0})\r\n", text);
            builder.AppendFormat("\tvalues\r\n");

            parameterList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, RowVersionField, StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => GetParameter(t, false));

            text = string.Format("1, {0}, getdate(), @CurrentUserId, getdate(), @CurrentUserId", string.Join(", ", parameterList.ToArray()));
            text = text.WordWrap(100, "\t\t");

            builder.AppendFormat("\t\t({0});\r\n", text);

            builder.AppendLine();

            builder.AppendLine("\tif @@error <> 0");
            builder.AppendLine("\t\treturn 1;");

            builder.AppendLine("\tset @Id = scope_identity();");

            builder.AppendLine();

            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    class UpdateProcedureDefinition : SaveProcedureDefinition
    {
        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.Update; }
        }

        protected override string GenerateScript()
        {
            string template = @"CREATE PROCEDURE [dbo].[{0}{1}] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[{0}{1}Internal] @xml, @Id out;

	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	exec [dbo].[{0}Get] @Id;

	return 0;
end
";
            return string.Format(template, this.Table.TableName, ProcedureType.ToString());
        }
    }

    class UpdateInternalProcedureDefinition : SaveProcedureDefinition
    {
        public UpdateInternalProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.UpdateInternal; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @xml xml, @Id TIdentifier out\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();
            var parameterList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => GetParameter(t, true));

            string parameters = string.Join(",\r\n\t\t\t", parameterList.ToArray());
            builder.AppendFormat("\tdeclare\t{0};\r\n", parameters);

            var assignmentList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => GetValueAssignment(t));

            string assignments = string.Join(",\r\n\t\t", assignmentList.ToArray());

            builder.AppendFormat("\tselect\r\n\t\t{0}\r\n\tfrom\r\n\t\t@xml.nodes('{1}') as T(c);\r\n", assignments, Table.TableName);

            builder.AppendLine("\tif @@error <> 0");
            builder.AppendLine("\t\treturn 1;");

            builder.AppendLine();

            builder.AppendLine("\tdeclare @CurrentUserId int;");
            builder.AppendLine();
            builder.AppendLine("\tset @CurrentUserId = [dbo].[GetCurrentUserId]();");
            builder.AppendLine();

            var columnList = Table.Columns
                .Where(t => string.Compare(t.ColumnName, RowVersionField, StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "Id", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => string.Compare(t.ColumnName, "State", StringComparison.InvariantCultureIgnoreCase) != 0)
                .Where(t => !AuditFileds.Contains(t.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(t => t.OrdinalPosition)
                .Select(t => "[" + t.ColumnName + "] = @" + t.ColumnName);

            builder.AppendFormat("\tupdate [{0}].[{1}]\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\tset");
            builder.AppendFormat("\t\t{0},\r\n", string.Join(",\r\n\t\t", columnList.ToArray()));
            builder.AppendLine("\t\t[Modified] = getdate(),");
            builder.AppendLine("\t\t[ModifiedBy] = @CurrentUserId");
            builder.AppendLine("\twhere");
            builder.AppendLine("\t\t[Id] = @Id;");

            builder.AppendLine();

            builder.AppendLine("\tif @@error <> 0");
            builder.AppendLine("\t\treturn 1;");

            builder.AppendLine();

            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    class DeleteProcedureDefinition : ProcedureDefinition
    {
        public DeleteProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.Delete; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @Id TIdentifier\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();
            builder.AppendLine("\tbegin transaction;");
            builder.AppendLine();
            builder.AppendFormat("\tdelete [{0}].[{1}] where [Id] = @Id;\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\tif @@error <> 0");
            builder.AppendLine("\tbegin");
            builder.AppendLine("\t\trollback transaction;");
            builder.AppendLine("\t\treturn 1;");
            builder.AppendLine("\tend");
            builder.AppendLine();
            builder.AppendLine("\tcommit transaction");
            builder.AppendLine();
            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }

    class ChangeStateProcedureDefinition : ProcedureDefinition
    {
        public ChangeStateProcedureDefinition()
        {
        }

        public override ProcedureType ProcedureType
        {
            get { return ProcedureType.ChangeState; }
        }

        protected override string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("create procedure [{0}].[{1}{2}] @Id TIdentifier, @NewState TState\r\n", Table.SchemaName, Table.TableName, ProcedureType);
            builder.AppendLine("as");
            builder.AppendLine("begin");
            builder.AppendLine("\tset nocount on;");
            builder.AppendLine();
            builder.AppendLine("\tdeclare @UserId int;");
            builder.AppendLine();
            builder.AppendLine("\tset @UserId = [dbo].[GetCurrentUserId]();");
            builder.AppendLine();
            builder.AppendFormat("\tupdate [{0}].[{1}]\r\n", Table.SchemaName, Table.TableName);
            builder.AppendLine("\tset");
            builder.AppendLine("\t\t[State] = @NewState,");
            builder.AppendLine("\t\t[Modified] = getdate(),");
            builder.AppendLine("\t\t[ModifiedBy] = @UserId");
            builder.AppendLine("\twhere");
            builder.AppendLine("\t\t[Id] = @Id;");
            builder.AppendLine();
            builder.AppendLine();
            builder.AppendLine("\treturn 0;");
            builder.AppendLine("end");

            return builder.ToString();
        }
    }
}
