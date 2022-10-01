using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateSection : NotifyDataObject
    {
        public static readonly NotifyDataObjectProperty CalculationStatementTemplateSectionIdProperty = NotifyDataObjectProperty.Register<int, CalculationStatementTemplateSection>("CalculationStatementTemplateSectionId");
        public static readonly NotifyDataObjectProperty CalculationStatementTemplateIdProperty = NotifyDataObjectProperty.Register<int, CalculationStatementTemplateSection>("CalculationStatementTemplateId");
        public static readonly NotifyDataObjectProperty OrdinalPositionProperty = NotifyDataObjectProperty.Register<int, CalculationStatementTemplateSection>("OrdinalPosition");
        public static readonly NotifyDataObjectProperty FileAsProperty = NotifyDataObjectProperty.Register<string, CalculationStatementTemplateSection>("FileAs");
        public static readonly NotifyDataObjectProperty CommentsProperty = NotifyDataObjectProperty.Register<string, CalculationStatementTemplateSection>("Comments");
        public static readonly NotifyDataObjectProperty ProductCategoryIdProperty = NotifyDataObjectProperty.Register<Nullable<int>, CalculationStatementTemplateSection>("ProductCategoryId");
        private static int SectionCount = 0;
        public CalculationStatementTemplateSection()
        {
            CalculationStatementTemplateSectionId = System.Threading.Interlocked.Decrement(ref SectionCount);
        }
        [XmlAttribute]
        public int CalculationStatementTemplateSectionId
        {
            get { return GetValue<int>(CalculationStatementTemplateSectionIdProperty); }
            set { this.WriteValue(CalculationStatementTemplateSectionIdProperty, value); }
        }
        [XmlAttribute]
        public int CalculationStatementTemplateId
        {
            get { return GetValue<int>(CalculationStatementTemplateIdProperty); }
            set { this.WriteValue(CalculationStatementTemplateIdProperty, value); }
        }
        [XmlAttribute]
        public int OrdinalPosition
        {
            get { return GetValue<int>(OrdinalPositionProperty); }
            set { this.SetValue(OrdinalPositionProperty, value); }
        }
        [XmlAttribute]
        public string FileAs
        {
            get { return GetValue<string>(FileAsProperty); }
            set { this.SetValue(FileAsProperty, value); }
        }
        [XmlAttribute]
        public string Comments
        {
            get { return GetValue<string>(CommentsProperty); }
            set { this.SetValue(CommentsProperty, value); }
        }
        [XmlAttribute]
        public Nullable<int> ProductCategoryId
        {
            get { return GetValue<Nullable<int>>(ProductCategoryIdProperty); }
            set { this.SetValue(ProductCategoryIdProperty, value); }
        }
        [XmlIgnore]
        public CalculationStatementTemplate Parent { get; internal set; }
    }
}
