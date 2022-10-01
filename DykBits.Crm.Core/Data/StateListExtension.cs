using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DykBits.Crm.Data
{
    [MarkupExtensionReturnType(typeof(IList))]
    public class StateListExtension : MarkupExtension
    {
        public StateListExtension()
        {
            OrderByState = true;
        }
        public StateListExtension(string documentType): this()
        {
            this.DocumentType = documentType;
        }
        public string DocumentType { get; set; }
        public bool OrderByState { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationManager.IsInitialized)
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                DocumentMetadata metadata = documentManager.Documents[DocumentType];
                if (OrderByState)
                    return metadata.States.Where(t=>t.State != 0).OrderBy(t => t.State).ToList();
                return metadata.States.Where(t => t.State != 0).OrderBy(t => t.Caption).ToList();
            }
            return new DocumentState[0];
        }

    }
}
