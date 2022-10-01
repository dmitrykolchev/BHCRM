using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectTemplateDataAdapterProxy
    {
        protected override ProjectTemplate CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.Duration = 30;
            document.ProjectTypeId = ProjectType.Commercial;
            return document;
        }
    }
}
