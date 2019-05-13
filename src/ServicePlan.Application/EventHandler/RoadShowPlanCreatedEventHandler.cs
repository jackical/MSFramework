using System.Threading.Tasks;
using MSFramework.EventBus;
using ServicePlan.Application.Services;

namespace ServicePlan.Application.EventHandler
{
	public class RoadShowPlanCreatedEventHandler : IEventHandler<RoadShowPlanCreatedEvent>
	{
		private readonly IRoadShowWeekSchedulerAppService _roadShowWeekSchedulerAppService;

		public RoadShowPlanCreatedEventHandler(IRoadShowWeekSchedulerAppService roadShowWeekSchedulerAppService)
		{
			_roadShowWeekSchedulerAppService = roadShowWeekSchedulerAppService;
		}

		public async Task Handle(RoadShowPlanCreatedEvent @event)
		{
			await _roadShowWeekSchedulerAppService.RoadShowPlanCreatedAsync(@event.SchedulerId, @event.AppointmentId,
				@event.PlanId);
		}
	}
}