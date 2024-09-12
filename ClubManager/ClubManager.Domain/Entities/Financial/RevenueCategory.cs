namespace ClubManager.Domain.Entities.Financial
{
    public class RevenueCategory : BaseEntity
    {
        public string Name { get; set; }  
        public string Description { get; set; }  
        public virtual Revenue Revenues { get; set; }
    }
}
