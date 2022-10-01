using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class TableDefinition
    {
        private List<ProcedureDefinition> _procedures;

        public TableDefinition()
        {
            Columns = new List<ColumnDefinition>();
        }
        
        public string SchemaName { get; set; }
        public string TableName { get; set; }

        public virtual ICollection<ColumnDefinition> Columns { get; set; }

        public IList<ProcedureDefinition> Procedures
        {
            get
            {
                if(this._procedures == null)
                {
                    this._procedures = new List<ProcedureDefinition>();
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.Browse));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.List));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.Get));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.Create));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.CreateInternal));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.Update));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.UpdateInternal));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.Delete));
                    this._procedures.Add(ProcedureDefinition.CreateProcedure(this, ProcedureType.ChangeState));
                }
                return this._procedures;
            }
        }
    }
}
