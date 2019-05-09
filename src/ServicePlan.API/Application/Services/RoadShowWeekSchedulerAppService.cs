using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework.Application;
using MSFramework.Data;
using MSFramework.Domain;
using MSFramework.EntityFrameworkCore.Repository;
using MSFramework.EventBus;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.Services
{
	public class RoadShowWeekSchedulerAppService : ApplicationServiceBase, IRoadShowWeekSchedulerAppService
	{
		private readonly EfRepository<RoadShowWeekScheduler, Guid> _repository;
		private readonly IEventBus _eventBus;
		
		protected RoadShowWeekSchedulerAppService(IMSFrameworkSession session, 
			EfRepository<RoadShowWeekScheduler, Guid> repository, 
			IEventBus eventBus,
			ILogger logger) : base(session, logger)
		{
			_repository = repository;
			_eventBus = eventBus;
		}

		public async Task RoadShowPlanCreatedAsync(Guid schedulerId, Guid appointmentId, Guid planId)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));
			
			weekScheduler.RoadShowPlanCreated(appointmentId, planId);
		}
	}
}