namespace ClubManager.Domain.Entities.Identity
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; }
        public string? Abbreviation { get; set; }
        public string? Logo { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Address { get; set; }
        public string? Colors { get; set; }
        public string? StadiumName { get; set; }
        public int StadiumCapacity { get; set; }
        public DateTime StadiumInauguration { get; set; }
        public bool HaveTrainingCenter { get; set; }
        public string? TrainingCenterAddress { get; set; }
        public string? OfficialWebsiteUrl { get; set; }
        public string? SocialMediaLinks { get; set; }
        public ICollection<User> User { get; set; } = [];

        public Institution() { }

        public Institution(Institution institution)
        {
            Name = institution.Name;
            Address = institution.Address;
            Abbreviation = institution.Abbreviation;
            Logo = institution.Logo;
            FoundationDate = institution.FoundationDate;
            Colors = institution.Colors;
            StadiumName = institution.StadiumName;
            StadiumCapacity = institution.StadiumCapacity;
            StadiumInauguration = institution.StadiumInauguration;
            HaveTrainingCenter = institution.HaveTrainingCenter;
            TrainingCenterAddress = institution.TrainingCenterAddress;
            OfficialWebsiteUrl = institution.OfficialWebsiteUrl;
            SocialMediaLinks = institution.SocialMediaLinks;
            User = new List<User>(institution.User);
        }
    }
}
