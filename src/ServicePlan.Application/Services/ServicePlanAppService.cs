using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework;
using MSFramework.Application;
using MSFramework.Data;
using MSFramework.Domain;
using MSFramework.EntityFrameworkCore.Repository;
using MSFramework.EventBus;
using ServicePlan.API.Application.DTO;
using ServicePlan.Domain.AggregateRoot;
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
		public async Task CreateRoadShowAsync(CreateRoadShowPlanDTO dto)
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
		public async Task CancelRoadShowAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}
			
			plan.Delete();
		}

		/// <summary>
		/// 创建服务计划
		/// </summary>
		/// <param name="dto">数据对象</param>
		/// <returns></returns>
		public async Task CreateAsync(CreateServicePlanDTO dto)
		{
			var plan = new ServicePlanAggregate(dto.ProductId, dto.PlanType, dto.User, dto.PlanName, dto.BeginTime, dto.EndTime);
			
			//TODO 是否需要发送消息？
			
			await _repository.InsertAsync(plan);
		}

		/// <summary>
		/// 提交服务计划
		/// </summary>
		/// <returns></returns>
		public async Task SubmitAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}
			
			plan.Submit();
		}

		/// <summary>
		/// 删除服务计划
		/// </summary>
		/// <param name="planId"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}
			
			plan.Delete();
		}

		/// <summary>
		/// 上传附件
		/// </summary>
		/// <param name="planId">服务计划标识</param>
		/// <param name="attachments">附件信息</param>
		/// <returns></returns>
		public async Task UploadAttachmentsAsync(Guid planId, List<AttachmentDTO> attachments)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}

			var files = new List<Attachment>();
			foreach (var attach in attachments)
			{
				files.Add(new Attachment((AttachmentType) Enum.Parse(typeof(AttachmentType), attach.Type), attach.Name,
					attach.Path, DateTime.Now));
			}

			plan.UploadFiles(files);
		}

		/// <summary>
		/// 质量审核通过
		/// </summary>
		/// <param name="planId">计划编号</param>
		/// <returns></returns>
		public async Task QcSuccessAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			plan.QcVerifySuccess(Session.UserId);
		}
		
		/// <summary>
		/// 质量审核失败
		/// </summary>
		/// <param name="planId">计划编号</param>
		/// <returns></returns>
		public async Task QcFailedAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			plan.QcVerifyFailed(Session.UserId);
		}
		
		/// <summary>
		/// 合规审核通过
		/// </summary>
		/// <param name="planId">计划编号</param>
		/// <returns></returns>
		public async Task AuditSuccessAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			plan.AuditSuccess(Session.UserId);
		}
		
		/// <summary>
		/// 合规审核失败
		/// </summary>
		/// <param name="planId">计划编号</param>
		/// <returns></returns>
		public async Task AuditFailedAsync(Guid planId)
		{
			var plan = await GetPlanAsync(planId);
			
			plan.AuditFailed(Session.UserId);
		}

		/// <summary>
		/// 发送邮件给客户
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <param name="clientUsers">客户联系人信息</param>
		/// <returns></returns>
		public async Task SendEmailAsync(Guid planId, List<ClientUser> clientUsers)
		{
			var plan = await GetPlanAsync(planId);
			
			plan.SendEmail(clientUsers);
		}

		/// <summary>
		/// 置服务计划完成
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <param name="dto">数据对象</param>
		/// <returns></returns>
		/// <exception cref="MSFrameworkException"></exception>
		public async Task SetComplete(Guid planId, CompletePlanDTO dto)
		{
			dto.NotNull(nameof(dto));
			dto.Subject.NotNull(nameof(dto.Subject));
			dto.IndustryId.NotNull(nameof(dto.IndustryId));
			
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}
			
			plan.Complete(dto.Subject, dto.IndustryId);
		}

		/// <summary>
		/// 设置服务记录联系人
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <param name="serviceRecordId">服务记录标识</param>
		/// <param name="clientUsers">客户联系人</param>
		/// <returns></returns>
		/// <exception cref="MSFrameworkException"></exception>
		public async Task SetServiceRecordUsersAsync(Guid planId, Guid serviceRecordId, List<ClientUser> clientUsers)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}
			
			plan.SetClientUsers(serviceRecordId, clientUsers);
		}

		/// <summary>
		/// 设置服务记录信息
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <param name="serviceRecordId">服务记录标识</param>
		/// <param name="dto">数据对象</param>
		/// <returns></returns>
		/// <exception cref="MSFrameworkException"></exception>
		public async Task SetServiceRecordInfoAsync(Guid planId, Guid serviceRecordId, ServiceRecordInfoDTO dto)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}

			plan.SetServiceRecordInfo(serviceRecordId, dto.ModificationRequirement, dto.Continue,
				dto.ModificationRequirement, dto.NewRequest);
		}

		/// <summary>
		/// 设置打分反馈
		/// </summary>
		/// <param name="planId">计划标识</param>
		/// <param name="serviceRecordId">服务记录标识</param>
		/// <param name="dto">数据对象</param>
		/// <returns></returns>
		public async Task SetScoreAndFeedbackAsync(Guid planId, Guid serviceRecordId, ServiceRecordScoreTDO dto)
		{
			dto.NotNull(nameof(dto));
			
			var plan = await GetPlanAsync(planId);
			
			plan.SetScore(serviceRecordId, dto.Score, dto.Feedback);
		}

		/// <summary>
		/// 创建服务记录
		/// </summary>
		/// <param name="planId">服务计划标识</param>
		/// <param name="dto">记录信息</param>
		/// <returns></returns>
		/// <exception cref="MSFrameworkException"></exception>
		public async Task CreateServiceRecordAsync(Guid planId, CreateServiceRecordDTO dto)
		{
			var plan = await GetPlanAsync(planId);
			
			if (plan.User != Session.UserId)
			{
				throw new MSFrameworkException("无权限操作");
			}

			var serviceRecord = new ServiceRecord(dto.ServiceTime, dto.ServicePlanType, dto.Subject, dto.IndustryId,
				dto.ClientUsers);
			
			serviceRecord.SetScore(dto.Score, dto.Feedback);
			serviceRecord.SetInfo(dto.ClientFocusKeyPoint, dto.Continue, dto.ModificationRequirement,
				dto.NewRequirement);
			plan.CreateServiceRecord(serviceRecord);
		}

		private async Task<ServicePlanAggregate> GetPlanAsync(Guid planId)
		{
			var plan = await _repository.GetAsync(planId);
			plan.NotNull(nameof(plan));
			
			return plan;
		}
	}
}