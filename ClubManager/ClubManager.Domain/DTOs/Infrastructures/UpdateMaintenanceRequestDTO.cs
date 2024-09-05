namespace ClubManager.Domain.DTOs.Infrastructures
{
    public class UpdateMaintenanceRequestDTO
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }  
        public string MaintenanceType { get; set; }  
        public string ProblemDescription { get; set; }  
        public string Priority { get; set; }  
        public DateTime RequestDate { get; set; }  
        public int RequestedUserId { get; set; }  
        public string Status { get; set; } 
    }
}
