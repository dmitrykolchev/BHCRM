using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class BudgetItemProductCategory
    {
        [XmlAttribute]
        public Nullable<int> BudgetItemId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductCategoryId { get; set; }
    }

    [TypeMapping(typeof(BudgetItemProductCategory), ElementName = "ProductCategory")]
    partial class BudgetItem
    {
        public const int Доходы_по_ОВД_Меню = 1;
        public const int Доходы_по_ОВД_Напитки_безалкогольные = 2;
        public const int Доходы_по_ОВД_Напитки_алкогольные = 3;
        public const int Доходы_по_ОВД_Пробка = 4;
        public const int Доходы_по_ОВД_Персонал = 5;
        public const int Доходы_по_ОВД_Транспорт = 6;
        public const int Доходы_по_ОВД_Наценка = 7;
        public const int Доходы_по_ОВД_НДС = 8;
        public const int Расходы_по_ОВД_Продукты = 9;
        public const int Расходы_по_ОВД_Напитки_безалкогольные = 10;
        public const int Расходы_по_ОВД_Напитки_алкогольные = 11;
        public const int Расходы_по_ОВД_Персонал_Склад = 12;
        public const int Расходы_по_ОВД_Персонал_Производство = 13;
        public const int Расходы_по_ОВД_Персонал_Проведение = 14;
        public const int Расходы_по_ОВД_Транспорт = 15;
        public const int Расходы_по_ОВД_Прачечная = 39;
        public const int Расходы_по_ОВД_Расходные_материалы = 16;
        public const int Расходы_по_ОВД_Потери_и_бой = 17;
        public const int Расходы_по_ОВД_Комплексные_обеды = 18;
        public const int Расходы_по_ОВД_Аренда_оборудования = 19;
        public const int Расходы_по_ОВД_Такси = 20;
        public const int Расходы_по_ОВД_Конвертация = 21;
        public const int Расходы_по_ОВД_Прочие_расходы = 22;
        public const int Расходы_по_ОВД_Комиссия_посреднику = 23;
        public const int Расходы_по_ОВД_НДС = 24;
        public const int Прочие_доходы_Дополнительные_услуги_РВО = 25;
        public const int Прочие_доходы_Дополнительные_услуги_Event = 26;
        public const int Прочие_доходы_Транзитные_платежи = 27;
        public const int Прочие_доходы_Агентские_от_подрядчика = 28;
        public const int Прочие_доходы_Наценка = 29;
        public const int Прочие_доходы_Прочее = 30;
        public const int Прочие_доходы_НДС = 31;
        public const int Прочие_расходы_Дополнительные_услуги_РВО = 32;
        public const int Прочие_расходы_Дополнительные_услуги_Event = 33;
        public const int Прочие_расходы_Транзитные_платежи = 34;
        public const int Прочие_расходы_Комиссия_посреднику = 35;
        public const int Прочие_расходы_Наценка = 36;
        public const int Прочие_расходы_Прочее = 37;
        public const int Прочие_расходы_НДС = 38;

        private ObservableCollection<BudgetItemProductCategory> _lines;

        public ObservableCollection<BudgetItemProductCategory> Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new ObservableCollection<BudgetItemProductCategory>();
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }
        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }
    }
}
