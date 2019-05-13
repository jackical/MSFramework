using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFramework.AspNetCore;
using MSFramework.Domain;
using ServicePlan.Application.DTO;
using ServicePlan.Application.Services;

namespace ServicePlan.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class RoadShowController: MSFrameworkControllerBase
	{
		private readonly IRoadShowWeekSchedulerAppService _roadShowWeekSchedulerAppService;

		public RoadShowController(
			IRoadShowWeekSchedulerAppService roadShowWeekSchedulerAppService,
			IMSFrameworkSession session, ILogger<ServicePlanController> logger) : base(session, logger)
		{
			_roadShowWeekSchedulerAppService = roadShowWeekSchedulerAppService;
		}
		
		[HttpPost("create")]
		public async Task<IActionResult> CreateAsync([FromBody] CreateRoadShowWeekSchedulerDTO dto)
		{
			await _roadShowWeekSchedulerAppService.CreateAsync(dto);
			return Ok(true);
		}
		
		[HttpPost("{schedulerId}")]
		public async Task<IActionResult> CreateAppointmentAsync(Guid schedulerId,  [FromBody] CreateAppointmentDTO dto)
		{
			await _roadShowWeekSchedulerAppService.CreateAppointmentAsync(schedulerId, dto);
			return Ok(true);
		}
		
		[HttpDelete("{schedulerId}/{appointmentId}")]
		public async Task<IActionResult> DeleteAppointmentAsync(Guid schedulerId,  Guid appointmentId)
		{
			await _roadShowWeekSchedulerAppService.DeleteAppointmentAsync(schedulerId, appointmentId);
			return Ok(true);
		}
		
		[HttpPut("{schedulerId}/{appointmentId}/order")]
		public async Task<IActionResult> MakeAppointmentWithClientAsync(Guid schedulerId,  Guid appointmentId, [FromBody]MakeAppointmentDTO dto)
		{
			await _roadShowWeekSchedulerAppService.MakeAppointmentWithClientAsync(schedulerId, appointmentId, dto);
			return Ok(true);
		}
		
		[HttpPut("{schedulerId}/{appointmentId}/cancel")]
		public async Task<IActionResult> CancelAppointmentWithClientAsync(Guid schedulerId,  Guid appointmentId)
		{
			await _roadShowWeekSchedulerAppService.CancelAppointmentWithClientAsync(schedulerId, appointmentId);
			return Ok(true);
		}
		
		[HttpPut("{schedulerId}/set-topic")]
		public async Task<IActionResult> SetRoadShowTopicAsync(Guid schedulerId, [FromBody]string topic)
		{
			await _roadShowWeekSchedulerAppService.SetRoadShowTopicAsync(schedulerId, topic);
			return Ok(true);
		}
	}
}