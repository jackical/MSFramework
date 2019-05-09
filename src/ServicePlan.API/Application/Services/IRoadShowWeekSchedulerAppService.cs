using System;
using System.Threading.Tasks;
using MSFramework.Application;

namespace ServicePlan.API.Application.Services
{
	public interface IRoadShowWeekSchedulerAppService : IApplicationService
	{
		Task RoadShowPlanCreatedAsync(Guid eventSchedulerId, Guid eventAppointmentId, Guid eventPlanId);
	}
}