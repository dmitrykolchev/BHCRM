using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DykBits.Crm.Data
{
    public sealed class UserAccess: NotifyObject
    {
        private static readonly UserAccess instance = new UserAccess();
        public static UserAccess Instance
        {
            get { return instance; }
        }
        public Visibility CostVisibility
        {
            get { return Visibility.Visible; }
        }

        public Visibility PriceVisibility
        {
            get { return Visibility.Visible; }
        }

        public bool CostVisible
        {
            get { return CostVisibility == Visibility.Visible; }
        }

        public bool PriceVisible
        {
            get { return PriceVisibility == Visibility.Visible; }
        }
    }
}
