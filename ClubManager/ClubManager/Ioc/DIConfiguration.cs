using ClubManager.API.ActionFilters;
using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.App.Services.Identity;
using ClubManager.App.Services.Infrastructures;
using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Identity.Validators;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Infrastructures;
using ClubManager.Domain.Interfaces.Repositories;
using ClubManager.Domain.Services;
using ClubManager.Domain.Services.Identity;
using ClubManager.Domain.Services.Infrastructures;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using ClubManager.Infra.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ClubManager.Ioc
{
    public static class DIConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            // Add UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Model Errors
            services.AddScoped<IModelErrorsContext, ModelErrorsContext>();
            services.AddScoped<IEntityValidationService, EntityValidationService>();
            //Add notification context
            services.AddScoped<INotificationContext, NotificationContext>();

            //Add Infra Services dependencies
            services.AddScoped<IUserClaimsService, UserClaimsService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            

            #region Add App Services dependencies 
            //Identity
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IInstitutionAppService, InstitutionAppService>();

            //Financial
            services.AddScoped<IEntityAppService, EntityAppService>();
            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<IRevenueAppService, RevenueAppService>();

            //Infrastrucutres
            services.AddScoped<IFacilityAppService, FacilityAppService>();
            services.AddScoped<IMaintenanceAppService, MaintenanceAppService>();

            //MembersTeams
            services.AddScoped<IMembersAppService, MembersAppService>();
            services.AddScoped<IPlayerAppService, PlayerAppService>();
            services.AddScoped<ITeamAppService, TeamAppService>();

            //TrainingCompetition
            services.AddScoped<IMatchAppService, MatchAppService>();
            services.AddScoped<ITrainingAppService, TrainingAppService>();

            #endregion

            #region Validators
            // Add Domain Validators
            services.AddScoped<IValidator<CreateInstitutionDTO>, InstitutionValidator>();
            services.AddScoped<IValidator<CreateUserDTO>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserDTO>, UpdateUserValidator>();
            services.AddScoped<IValidator<CreateUserPermissionsDTO>, CreateUserPermissionsValidator>();
            services.AddScoped<IValidator<UpdateUserPermissionsDTO>, UpdateUserPermissionsValidator>();
            services.AddScoped<IValidator<ResetPasswordDTO>, PasswordValidator>();

            services.AddScoped<IValidator<CreateClubMemberDTO>, CreateClubMemberValidator>();
            services.AddScoped<IValidator<UpdateClubMemberDTO>, UpdateClubMemberValidator>();
            services.AddScoped<IValidator<CreateMinorClubMemberDTO>, CreateMinorClubMemberValidator>();
            services.AddScoped<IValidator<UpdateMinorClubMemberDTO>, UpdateMinorClubMemberValidator>();
            services.AddScoped<IValidator<CreatePlayerTransferDTO>, CreatePlayerTransferValidator>();
            services.AddScoped<IValidator<UpdatePlayerTransferDTO>, UpdatePlayerTransferValidator>();
            services.AddScoped<IValidator<CreatePlayerContractDTO>, CreatePlayerContractValidator>();
            services.AddScoped<IValidator<UpdatePlayerContractDTO>, UpdatePlayerContractValidator>();
            services.AddScoped<IValidator<CreatePlayerPerformanceHistoryDTO>, CreatePlayerPerformanceHistoryValidator>();
            services.AddScoped<IValidator<UpdatePlayerPerformanceHistoryDTO>, UpdatePlayerPerformanceHistoryValidator>();
            services.AddScoped<IValidator<CreatePlayerDTO>, CreatePlayerValidator>();
            services.AddScoped<IValidator<UpdatePlayerDTO>, UpdatePlayerValidator>();
            services.AddScoped<IValidator<CreateResponsiblePlayerDTO>, CreateResponsiblePlayerValidator>();
            services.AddScoped<IValidator<UpdateResponsiblePlayerDTO>, UpdateResponsiblePlayerValidator>();
            services.AddScoped<IValidator<CreateTeamDTO>, CreateTeamValidator>();
            services.AddScoped<IValidator<UpdateTeamDTO>, UpdateTeamValidator>();

            services.AddScoped<IValidator<CreateFacilityDTO>, FacilityValidator>();
            services.AddScoped<IValidator<CreateFacilityReservationDTO>, FacilityReservationValidator>();
            services.AddScoped<IValidator<CreateMaintenanceRequestDTO>, FacilityMaintenanceRequestValidator>();

            services.AddScoped<IValidator<CreateMatchDTO>, MatchValidator>();
            services.AddScoped<IValidator<CreateMatchStatisticDTO>, MatchStatisticValidator>();
            services.AddScoped<IValidator<CreateTrainingSessionDTO>, TrainingSessionValidator>();
            services.AddScoped<IValidator<CreateTrainingAttendanceDTO>, TrainingAttendanceValidator>();

            services.AddScoped<IValidator<ExpenseDTO>, ExpenseValidator>();
            services.AddScoped<IValidator<RevenueDTO>, RevenueValidator>();
            services.AddScoped<IValidator<CreateEntityDTO>, EntityValidator>();
            #endregion

            #region Add Domain Services dependencies

            //Identity
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IUserService, UserService>();

            //TrainingCompetition
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<ITrainingService, TrainingService>();

            //MembersTeams
            services.AddScoped<IMembersService, MemberService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITeamService, TeamService>();

            //Infrastructures
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();

            //Financial
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IRevenueService, RevenueService>();

            #endregion

            // Add data access dependencies
            var sql_conn = configuration.GetConnectionString("DefaultDockerConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(sql_conn));

            // Add services to the container.
            services.AddControllers(options => 
            {
                options.Filters.Add<NotificationFilter>();
                options.Filters.Add<ModelErrorFilter>();
            });
        }
    }
}
