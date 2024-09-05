namespace ClubManager.Domain.DTOs.Infrastructures
{
    public class CreateFacilityReservationDTO
    {
        public int FacilityId { get; set; }  
        public DateTime StartTime { get; set; }  
        public DateTime EndTime { get; set; }  
        public string EventType { get; set; } 
        public string EventDescription { get; set; }  
        public int ReservedUserId { get; set; }  
    }
}
