using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework.Application;
using MSFramework.Data;
using MSFramework.Domain;
using MSFramework.EntityFrameworkCore.Repository;
using MSFramework.EventBus;
using ServicePlan.API.Application.DTO;
using ServicePlan.Domain.Services;
using ServicePlanAggregate = ServicePlan.Domain.AggregateRoot.ServicePlan;

namespace ServicePlan.API.Application.Services
{
	public class ServicePlanAppService : ApplicationServiceBase, IServicePlanAppService
	{
		private readonly EfRepository<ServicePlanAggregate, Guid> _repository;
		private readonly IEventBus _eventBus;

		public ServicePlanAppService(IMSFrameworkSession session, IEventBus eventBus,
			EfRepository<ServicePlanAggregate, Guid> repository,
			ILogger<ServicePlanService> logger) : base(session, logger)
		{
			_repository = repository;
			_eventBus = eventBus;
		}

		/// <summary>
		/// 创建路演计划
		/// </summary>
		/// <param name="dto">数据对象</param>
		/// <returns></returns>
		public async Task CreateRoadShowPlan(CreateRoadShowPlanDTO dto)
		{
			var roadShowPlan = new ServicePlanAggregate(dto.ClientUsers, dto.User, dto.Creator, "路演服务计划", dto.Address,
				dto.BeginTime, dto.EndTime);

			await _eventBus.PublishAsync(new RoadShowPlanCreatedEvent(dto.SchedulerId, dto.AppointmentId, roadShowPlan.Id));
			await _repository.InsertAsync(roadShowPlan);
		}

		/// <summary>
		/// 取消路演计划
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <returns></returns>
		public async Task CancelRoadShowServicePlan(Guid planId)
		{
			var roadShowPlan = await _repository.GetAsync(planId);
			roadShowPlan.NotNull(nameof(roadShowPlan));
			roadShowPlan.Delete();
		}
	}
}