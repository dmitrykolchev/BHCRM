using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Input
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandHandlerAttribute: Attribute
    {
        private string _commandText;
        public CommandHandlerAttribute(string commandText)
        {
            this._commandText = commandText;
        }

        public string CommandText
        {
            get { return this._commandText; }
        }
    }
}
