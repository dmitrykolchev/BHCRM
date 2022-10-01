using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectTaskTemplateDataAdapterProxy
    {
        protected override ProjectTaskTemplate CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.Importance = Importance.Normal;
            document.TaskDuration = 1;
            document.IsMilestone = true;
            document.TaskStartOffset = 0;
            if (dataContext is ProjectTemplate)
            {
                document.ProjectTemplateId = ((ProjectTemplate)dataContext).Id;
            }
            return document;
        }
    }
}
