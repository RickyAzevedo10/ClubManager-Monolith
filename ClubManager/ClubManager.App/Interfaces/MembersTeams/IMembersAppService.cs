using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.App.Interfaces.Identity
{
    public interface IMembersAppService
    {
        Task<ClubMemberResponseDTO?> Create(CreateClubMemberDTO memberToCreate);
        Task<ClubMemberResponseDTO?> Delete(long id);
        Task<List<ClubMemberResponseDTO>?> GetAllClubMembers();
        Task<ClubMemberResponseDTO?> Update(UpdateClubMemberDTO clubMemberToUpdate);
        Task<List<ClubMemberResponseDTO>?> SearchClubMembersAsync(string? firstName, string? lastName);

        Task<MinorClubMemberResponseDTO?> DeleteMinorClubMember(long id);
        Task<List<MinorClubMemberResponseDTO>?> GetAllMinorClubMembers();
        Task<MinorClubMemberResponseDTO?> CreateMinorClubMembers(CreateMinorClubMemberDTO minorMemberToCreate);
        Task<MinorClubMemberResponseDTO?> UpdateMinorMembers(UpdateMinorClubMemberDTO minorClubMemberToUpdate);
        Task<List<MinorClubMemberResponseDTO>?> SearchMinorMembersAsync(string? firstName, string? lastName);
    }
}
