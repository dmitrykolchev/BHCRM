using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public enum DataPresentationType
    {
        Root,
        Child
    }
    public interface IDataPresentation
    {
        DataPresentationType WindowType { get; }
        object DataContext { get; }
    }
}
