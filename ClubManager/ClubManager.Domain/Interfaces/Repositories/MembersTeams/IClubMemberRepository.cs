using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IClubMemberRepository : IBaseRepository<ClubMember>
    {
        Task<ClubMember?> GetByIdAsync(long clubMemberId);
        Task<ClubMember?> GetByEmailAsync(string email);
        Task<IEnumerable<ClubMember>> SearchClubMembersAsync(string? firstName, string? lastName);
    }
}