using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CalculationStatementDataAdapterProxy
    {
        public CalculationStatement Find(Budget budget, int calculationStage, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            if (budget.IsNew)
                throw new ArgumentException("Необходимо сохранить смету", "budget");
            CalculationStatementFilter filter = (CalculationStatementFilter)this.CreateFilter(budget, null);
            filter.AllStates = true;
            filter.IncomeBudgetItemId = incomeBudgetItemId;
            filter.ExpenseBudgetItemId = expenseBudgetItemId;
            filter.CalculationStage = calculationStage;

            CalculationStatementView itemView = this.Browse(filter.ToXml()).FirstOrDefault();
            if (itemView == null)
                return null;
            return this.GetItem(itemView.GetKey());
        }
        public CalculationStatement Create(Budget budget, int calculationStage, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            if (budget.IsNew)
                throw new ArgumentException("Необходимо сохранить смету", "budget");
            var document = this.CreateItem(budget);
            document.CalculationStage = calculationStage;
            document.IncomeBudgetItemId = incomeBudgetItemId;
            document.ExpenseBudgetItemId = expenseBudgetItemId;
            return document;
        }
        public CalculationStatement CreateFromTemplate(Budget budget, BudgetTemplate budgetTemplate, CalculationStatementTemplate template)
        {
            var document = base.CreateItem(budget);
            document.DocumentDate = DateTime.Today;
            document.IncomeBudgetItemId = template.IncomeBudgetItemId;
            document.ExpenseBudgetItemId = template.ExpenseBudgetItemId;
            document.DependsOnAmountOfPersons = template.DependsOnAmountOfPersons;
            document.AmountOnly = template.AmountOnly;
            document.VATRateId = VATRate.VATRate18;
            document.Margin = 0;
            document.Discount = 0;
            document.Comments = template.Comments;
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            if (employee != null)
            {
                document.ResponsibleEmployeeId = employee.Id;
                document.OrganizationId = employee.OrganizationId;
            }

            ListManager listManager = ServiceManager.GetService<ListManager>();
            DocumentRecordCollection products = listManager.GetList(Product.DataItemClassName);
            foreach (var section in template.Sections)
            {
                var lines = template.Lines.Where(t => t.CalculationStatementTemplateSectionId == section.CalculationStatementTemplateSectionId);
                CalculationStatementSection newSection = new CalculationStatementSection
                {
                    CalculationStatementSectionId = section.CalculationStatementTemplateSectionId,
                    FileAs = section.FileAs,
                    Comments = section.Comments,
                    ProductCategoryId = section.ProductCategoryId,
                    StandardAmount = 0,
                    StandardTotalCost = 0,
                    StandardTotalPrice = 0
                };
                List<CalculationStatementLine> newLines = new List<CalculationStatementLine>();
                foreach (var line in lines)
                {
                    decimal cost;
                    decimal price;
                    if (line.ProductId.HasValue)
                    {
                        ProductView product = (ProductView)products[line.ProductId.Value];
                        cost = product.StandardCost;
                        price =  product.ListPrice;
                    }
                    else
                    {
                        cost = line.Cost;
                        price = line.Price;
                    }

                    if (document.AmountOnly)
                    {
                        cost = 0;
                        price = 0;
                    }

                    decimal amount = line.Amount;
                    if (line.DependsOnAmountOfPersons)
                    {
                        amount *= budget.AmountOfGuests.Value;
                        amount /= budgetTemplate.AmountOfPersons;
                    }
                    if (line.DependsOnEventDuration)
                    {
                        amount *= budget.EventDuration.Value;
                        amount /= budgetTemplate.EventDuration;
                    }
                    CalculationStatementLine newLine = new CalculationStatementLine
                    {
                        CalculationStatementSectionId = newSection.CalculationStatementSectionId,
                        ProductId = line.ProductId,
                        FileAs = line.FileAs,
                        Comments = line.Comments,
                        StartTime = DateTime.Today,
                        EndTime = DateTime.Today + TimeSpan.FromHours((double)line.Duration),
                        Amount = amount,
                        Factor = 1,
                        Cost = cost,
                        Price = price
                    };
                    newLines.Add(newLine);
                    decimal standardAmount = newLine.Amount * newLine.Duration.GetValueOrDefault(1);
                    newSection.StandardAmount += standardAmount;
                    newSection.StandardTotalCost += standardAmount * newLine.Cost;
                    newSection.StandardTotalPrice += standardAmount * newLine.Price;
                }
                document.Sections.Add(newSection);
                foreach (var line in newLines)
                    document.Lines.Add(line);
            }
            return document;
        }
        protected override CalculationStatement CreateItemOverride(object dataContext)
        {
            if (dataContext is CalculationStatement)
                return ((CalculationStatement)dataContext).Clone();

            var document = base.CreateItemOverride(dataContext);
            document.VATRateId = VATRate.VATRate18;
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            if (employee != null)
            {
                document.ResponsibleEmployeeId = employee.Id;
            }
            if (dataContext is ServiceRequest)
            {
                document.ServiceRequestId = ((ServiceRequest)dataContext).Id;
                document.OrganizationId = ((ServiceRequest)dataContext).OrganizationId;
            }
            else if (dataContext is Budget)
            {
                document.BudgetId = ((Budget)dataContext).Id;
                document.ServiceRequestId = ((Budget)dataContext).ServiceRequestId;
                document.OrganizationId = ((Budget)dataContext).OrganizationId;
            }
            return document;
        }
    }
}
