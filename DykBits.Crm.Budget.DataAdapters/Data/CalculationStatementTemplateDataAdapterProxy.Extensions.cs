using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CalculationStatementTemplateDataAdapterProxy
    {
        protected override CalculationStatementTemplate CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is BudgetTemplate)
            {
                document.BudgetTemplateId = ((BudgetTemplate)dataContext).Id;
            }
            return document;
        }
        protected override void OnValidate(CalculationStatementTemplate item)
        {
            if (string.IsNullOrEmpty(item.FileAs))
                item.FileAs = item.Metadata.Caption;
            base.OnValidate(item);
        }
        public CalculationStatementTemplate FindOrCreate(BudgetTemplate budgetTemplate, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            if (budgetTemplate.IsNew)
                throw new ArgumentException("Необходимо сохранить шаблон ПРС", "budgetTemplate");

            var document = Find(budgetTemplate, incomeBudgetItemId, expenseBudgetItemId);
            if (document != null)
                return document;
            return Create(budgetTemplate, incomeBudgetItemId, expenseBudgetItemId);
        }
        public CalculationStatementTemplate Create(BudgetTemplate budgetTemplate, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            var document = this.CreateItem(budgetTemplate);
            document.IncomeBudgetItemId = incomeBudgetItemId;
            document.ExpenseBudgetItemId = expenseBudgetItemId;
            return document;
        }
        public CalculationStatementTemplate Find(BudgetTemplate budgetTemplate, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            CalculationStatementTemplateFilter filter = new CalculationStatementTemplateFilter();
            filter.AllStates = true;
            filter.BudgetTemplateId = budgetTemplate.Id;
            filter.IncomeBudgetItemId = incomeBudgetItemId;
            filter.ExpenseBudgetItemId = expenseBudgetItemId;

            CalculationStatementTemplateView itemView = this.Browse(filter.ToXml()).FirstOrDefault();
            if (itemView == null)
                return null;
            return this.GetItem(itemView.GetKey());
        }
        public CalculationStatementTemplate CreateCopy(ItemKey key)
        {
            CalculationStatementTemplate source = this.GetItem(key);
            CalculationStatementTemplate copy = this.CreateItem(source);
            copy.FileAs = source.FileAs;
            copy.BudgetTemplateId = source.BudgetTemplateId;
            copy.IncomeBudgetItemId = source.IncomeBudgetItemId;
            copy.ExpenseBudgetItemId = source.ExpenseBudgetItemId;
            copy.Comments = source.Comments;
            foreach (var section in source.Sections)
            {
                copy.Sections.Add(new CalculationStatementTemplateSection
                {
                    CalculationStatementTemplateSectionId = section.CalculationStatementTemplateSectionId,
                    OrdinalPosition = section.OrdinalPosition,
                    FileAs = section.FileAs,
                    Comments = section.Comments,
                    ProductCategoryId = section.ProductCategoryId
                });
            }
            foreach (var line in source.Lines)
            {
                copy.Lines.Add(new CalculationStatementTemplateLine
                {
                    CalculationStatementTemplateSectionId = line.CalculationStatementTemplateSectionId,
                    OrdinalPosition = line.OrdinalPosition,
                    ProductId = line.ProductId,
                    FileAs = line.FileAs,
                    Comments = line.Comments,
                    Duration = line.Duration,
                    Amount = line.Amount,
                    DependsOnAmountOfPersons = line.DependsOnAmountOfPersons,
                    DependsOnEventDuration = line.DependsOnEventDuration,
                    Price = line.Price,
                    Cost = line.Cost
                });
            }
            return copy;
        }
    }
}
