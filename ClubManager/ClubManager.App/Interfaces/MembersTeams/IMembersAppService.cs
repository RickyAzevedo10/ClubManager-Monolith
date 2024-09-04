using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IMembersAppService
    {
        Task<ClubMember?> Create(CreateClubMemberDTO memberToCreate);
        Task<ClubMember?> Delete(long id);
        Task<List<ClubMember>?> GetAllClubMembers();
        Task<ClubMember?> Update(UpdateClubMemberDTO clubMemberToUpdate);

        Task<MinorClubMember?> DeleteMinorClubMember(long id);
        Task<List<MinorClubMember>?> GetAllMinorClubMembers();
        Task<MinorClubMember?> CreateMinorClubMembers(CreateMinorClubMemberDTO minorMemberToCreate);
        Task<MinorClubMember?> UpdateMinorMembers(UpdateMinorClubMemberDTO minorClubMemberToUpdate);
        Task<List<ClubMember>?> SearchClubMembersAsync(string? firstName, string? lastName);
        Task<List<MinorClubMember>?> SearchMinorMembersAsync(string? firstName, string? lastName);
    }
}
