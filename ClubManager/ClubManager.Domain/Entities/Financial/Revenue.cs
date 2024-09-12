namespace ClubManager.Domain.Entities.Financial
{
    public class Revenue : BaseEntity
    {
        public DateTime RevenueDate { get; set; }  
        public decimal Amount { get; set; }  
        public string Source { get; set; }  
        public int CategoryId { get; set; }  
        public string Description { get; set; }  
        public string PaymentReference { get; set; }  
        public int EntityId { get; set; }  

        
        public virtual RevenueCategory RevenueCategory { get; set; }  
        public virtual Entity Entity { get; set; }

        public void SetRevenueDate(DateTime revenueDate)
        {
            RevenueDate = revenueDate;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public void SetSource(string source)
        {
            Source = source;
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

    }
}
