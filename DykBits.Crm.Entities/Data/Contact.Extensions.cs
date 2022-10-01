using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(MarketingProgramTypeSelector))]
    partial class Contact
    {
        private ObservableCollection<MarketingProgramTypeSelector> _marketingProgramTypes;
        public ObservableCollection<MarketingProgramTypeSelector> MarketingProgramTypes
        {
            get
            {
                if (this._marketingProgramTypes == null)
                {
                    this._marketingProgramTypes = new ObservableCollection<MarketingProgramTypeSelector>();
                    this._marketingProgramTypes.CollectionChanged += _marketingProgramTypes_CollectionChanged;
                }
                return this._marketingProgramTypes;
            }
        }
        void _marketingProgramTypes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (MarketingProgramTypeSelector item in e.NewItems)
                item.PropertyChanged += item_PropertyChanged;
            InvokePropertyChanged("MarketingProgramTypes");
        }
        void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokePropertyChanged("MarketingProgramTypes");
        }

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == AccountIdProperty)
            {
                if (this.AccountId == 0)
                    return "Необходимо выбрать организацию";
            }
            else if (propertyInfo.Name == FirstNameProperty || propertyInfo.Name == MiddleNameProperty || propertyInfo.Name == LastNameProperty)
            {
                if (string.IsNullOrEmpty(this.FirstName) && string.IsNullOrEmpty(this.MiddleName) && string.IsNullOrEmpty(this.LastName))
                    return "Необходимо ввести имя контакта";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
