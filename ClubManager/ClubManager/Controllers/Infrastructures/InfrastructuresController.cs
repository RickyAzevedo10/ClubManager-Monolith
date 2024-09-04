using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class InfrastructuresController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;
        private readonly ModelErrorsContext _modelErrorsContext;

        public InfrastructuresController(NotificationContext notificationContext, ModelErrorsContext modelErrorsContext)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
        }


    }
}
