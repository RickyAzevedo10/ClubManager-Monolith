using ClubManager.App.Interfaces.Identity;
using ClubManager.App.Interfaces.Infrastructure;
using ClubManager.App.Services.Identity;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.DTOs.Infrastructures;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.Identity;
using ClubManager.Domain.Entities.Identity.Validators;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Interfaces.Identity;
using ClubManager.Domain.Interfaces.Repositories;
using ClubManager.Domain.Services;
using ClubManager.Domain.Services.Identity;
using ClubManager.Infra.Contexts;
using ClubManager.Infra.Persistence;
using ClubManager.Infra.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MSAuth.API.ActionFilters;
using MSAuth.Domain.Services;

namespace ClubManager.Ioc
{
    public static class DIConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            //Add notification context
            services.AddScoped<INotificationContext, NotificationContext>();

            // Add Model Errors
            services.AddScoped<IModelErrorsContext, ModelErrorsContext>();

            // Add UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add App Services dependencies
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IInstitutionAppService, InstitutionAppService>();

            //Add Infra Services dependencies
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IUserClaimsService, UserClaimsService>();

            // Add Domain Services dependencies
            services.AddScoped<EntityValidationService>();
            services.AddScoped<IInstitutionService, InstitutionService>();

            // Add Domain Validators
            services.AddScoped<IValidator<Institution>, InstitutionValidator>();
            services.AddScoped<IValidator<CreateUserDTO>, CreateUserValidator>();
            services.AddScoped<IValidator<CreateUserPermissionsDTO>, CreateUserPermissionsValidator>();
            services.AddScoped<IValidator<UpdateUserPermissionsDTO>, UpdateUserPermissionsValidator>();

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

            // Add data access dependencies
            var sql_conn = configuration.GetConnectionString("DefaultConnection");
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
