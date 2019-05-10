using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFramework.AspNetCore;
using MSFramework.Domain;
using ServicePlan.API.Application.DTO;
using ServicePlan.API.Application.Services;

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
		public async Task<IActionResult> CreateAsync([FromBody] CreateServicePlanDTO dto)
		{
			//await _roadShowWeekSchedulerAppService.CreateAsync(dto);
			return Ok(true);
		}
	}
}