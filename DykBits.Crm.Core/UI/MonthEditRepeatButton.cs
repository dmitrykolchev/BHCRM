using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DykBits.Crm.UI
{
    public class MonthEditRepeatButton: RepeatButton
    {
        static MonthEditRepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MonthEditRepeatButton), new FrameworkPropertyMetadata(typeof(MonthEditRepeatButton)));
        }
    }
}
