using ClubManager.App.Interfaces.Identity;
using ClubManager.Domain.DTOs.TrainingCompetition;
using ClubManager.Domain.Entities.TrainingCompetition;
using ClubManager.Domain.Services;
using ClubManager.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Controllers.MembersTeams
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;
        private readonly ModelErrorsContext _modelErrorsContext;
        private readonly ITrainingAppService _trainingAppService;

        public TrainingController(NotificationContext notificationContext, ModelErrorsContext modelErrorsContext, ITrainingAppService trainingAppService)
        {
            _notificationContext = notificationContext;
            _modelErrorsContext = modelErrorsContext;
            _trainingAppService = trainingAppService;
        }

        #region TrainingSession
        /// <summary>
        /// create TrainingSession
        /// </summary>
        /// <param name="trainingSessionBody"></param>
        /// <returns></returns>
        [HttpPost("TrainingSession")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PostTrainingSession(CreateTrainingSessionDTO trainingSessionBody)
        {
            TrainingSession? response = await _trainingAppService.CreateTrainingSession(trainingSessionBody);
            return DomainResult<TrainingSession?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update TrainingSession
        /// </summary>
        /// <param name="trainingSessionToUpdate"></param>
        /// <returns></returns>
        [HttpPut("TrainingSession")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PutTrainingSession(UpdateTrainingSessionDTO trainingSessionToUpdate)
        {
            TrainingSession? response = await _trainingAppService.UpdateTrainingSession(trainingSessionToUpdate);
            return DomainResult<TrainingSession?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete TrainingSession
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("TrainingSession")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> DeleteTrainingSession(long id)
        {
            TrainingSession? response = await _trainingAppService.DeleteTrainingSession(id);
            return DomainResult<TrainingSession?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get TrainingSession
        /// </summary>
        /// <param name="trainingSessionId"></param>
        /// <returns></returns>
        [HttpGet("TrainingSession")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetTrainingSession(long trainingSessionId)
        {
            TrainingSession? response = await _trainingAppService.GetTrainingSession(trainingSessionId);
            return DomainResult<TrainingSession?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get TrainingSession from a date interval
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("TrainingSession")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetTrainingSessionsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<TrainingSession>? response = await _trainingAppService.GetTrainingSessionsByDateRange(startDate, endDate);
            return DomainResult<List<TrainingSession>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        #endregion


        #region TrainingAttendance
        /// <summary>
        /// create TrainingAttendance
        /// </summary>
        /// <param name="trainingAttendanceBody"></param>
        /// <returns></returns>
        [HttpPost("TrainingAttendance")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PostTrainingAttendance(CreateTrainingAttendanceDTO trainingAttendanceBody)
        {
            TrainingAttendance? response = await _trainingAppService.CreateTrainingAttendance(trainingAttendanceBody);
            return DomainResult<TrainingAttendance?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// update TrainingAttendance
        /// </summary>
        /// <param name="trainingAttendanceToUpdate"></param>
        /// <returns></returns>
        [HttpPut("TrainingAttendance")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> PutTrainingAttendance(UpdateTrainingAttendanceDTO trainingAttendanceToUpdate)
        {
            TrainingAttendance? response = await _trainingAppService.UpdateTrainingAttendance(trainingAttendanceToUpdate);
            return DomainResult<TrainingAttendance?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// delete TrainingAttendance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("TrainingAttendance")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> DeleteTrainingAttendance(long id)
        {
            TrainingAttendance? response = await _trainingAppService.DeleteTrainingAttendance(id);
            return DomainResult<TrainingAttendance?>.Ok(response, _notificationContext, _modelErrorsContext);
        }

        /// <summary>
        /// get all player attendance
        /// </summary>
        /// <param name="trainingAttendanceId"></param>
        /// <returns></returns>
        [HttpGet("TrainingAttendance")]
        [Authorize(Roles = "Admin,Presidente,Treinador")]
        public async Task<IActionResult> GetTrainingAttendance(long trainingAttendanceId)
        {
            List<TrainingAttendance>? response = await _trainingAppService.GetTrainingAttendance(trainingAttendanceId);
            return DomainResult<List<TrainingAttendance>?>.Ok(response, _notificationContext, _modelErrorsContext);
        }
        #endregion

    }
}
