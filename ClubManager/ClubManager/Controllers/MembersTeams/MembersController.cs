using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.MembersTeams;
using ClubManager.Domain.Entities.MembersTeams;
using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;
        private readonly IModelErrorsContext _modelErrorsContext;
        private readonly IMembersAppService _membersAppService;

        public MembersController(INotificationContext notificationContext, IModelErrorsContext modelErrorsContext, IMembersAppService membersAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _membersAppService = membersAppService;
        }

        #region Members
        /// <summary>
        /// adding member
        /// </summary>
        /// <param name="memberBody"></param>
        /// <returns></returns>
        [HttpPost("Members")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> Post(CreateClubMemberDTO memberBody)
        {
            ClubMember? response = await _membersAppService.Create(memberBody);
            return DomainResult<ClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Members")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> Delete(long id)
        {
            ClubMember? response = await _membersAppService.Delete(id);
            return DomainResult<ClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get member with search method
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("MembersSearch")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> SearchClubMembers([FromQuery] string? firstName, [FromQuery] string? lastName)
        {
            List<ClubMember>? response = await _membersAppService.SearchClubMembersAsync(firstName, lastName);
            return DomainResult<List<ClubMember>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all member
        /// </summary>
        /// <returns></returns>
        [HttpGet("Members")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetAllClubMembers()
        {
            List<ClubMember>? response = await _membersAppService.GetAllClubMembers();
            return DomainResult<List<ClubMember>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update member
        /// </summary>
        /// <param name="memberToUpdate"></param>
        /// <returns></returns>
        [HttpPut("Members")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> Put(UpdateClubMemberDTO memberToUpdate)
        {
            ClubMember? response = await _membersAppService.Update(memberToUpdate);
            return DomainResult<ClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion

        #region Minor Member
        /// <summary>
        /// adding minor member
        /// </summary>
        /// <param name="memberBody"></param>
        /// <returns></returns>
        [HttpPost("MinorMembers")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PostMinorMembers(CreateMinorClubMemberDTO memberBody)
        {
            MinorClubMember? response = await _membersAppService.CreateMinorClubMembers(memberBody);
            return DomainResult<MinorClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update minor member
        /// </summary>
        /// <param name="minorMemberToUpdate"></param>
        /// <returns></returns>
        [HttpPut("MinorMembers")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> PutMinorMembers(UpdateMinorClubMemberDTO minorMemberToUpdate)
        {
            MinorClubMember? response = await _membersAppService.UpdateMinorMembers(minorMemberToUpdate);
            return DomainResult<MinorClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get minor member with search method
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("MinorMembersSearch")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> SearchMinorMembers([FromQuery] string? firstName, [FromQuery] string? lastName)
        {
            List<MinorClubMember>? response = await _membersAppService.SearchMinorMembersAsync(firstName, lastName);
            return DomainResult<List<MinorClubMember>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all minor member
        /// </summary>
        /// <returns></returns>
        [HttpGet("MinorMembers")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> GetAllMinorClubMembers()
        {
            List<MinorClubMember>? response = await _membersAppService.GetAllMinorClubMembers();
            return DomainResult<List<MinorClubMember>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete minor member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("MinorMembers")]
        [Authorize(Roles = "Admin,Presidente,Diretor Desportivo,Secretário")]
        public async Task<IActionResult> DeleteMinorClubMembers(long id)
        {
            MinorClubMember? response = await _membersAppService.DeleteMinorClubMember(id);
            return DomainResult<MinorClubMember?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion
    }
}
