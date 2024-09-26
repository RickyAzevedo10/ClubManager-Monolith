using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IUserClubMemberRepository : IBaseRepository<UserClubMember>
    {
        Task<UserClubMember?> GetByUserIdAsync(long userId);
    }
}