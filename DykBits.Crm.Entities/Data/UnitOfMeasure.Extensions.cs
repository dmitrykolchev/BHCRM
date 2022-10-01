using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class UnitOfMeasure
    {
        private UnitOfMeasureClassView _uomClass;
        private UnitOfMeasureView _baseUnit;
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == UnitOfMeasureClassIdProperty)
            {
                this._uomClass = null;
                this._baseUnit = null;
                InvokePropertyChanged("UOMClass");
                InvokePropertyChanged("BaseUnit");
            }
        }

        [XmlIgnore]
        public UnitOfMeasureClassView UOMClass
        {
            get
            {
                if (this._uomClass == null)
                {
                    if (this.UnitOfMeasureClassId.HasValue)
                    {
                        this._uomClass = ListManager.GetItem<UnitOfMeasureClassView>(this.UnitOfMeasureClassId.Value);
                    }
                }
                return this._uomClass;
            }
        }
        [XmlIgnore]
        public UnitOfMeasureView BaseUnit
        {
            get
            {
                if (this._baseUnit == null)
                {
                    if (this.UOMClass != null && this.UOMClass.BaseUnitOfMeasureId.HasValue)
                    {
                        this._baseUnit = ListManager.GetItem<UnitOfMeasureView>(this.UOMClass.BaseUnitOfMeasureId.Value);
                    }
                }
                return this._baseUnit;
            }
        }
        public static bool IsConvertible(int uomId1, int uomId2)
        {
            var item1 = ListManager.GetItem<UnitOfMeasureView>(uomId1);
            var item2 = ListManager.GetItem<UnitOfMeasureView>(uomId2);
            var uomClass = item1.UnitOfMeasureClassId.GetValueOrDefault(1);
            return uomClass != 1 && uomClass == item2.UnitOfMeasureClassId;
        }
    }
}
