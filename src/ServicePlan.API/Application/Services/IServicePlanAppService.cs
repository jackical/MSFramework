using System;
using System.Threading.Tasks;
using MSFramework.Application;
using ServicePlan.API.Application.DTO;

namespace ServicePlan.API.Application.Services
{
	public interface IServicePlanAppService : IApplicationService
	{
		Task CreateRoadShowPlan(CreateRoadShowPlanDTO dto);
		Task CancelRoadShowServicePlan(Guid planId);
	}
}