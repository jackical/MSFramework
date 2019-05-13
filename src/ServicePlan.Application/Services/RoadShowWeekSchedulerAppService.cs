using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework.Application;
using MSFramework.Data;
using MSFramework.Domain;
using MSFramework.EntityFrameworkCore.Repository;
using MSFramework.EventBus;
using ServicePlan.Application.DTO;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Application.Services
{
	public class RoadShowWeekSchedulerAppService : ApplicationServiceBase, IRoadShowWeekSchedulerAppService
	{
		private readonly EfRepository<RoadShowWeekScheduler, Guid> _repository;
		
		private readonly IEventBus _eventBus;
		
		public RoadShowWeekSchedulerAppService(IMSFrameworkSession session, 
			IEventBus eventBus,
			EfRepository<RoadShowWeekScheduler, Guid> repository, 
			ILogger<RoadShowWeekSchedulerAppService> logger) : base(session, logger)
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

		public async Task CreateAsync(CreateRoadShowWeekSchedulerDTO dto)
		{
			var weekScheduler = new RoadShowWeekScheduler(dto.User, dto.BeginTime, dto.EndTime);

			if (dto.Appointments != null)
			{
				foreach (var appointmentDto in dto.Appointments)
				{
					weekScheduler.AddAppointment(appointmentDto.Location, appointmentDto.BeginTime,
						appointmentDto.EndTime);
				}
			}

			await _repository.InsertAsync(weekScheduler);
		}

		public async Task CreateAppointmentAsync(Guid schedulerId, CreateAppointmentDTO dto)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));

			weekScheduler.AddAppointment(dto.Location, dto.BeginTime, dto.EndTime);
		}

		public async Task DeleteAppointmentAsync(Guid schedulerId, Guid appointmentId)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));
			
			weekScheduler.DeleteAppointment(appointmentId);
		}

		public async Task MakeAppointmentWithClientAsync(Guid schedulerId, Guid appointmentId, MakeAppointmentDTO dto)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));

			weekScheduler.MakeAppointWithClient(appointmentId, dto.Address, dto.Client, dto.ClientUsers, dto.Sale,
				dto.Description);
		}

		public async Task CancelAppointmentWithClientAsync(Guid schedulerId, Guid appointmentId)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));
			
			weekScheduler.CancelAppointWithClient(appointmentId);
		}

		public async Task SetRoadShowTopicAsync(Guid schedulerId, string topic)
		{
			var weekScheduler = await _repository.GetAsync(schedulerId);
			weekScheduler.NotNull(nameof(weekScheduler));
			
			weekScheduler.SetKeyIdeaAndTopic(topic);
		}
	}
}