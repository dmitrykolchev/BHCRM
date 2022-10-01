using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentEmployeeAccessRightDataAdapterProxy
    {
        protected override DocumentEmployeeAccessRight CreateItemOverride(object dataContext)
        {
            DocumentEmployeeAccessRight document = base.CreateItemOverride(dataContext);
            if (dataContext is IDataItem)
            {
                IDataItem dataItem = (IDataItem)dataContext;
                document.DocumentTypeId = dataItem.DataItemClassId;
                document.DocumentId = dataItem.Id;
            }
            IEmployeeInfo employeeInfo = SecurityManager.GetCurrentEmployee();
            document.EmployeeId = employeeInfo.Id;
            document.DocumentAccessTypeId = DocumentAccessType.DocumentAccessTypeMisc;
            document.StartDate = DateTime.Today;

            return document;
        }

        protected override void OnValidate(DocumentEmployeeAccessRight item)
        {
            base.OnValidate(item);
            if (string.IsNullOrEmpty(item.FileAs))
            {
                DocumentMetadata metadata = DocumentManager.GetMetadata(item.DocumentTypeId);
                switch (item.DocumentAccessTypeId)
                {
                    case DocumentAccessType.DocumentAccessTypeGeneral:
                        item.FileAs = "Основной доступ к документу '" + metadata.Caption + "'";
                        break;
                    case DocumentAccessType.DocumentAccessTypeMisc:
                        item.FileAs = "Дополнительный доступ к документу '" + metadata.Caption + "'";
                        break;
                    case DocumentAccessType.DocumentAccessTypeTemporary:
                        item.FileAs = "Временный доступ к документу '" + metadata.Caption + "'";
                        break;
                }
            }
            switch (item.DocumentAccessTypeId)
            {
                case DocumentAccessType.DocumentAccessTypeGeneral:
                case DocumentAccessType.DocumentAccessTypeMisc:
                    if (!item.StartDate.HasValue)
                        throw new ArgumentException("Необходимо ввести дату начала");
                    item.EndDate = null;
                    break;
                case DocumentAccessType.DocumentAccessTypeTemporary:
                    if (!item.StartDate.HasValue)
                        throw new ArgumentException("Необходимо ввести дату начала временного доступа");
                    if (!item.EndDate.HasValue)
                        throw new ArgumentException("Необходимо ввести дату окончания временного доступа");
                    break;
            }
            

        }
    }
}
