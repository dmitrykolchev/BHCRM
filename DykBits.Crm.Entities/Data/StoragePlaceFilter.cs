﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class StoragePlaceFilter
    {
        public int? AccountId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)StoragePlaceState.Active };
            if (dataContext is Organization)
                this.AccountId = ((Organization)dataContext).Id;
        }
    }
}