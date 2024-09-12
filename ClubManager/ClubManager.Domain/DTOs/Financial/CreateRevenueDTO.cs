namespace ClubManager.Domain.DTOs.Financial
{
    public class CreateRevenueDTO
    {
        public CreateEntityDTO Entity { get; set; }
        public List<RevenueDTO> Revenues { get; set; }
    }

    public class RevenueDTO
    {
        public DateTime RevenueDate { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string PaymentReference { get; set; }
        public int EntityId { get; set; }
        public int ResponsibleUserId { get; set; }
    }
}
