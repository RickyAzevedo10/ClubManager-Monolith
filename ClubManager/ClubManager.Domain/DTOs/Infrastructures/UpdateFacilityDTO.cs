namespace ClubManager.Domain.DTOs.Infrastructures
{
    public class UpdateFacilityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int FacilityCategoryId { get; set; }  
        public string Location { get; set; }  
        public int Capacity { get; set; } 
        public string Description { get; set; }  
    }
}
