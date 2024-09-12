namespace ClubManager.Domain.DTOs.Financial
{
    public class CreateEntityDTO
    {
        public bool Internal { get; set; }
        public bool External { get; set; }
        public int? ClubMemberId { get; set; }
        public int? PlayerId { get; set; }
        public string EntityType { get; set; }
        public string EntityName { get; set; }
    }
}
