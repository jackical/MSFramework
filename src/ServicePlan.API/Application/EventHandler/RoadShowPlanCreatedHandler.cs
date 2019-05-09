using System.Threading.Tasks;
using MSFramework.EventBus;
using ServicePlan.API.Application.Services;

namespace ServicePlan.API.Application.EventHandler
{
	public class RoadShowPlanCreatedHandler : IEventHandler<RoadShowPlanCreatedEvent>
	{
		private readonly IRoadShowWeekSchedulerAppService _roadShowWeekSchedulerAppService;

		public RoadShowPlanCreatedHandler(IRoadShowWeekSchedulerAppService roadShowWeekSchedulerAppService)
		{
			_roadShowWeekSchedulerAppService = roadShowWeekSchedulerAppService;
		}

		public async Task Handle(RoadShowPlanCreatedEvent @event)
		{
			await _roadShowWeekSchedulerAppService.RoadShowPlanCreatedAsync(@event.SchedulerId, @event.AppointmentId, @event.PlanId);
		}
	}
}