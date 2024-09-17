namespace ClubManager.Domain.DTOs.Financial
{
    public class UpdateEntityRevenueDTO
    {
        public UpdateEntityDTO Entity { get; set; }
        public List<UpdateRevenueDTO> Revenues { get; set; }
    }

    public class UpdateRevenueDTO
    {
        public int Id { get; set; }
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
