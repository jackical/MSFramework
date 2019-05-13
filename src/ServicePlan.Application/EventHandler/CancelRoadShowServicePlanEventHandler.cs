using System.Threading.Tasks;
using MSFramework.EventBus;
using ServicePlan.Application.Services;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Application.EventHandler
{
	public class RoadShowPlanCanceledEventHandler : IEventHandler<RoadShowPlanCanceledEvent>
	{
		private readonly IServicePlanAppService _servicePlanAppService;

		public RoadShowPlanCanceledEventHandler(IServicePlanAppService servicePlanAppService)
		{
			_servicePlanAppService = servicePlanAppService;
		}
		
		public async Task Handle(RoadShowPlanCanceledEvent @event)
		{
			await _servicePlanAppService.CancelRoadShowAsync(@event.PlanId);
		}
	}
}