using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces.Repositories.Identity;

namespace ClubManager.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();

        //Identity
        IUserRepository UserRepository { get; }
        IInstitutionRepository InstitutionRepository { get; }
        IBaseRepository<UserRoles> UserRolesRepository { get; }
        IUserPermissionsRepository UserPermissionsRepository { get; }

        //MembersTeams
        IPlayerRepository PlayerRepository { get; }
        IBaseRepository<PlayerCategory> PlayerCategoryRepository { get; }
        IPlayerPerformanceHistoryRepository PlayerPerformanceHistoryRepository { get; }
        IClubMemberRepository ClubMemberRepository { get; }
        IMinorClubMemberRepository MinorClubMemberRepository { get; }
        IBaseRepository<PlayerResponsible> PlayerResponsibleRepository { get; }
        IPlayerContractRepository PlayerContractRepository { get; }
        IPlayerTransferRepository PlayerTransferRepository { get; }
        ITeamRepository TeamRepository { get; }
        IBaseRepository<TeamCategory> TeamCategoryRepository { get; }
        IBaseRepository<TeamPlayer> TeamPlayerRepository { get; }
        IBaseRepository<TeamCoach> TeamCoachRepository { get; }
        IBaseRepository<UserClubMember> UserClubMemberRepository { get; }

        //Infrastructures
        IBaseRepository<FacilityCategory> FacilityCategoryRepository { get; }
        IBaseRepository<Facility> FacilityRepository { get; }
        IBaseRepository<FacilityReservation> FacilityReservationRepository { get; }
        IBaseRepository<MaintenanceRequest> MaintenanceRequestRepository { get; }
        IMaintenanceHistoryRepository MaintenanceHistoryRepository { get; }

    }
}