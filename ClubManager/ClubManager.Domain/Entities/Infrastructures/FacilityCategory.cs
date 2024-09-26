namespace ClubManager.Domain.Entities.Infrastructures
{
    public class FacilityCategory : BaseEntity
    {
        public string Name { get; set; }  
        public string Description { get; set; }
        public ICollection<Facility> Facility { get; set; }
    }
}
