using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class PresentationNodeType: DataItemView
    {
        public const int Folder = 1;
        public const int PresentationSet = 2;
        public const int Presentation = 3;
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public override bool CanDelete
        {
            get
            {
                return false;
            }
        }
        public override bool CanChangeStateTo(byte newState)
        {
            return false;
        }
        public override string DataItemClass
        {
            get { return "PresentationNodeType"; }
        }
    }
}
