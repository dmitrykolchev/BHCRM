using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.Input
{
    [TypeConverter(typeof(UICommandConverter))]
    public class UICommand : RoutedCommand
    {
        private UICommandId _id;

        public UICommand()
        {
        }

        public UICommand(UICommandId id, Type ownerType)
            : this(id, ownerType, null)
        {
        }

        public UICommand(UICommandId id, Type ownerType, InputGestureCollection inputGestures)
            : base(id.ToString(), ownerType, inputGestures)
        {
            this._id = id;
        }

        public UICommandId Id
        {
            get { return this._id; }
        }

        public string Text { get; set; }
    }
}
