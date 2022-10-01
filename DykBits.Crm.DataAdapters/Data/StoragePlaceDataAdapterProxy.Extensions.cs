using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class StoragePlaceDataAdapterProxy
    {
        protected override StoragePlace CreateItemOverride(object dataContext)
        {
            StoragePlace document = base.CreateItemOverride(dataContext);
            return document;
        }
    }
}
