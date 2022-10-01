using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DykBits.Crm.UI
{
    public class MonthEditButton: Button
    {
        static MonthEditButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MonthEditButton), new FrameworkPropertyMetadata(typeof(MonthEditButton)));
        }
    }
}
