using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFramework.AspNetCore;
using MSFramework.Domain;
using ServicePlan.API.Application.DTO;
using ServicePlan.API.Application.Services;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ServicePlanController : MSFrameworkControllerBase
	{
		private readonly IServicePlanAppService _servicePlanAppService;

		public ServicePlanController(
			IServicePlanAppService servicePlanAppService,
			IMSFrameworkSession session, ILogger<ServicePlanController> logger) : base(session, logger)
		{
			_servicePlanAppService = servicePlanAppService;			 
		}
		
		[HttpPost("Create")]
		public async Task<IActionResult> CreateServicePlan()
		{
			var user = new User(Guid.NewGuid(), "沈", "威", "金融科技", "金融科技", "jackical.shen@research.xbmail.com.cn");
			var creator = new User(Guid.NewGuid(), "孙", "李杰", "金融科技", "金融科技", "sunlijie.shen@research.xbmail.com.cn");
			var clientUsers = new List<ClientUser>
			{
				new ClientUser(Guid.NewGuid(), "沈", "威", Guid.NewGuid(), "金融科技", "金融科技")
			};

			await _servicePlanAppService.CreateRoadShowPlan(new CreateRoadShowPlanDTO(clientUsers, user, creator,
				"宝山区顾村公园", DateTime.Now, DateTime.Now.AddDays(7), Guid.NewGuid(), Guid.NewGuid()));

			return Ok(true);
		}
	}
}
