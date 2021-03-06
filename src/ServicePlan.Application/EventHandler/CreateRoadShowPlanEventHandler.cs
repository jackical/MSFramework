using System.Threading.Tasks;
using MSFramework.EventBus;
using ServicePlan.Application.DTO;
using ServicePlan.Application.Services;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Application.EventHandler
{
	public class CreateRoadShowPlanEventHandler : IEventHandler<CreateRoadShowServicePlanEvent>
	{
		private readonly IServicePlanAppService _servicePlanAppService;

		public CreateRoadShowPlanEventHandler(IServicePlanAppService servicePlanAppService)
		{
			_servicePlanAppService = servicePlanAppService;
		}
		
		public async Task Handle(CreateRoadShowServicePlanEvent @event)
		{
			var dto = new CreateRoadShowPlanDTO(@event.ClientUsers, @event.User, @event.CreatorUser, @event.Address,
				@event.BeginTime, @event.EndTime, @event.SchedulerId, @event.AppointmentId);

			await _servicePlanAppService.CreateRoadShowAsync(dto);
		}
	}
}