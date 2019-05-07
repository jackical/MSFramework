using System.Threading.Tasks;
using MSFramework.EventBus;
using ServicePlan.API.Application.Services;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.EventHandler
{
	public class CancelRoadShowServicePlanEventHandler : IEventHandler<CancelRoadShowServicePlanEvent>
	{
		private readonly IServicePlanAppService _servicePlanAppService;

		public CancelRoadShowServicePlanEventHandler(IServicePlanAppService servicePlanAppService)
		{
			_servicePlanAppService = servicePlanAppService;
		}
		
		public async Task Handle(CancelRoadShowServicePlanEvent @event)
		{
			await _servicePlanAppService.CancelRoadShowServicePlan(@event.AppointmentId);
		}
	}
}