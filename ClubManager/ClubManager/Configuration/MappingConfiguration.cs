using AutoMapper;
using ClubManager.Application.Mappings;

namespace ClubManager.API.Configuration
{
    public static class MappingConfiguration
    {
        public static void AddMappingConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new IdentityMappingProfile());
                mc.AddProfile(new FinancialMappingProfile());
                mc.AddProfile(new InfrastructuresMappingProfile());
                mc.AddProfile(new TrainingCompetitionMappingProfile());
                mc.AddProfile(new MembersTeamsMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}