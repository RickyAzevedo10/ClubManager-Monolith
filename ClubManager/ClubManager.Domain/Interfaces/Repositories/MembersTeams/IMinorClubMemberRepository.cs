using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IMinorClubMemberRepository : IBaseRepository<MinorClubMember>
    {
        Task<MinorClubMember?> GetByIdAsync(long clubMemberId);
        Task<MinorClubMember?> GetByEmailAsync(string email);
        Task<IEnumerable<MinorClubMember>> SearchMinorClubMemberAsync(string? firstName, string? lastName);
    }
}