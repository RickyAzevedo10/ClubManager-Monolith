using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Infrastructures;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Interfaces.Repositories;
using ClubManager.Domain.Interfaces.Repositories.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Repositories.Identity;

namespace ClubManager.Infra.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        //Identity
        public IUserRepository _userRepository { get; private set; }
        public IInstitutionRepository _institutionRepository { get; private set; }
        public IBaseRepository<UserRoles> _userRolesRepository { get; private set; }
        public IUserPermissionsRepository _userPermissionsRepository { get; private set; }

        //MembersTeams
        public IPlayerRepository _playerRepository { get; private set; }
        public IBaseRepository<PlayerCategory> _playerCategoryRepository { get; private set; }
        public IPlayerPerformanceHistoryRepository _playerPerformanceHistoryRepository { get; private set; }
        public IClubMemberRepository _clubMemberRepository { get; private set; }
        public IMinorClubMemberRepository _minorClubMemberRepository { get; private set; }
        public IBaseRepository<PlayerResponsible> _playerResponsibleRepository { get; private set; }
        public IPlayerContractRepository _playerContractRepository { get; private set; }
        public IPlayerTransferRepository _playerTransferRepository { get; private set; }
        public ITeamRepository _teamRepository { get; private set; }
        public IBaseRepository<TeamCategory> _teamCategoryRepository { get; private set; }
        public IBaseRepository<TeamPlayer> _teamPlayerRepository { get; private set; }
        public IBaseRepository<TeamCoach> _teamCoachRepository { get; private set; }
        public IBaseRepository<UserClubMember> _userClubMemberRepository { get; private set; }

        //Infrastructures
        public IBaseRepository<FacilityCategory> _facilityCategoryRepository { get; private set; }
        public IBaseRepository<Facility> _facilityRepository { get; private set; }
        public IBaseRepository<FacilityReservation> _facilityReservationRepository { get; private set; }
        public IBaseRepository<MaintenanceRequest> _maintenanceRequestRepository { get; private set; }
        public IMaintenanceHistoryRepository _maintenanceHistoryRepository { get; private set; }


        //TrainingCompetition
        public IMatchRepository _matchRepository { get; private set; }
        public IMatchStatisticRepository _matchStatisticRepository { get; private set; }
        public ITrainingAttendanceRepository _trainingAttendanceRepository { get; private set; }
        public ITrainingSessionRepository _trainingSessionRepository { get; private set; }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #region Identity
        public IInstitutionRepository InstitutionRepository
        {
            get
            {
                if (_institutionRepository == null)
                {
                    _institutionRepository = new InstitutionRepository(_context);
                }
                return _institutionRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IBaseRepository<UserRoles> UserRolesRepository
        {
            get
            {
                if (_userRolesRepository == null)
                {
                    _userRolesRepository = new BaseRepository<UserRoles>(_context);
                }
                return _userRolesRepository;
            }
        }

        public IUserPermissionsRepository UserPermissionsRepository
        {
            get
            {
                if (_userPermissionsRepository == null)
                {
                    _userPermissionsRepository = new UserPermissionsRepository(_context);
                }
                return _userPermissionsRepository;
            }
        }
        #endregion

        #region MembersTeams
        public IPlayerRepository PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(_context);
                }
                return _playerRepository;
            }
        }

        public IBaseRepository<PlayerCategory> PlayerCategoryRepository
        {
            get
            {
                if (_playerCategoryRepository == null)
                {
                    _playerCategoryRepository = new BaseRepository<PlayerCategory>(_context);
                }
                return _playerCategoryRepository;
            }
        }

        public IPlayerPerformanceHistoryRepository PlayerPerformanceHistoryRepository
        {
            get
            {
                if (_playerPerformanceHistoryRepository == null)
                {
                    _playerPerformanceHistoryRepository = new PlayerPerformanceHistoryRepository(_context);
                }
                return _playerPerformanceHistoryRepository;
            }
        }

        public IClubMemberRepository ClubMemberRepository
        {
            get
            {
                if (_clubMemberRepository == null)
                {
                    _clubMemberRepository = new ClubMemberRepository(_context);
                }
                return _clubMemberRepository;
            }
        }

        public IMinorClubMemberRepository MinorClubMemberRepository
        {
            get
            {
                if (_minorClubMemberRepository == null)
                {
                    _minorClubMemberRepository = new MinorClubMemberRepository(_context);
                }
                return _minorClubMemberRepository;
            }
        }

        public IBaseRepository<PlayerResponsible> PlayerResponsibleRepository
        {
            get
            {
                if (_playerResponsibleRepository == null)
                {
                    _playerResponsibleRepository = new BaseRepository<PlayerResponsible>(_context);
                }
                return _playerResponsibleRepository;
            }
        }

        public IPlayerContractRepository PlayerContractRepository
        {
            get
            {
                if (_playerContractRepository == null)
                {
                    _playerContractRepository = new PlayerContractRepository(_context);
                }
                return _playerContractRepository;
            }
        }

        public IPlayerTransferRepository PlayerTransferRepository
        {
            get
            {
                if (_playerTransferRepository == null)
                {
                    _playerTransferRepository = new PlayerTransferRepository(_context);
                }
                return _playerTransferRepository;
            }
        }

        public ITeamRepository TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new TeamRepository(_context);
                }
                return _teamRepository;
            }
        }

        public IBaseRepository<TeamCategory> TeamCategoryRepository
        {
            get
            {
                if (_teamCategoryRepository == null)
                {
                    _teamCategoryRepository = new BaseRepository<TeamCategory>(_context);
                }
                return _teamCategoryRepository;
            }
        }

        public IBaseRepository<TeamPlayer> TeamPlayerRepository
        {
            get
            {
                if (_teamPlayerRepository == null)
                {
                    _teamPlayerRepository = new BaseRepository<TeamPlayer>(_context);
                }
                return _teamPlayerRepository;
            }
        }

        public IBaseRepository<TeamCoach> TeamCoachRepository
        {
            get
            {
                if (_teamCoachRepository == null)
                {
                    _teamCoachRepository = new BaseRepository<TeamCoach>(_context);
                }
                return _teamCoachRepository;
            }
        }

        public IBaseRepository<UserClubMember> UserClubMemberRepository
        {
            get
            {
                if (_userClubMemberRepository == null)
                {
                    _userClubMemberRepository = new BaseRepository<UserClubMember>(_context);
                }
                return _userClubMemberRepository;
            }
        }

        #endregion

        #region Infrastructures
        public IBaseRepository<FacilityCategory> FacilityCategoryRepository
        {
            get
            {
                if (_facilityCategoryRepository == null)
                {
                    _facilityCategoryRepository = new BaseRepository<FacilityCategory>(_context);
                }
                return _facilityCategoryRepository;
            }
        }

        public IBaseRepository<Facility> FacilityRepository
        {
            get
            {
                if (_facilityRepository == null)
                {
                    _facilityRepository = new BaseRepository<Facility>(_context);
                }
                return _facilityRepository;
            }
        }

        public IBaseRepository<FacilityReservation> FacilityReservationRepository
        {
            get
            {
                if (_facilityReservationRepository == null)
                {
                    _facilityReservationRepository = new BaseRepository<FacilityReservation>(_context);
                }
                return _facilityReservationRepository;
            }
        }

        public IBaseRepository<MaintenanceRequest> MaintenanceRequestRepository
        {
            get
            {
                if (_maintenanceRequestRepository == null)
                {
                    _maintenanceRequestRepository = new BaseRepository<MaintenanceRequest>(_context);
                }
                return _maintenanceRequestRepository;
            }
        }

        public IMaintenanceHistoryRepository MaintenanceHistoryRepository
        {
            get
            {
                if (_maintenanceHistoryRepository == null)
                {
                    _maintenanceHistoryRepository = new MaintenanceHistoryRepository(_context);
                }
                return _maintenanceHistoryRepository;
            }
        }
        #endregion

        #region TrainingCompetition
        public IMatchRepository MatchRepository
        {
            get
            {
                if (_matchRepository == null)
                {
                    _matchRepository = new MatchRepository(_context);
                }
                return _matchRepository;
            }
        }

        public IMatchStatisticRepository MatchStatisticRepository
        {
            get
            {
                if (_matchStatisticRepository == null)
                {
                    _matchStatisticRepository = new MatchStatisticRepository(_context);
                }
                return _matchStatisticRepository;
            }
        }

        public ITrainingAttendanceRepository TrainingAttendanceRepository
        {
            get
            {
                if (_trainingAttendanceRepository == null)
                {
                    _trainingAttendanceRepository = new TrainingAttendanceRepository(_context);
                }
                return _trainingAttendanceRepository;
            }
        }

        public ITrainingSessionRepository TrainingSessionRepository
        {
            get
            {
                if (_trainingSessionRepository == null)
                {
                    _trainingSessionRepository = new TrainingSessionRepository(_context);
                }
                return _trainingSessionRepository;
            }
        }

        #endregion
    }
}
