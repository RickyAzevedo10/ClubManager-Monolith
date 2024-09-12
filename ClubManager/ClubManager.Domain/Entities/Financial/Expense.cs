using ClubManager.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManager.Domain.Entities.Financial
{
    public class Expense : BaseEntity
    {
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }  
        public string Destination { get; set; }  
        public int CategoryId { get; set; }  
        public string Description { get; set; }  
        public string PaymentReference { get; set; }  
        public int EntityId { get; set; }
        public int ResponsibleUserId { get; set; }

        // Propriedades de navegação
        public virtual ExpenseCategory ExpenseCategory { get; set; }  // Referência para a categoria da despesa
        public virtual Entity Entity { get; set; }
        public virtual User User { get; set; }

        public void SetExpenseDate(DateTime expenseDate)
        {
            ExpenseDate = expenseDate;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public void SetDestination(string destination)
        {
            Destination = destination;
        }

        public void SetCategoryId(int categoryId)
        {
            CategoryId = categoryId;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetPaymentReference(string paymentReference)
        {
            PaymentReference = paymentReference;
        }

        public void SetEntityId(int entityId)
        {
            EntityId = entityId;
        }

        public void SetResponsibleUserId(int responsibleUserId)
        {
            ResponsibleUserId = responsibleUserId;
        }

    }
}
