namespace ClubManager.Domain.Entities.Financial
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; }

        public virtual Expense Expenses { get; set; }
    }
}
