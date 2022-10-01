using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class UserNotificationView
    {
        private IDataItem _dataItem;
        private IDataItem _targetDocument;
        [XmlIgnore]
        public string Caption
        {
            get
            {
                if (string.IsNullOrEmpty(FileAs))
                    return null;
                if (this.FileAs[0] != '#')
                    return this.FileAs;
                switch (this.FileAs)
                {
                    case "#ProjectTaskAssigned":
                        return "Назначение исполнителем задачи";
                    case "#ProjectTaskUnassigned":
                        return "Исключение из исполнителей задачи";
                    case "#ProjectMemberAssigned":
                        return "Включение в рабочую группу";
                    case "#ProjectMemberUnassigned":
                        return "Исключение из рабочей группы";
                }
                return this.FileAs;
            }
        }
        [XmlIgnore]
        public IDataItem Item
        {
            get
            {
                if (this._dataItem == null && this.DocumentId.HasValue)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._dataItem = listManager.GetItem(ItemKey.CreateKey(this.DocumentTypeId.Value, this.DocumentId.Value));
                }
                return this._dataItem;
            }
        }
        [XmlIgnore]
        public IDataItem TargetDocument
        {
            get
            {
                if (this._targetDocument == null)
                {
                    switch (this.FileAs)
                    {
                        case "#ProjectTaskAssigned":
                        case "#ProjectTaskUnassigned":
                            this._targetDocument = Item;
                            break;
                        case "#ProjectMemberAssigned":
                        case "#ProjectMemberUnassigned":
                            ServiceRequestFilter filter = new ServiceRequestFilter { ProjectMemberId = ((ProjectMemberView)Item).Id };
                            this._targetDocument = DocumentManager.Browse<ServiceRequestView>(filter).FirstOrDefault();
                            break;
                        default:
                            this._targetDocument = Item;
                            break;
                    }
                }
                return this._targetDocument;
            }
        }
    }
}
