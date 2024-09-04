namespace ClubManager.Domain.Entities.Identity
{
    public class UserRoles : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
