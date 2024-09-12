namespace ClubManager.Domain.DTOs.Financial
{
    public class CreateExpenseDTO
    {
        public CreateEntityDTO Entity { get; set; }
        public List<ExpenseDTO> Expenses { get; set; }
    }

    public class ExpenseDTO
    {
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string Destination { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string PaymentReference { get; set; }
        public int EntityId { get; set; }
        public int ResponsibleUserId { get; set; }
    }
}
