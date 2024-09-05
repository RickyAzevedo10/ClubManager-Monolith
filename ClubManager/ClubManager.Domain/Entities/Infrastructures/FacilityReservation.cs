using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Entities.Infrastructures
{
    public class FacilityReservation : BaseEntity
    {
        public int FacilityId { get; set; }  
        public DateTime StartTime { get; set; }  
        public DateTime EndTime { get; set; }
        public string EventType { get; set; }  
        public string EventDescription { get; set; }  
        public int ReservedUserId { get; set; }  
        // Relacionamentos com outras tabelas
        public Facility Facility { get; set; }  
        public User ReservedUser { get; set; }


        public void SetFacilityId(int facilityId)
        {
            FacilityId = facilityId;
        }

        public void SetStartTime(DateTime startTime)
        {
            StartTime = startTime;
        }

        public void SetEndTime(DateTime endTime)
        {
            EndTime = endTime;
        }

        public void SetEventType(string eventType)
        {
            EventType = eventType;
        }

        public void SetEventDescription(string eventDescription)
        {
            EventDescription = eventDescription;
        }

        public void SetReservedUserId(int reservedUserId)
        {
            ReservedUserId = reservedUserId;
        }
    }
}
