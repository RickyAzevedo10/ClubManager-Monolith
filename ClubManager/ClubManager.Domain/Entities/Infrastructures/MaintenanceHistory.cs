using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Entities.Infrastructures
{
    public class MaintenanceHistory :BaseEntity
    {
        public int FacilityId { get; set; }  
        public string MaintenanceType { get; set; }  
        public string Description { get; set; }  
        public DateTime MaintenanceDate { get; set; }  
        public int RequestUserId { get; set; } 
        // Relacionamentos com outras tabelas
        public Facility Facility { get; set; } 
        public User RequestUser { get; set; }

        public void SetFacilityId(int facilityId)
        {
            FacilityId = facilityId;
        }

        public void SetMaintenanceType(string maintenanceType)
        {
            MaintenanceType = maintenanceType;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetMaintenanceDate(DateTime maintenanceDate)
        {
            MaintenanceDate = maintenanceDate;
        }

        public void SetRequestUserId(int requestUserId)
        {
            RequestUserId = requestUserId;
        }
    }
}
