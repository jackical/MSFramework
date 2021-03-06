using System;
using System.Collections.Generic;
using System.Linq;
using MSFramework.Data;
using MSFramework.Domain;
using ServicePlan.Domain.Services;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 服务计划
	/// </summary>
	public class ServicePlan : AggregateRootBase<ServicePlan, Guid>
	{
		/// <summary>
		/// 计划名称
		/// </summary>
		private string _name;

		/// <summary>
		/// 服务计划类型
		/// </summary>
		private ServicePlanType _planType;

		/// <summary>
		/// 提交状态
		/// </summary>
		private ServicePlanState _planState;

		/// <summary>
		/// 质量审核状态
		/// </summary>
		private ValidationState _validationState;

		/// <summary>
		/// 合规审核状态
		/// </summary>
		private AuditState _auditState;

		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime _beginTime;

		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime _endTime;

		/// <summary>
		/// 是否已删除
		/// </summary>
		private bool _deleted;

		/// <summary>
		/// 附件
		/// </summary>
		private readonly List<Attachment> _attachments = new List<Attachment>(0);

		/// <summary>
		/// 邮件发送记录
		/// </summary>
		private readonly List<EmailRecord> _emailRecords = new List<EmailRecord>(0);

		/// <summary>
		/// 服务记录
		/// </summary>
		private readonly List<ServiceRecord> _serviceRecords = new List<ServiceRecord>(0);

		/// <summary>
		/// 审核信息
		/// </summary>
		private readonly List<AuditHistory> _auditHistories = new List<AuditHistory>(0);

		/// <summary>
		/// 产品信息
		/// </summary>
		public string ProductId { get; private set; } = string.Empty;

		/// <summary>
		/// 路演信息
		/// </summary>
		public RoadShow RoadShow { get; private set; } = RoadShow.Empty();

		/// <summary>
		/// 数据报告信息
		/// </summary>
		public DataReport DataReport { get; private set; } = DataReport.Empty();

		/// <summary>
		/// 质量检测人
		/// </summary>
		public string QcUser { get; private set; } = string.Empty;

		/// <summary>
		/// 负责人
		/// </summary>
		public string User { get; private set; } = string.Empty;

		/// <summary>
		/// 创建人
		/// </summary>
		public string Creator { get; private set; } = string.Empty;

		/// <summary>
		/// 最后合规人
		/// </summary>
		public string AuditUser { get; private set; } = string.Empty;

		public IReadOnlyCollection<Attachment> Attachments => _attachments;

		public IReadOnlyCollection<EmailRecord> EmailRecords => _emailRecords;

		public IReadOnlyCollection<ServiceRecord> ServiceRecords => _serviceRecords;

		public IReadOnlyCollection<AuditHistory> AuditHistory => _auditHistories;

		private ServicePlan()
		{
		}

		/// <summary>
		/// 新建服务计划
		/// </summary>
		/// <param name="productId">产品标识</param>
		/// <param name="name">计划名称</param>
		/// <param name="planType">计划类型</param>
		/// <param name="user">用户信息</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public ServicePlan(string productId, ServicePlanType planType, string user, string name,
			DateTime beginTime, DateTime endTime)
		{
			ApplyChangedEvent(new CreateServicePlanEvent(productId, planType, user, name, beginTime, endTime));
		}

		/// <summary>
		/// 路演预约产生的服务计划
		/// </summary>
		/// <param name="clientUsers">客户联系人</param>
		/// <param name="creator">创建人</param>
		/// <param name="name">计划名称</param>
		/// <param name="address">地址</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <param name="user">用户</param>
		public ServicePlan(List<ClientUser> clientUsers, string user, string creator, string name,
			string address, DateTime beginTime, DateTime endTime)
		{
			ApplyChangedEvent(new CreateRoadShowPlanEvent(clientUsers, user, creator, name, address,
				beginTime, endTime));
		}

		/// <summary>
		/// 删除服务计划（仅限待提交）
		/// </summary>
		public void Delete()
		{
			ApplyChangedEvent(new DeleteServicePlanEvent());
		}

		/// <summary>
		/// 提交服务计划
		/// </summary>
		public void Submit()
		{
			ApplyChangedEvent(new SubmitPlanEvent());
		}

		/// <summary>
		/// 设置标题和摘要（仅数据产品）
		/// </summary>
		/// <param name="title">标题</param>
		/// <param name="abstract">摘要</param>
		public void SetTitleAndAbstract(string title, string @abstract)
		{
			ApplyChangedEvent(new SetTitleAndAbstractEvent(title, @abstract));
		}

		/// <summary>
		/// 上传文件
		/// </summary>
		/// <param name="uploadAttachments">附件信息</param>
		public void UploadFiles(List<Attachment> uploadAttachments)
		{
			ApplyChangedEvent(new UploadAttachmentsEvent(uploadAttachments));
		}

		/// <summary>
		/// 提交审核
		/// </summary>
		/// <param name="user">用户</param>
		public void SubmitAudit(string user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new SubmitAuditEvent(user));
		}

		/// <summary>
		/// 质量审核通过
		/// </summary>
		/// <param name="user">审核人</param>
		public void QcVerifySuccess(string user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new QcVerifySuccessEvent(user));
		}

		/// <summary>
		/// 质量审核失败
		/// </summary>
		/// <param name="user">审核人</param>
		public void QcVerifyFailed(string user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new QcVerifyFailedEvent(user));
		}

		/// <summary>
		/// 合规审核通过
		/// </summary>
		/// <param name="user">审核人</param>
		public void AuditSuccess(string user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new AuditSuccessEvent(user));
		}

		/// <summary>
		/// 合规审核失败
		/// </summary>
		/// <param name="user">审核人</param>
		public void AuditFailed(string user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new AuditFailedEvent(user));
		}

		/// <summary>
		/// 发送报告给客户（限数据产品）
		/// </summary>
		/// <param name="clientUsers">客户联系人</param>
		public void SendEmail(List<ClientUser> clientUsers)
		{
			clientUsers.NotNull(nameof(clientUsers));

			ApplyChangedEvent(new SendEmailEvent(clientUsers, DateTime.Now));
		}

		public void SetEmailSentSuccess(Guid identity)
		{
			identity.NotNull(nameof(identity));

			ApplyChangedEvent(new SetEmailSentSuccessEvent(identity, DateTime.Now));
		}

		public void SetEmailSentFailed(Guid identity)
		{
			identity.NotNull(nameof(identity));

			ApplyChangedEvent(new SetEmailSentFailedEvent(identity, DateTime.Now));
		}

		/// <summary>
		/// 置服务计划完成
		/// </summary>
		public void Complete(string subject, string industryId)
		{
			ApplyChangedEvent(new CompletePlanEvent(subject, industryId));
		}

		/// <summary>
		/// 添加服务记录
		/// </summary>
		/// <param name="serviceRecord">服务记录对象</param>
		public void CreateServiceRecord(ServiceRecord serviceRecord)
		{
			ApplyChangedEvent(new CreateServiceRecordEvent(serviceRecord));
		}

		/// <summary>
		/// 修改联系人,（仅限路演）
		/// 服务计划完成之后可修改客户联系人
		/// </summary>
		public void SetClientUsers(Guid serviceRecordId, List<ClientUser> clientUsers)
		{
			ApplyChangedEvent(new SetClientUsersEvent(serviceRecordId, clientUsers));
		}

		/// <summary>
		/// 设置打分和服务反馈信息
		/// </summary>
		/// <param name="serviceRecordId">服务记录标识</param>
		/// <param name="score">打分</param>
		/// <param name="feedback">反馈信息</param>
		public void SetScore(Guid serviceRecordId, int score, string feedback)
		{
			ApplyChangedEvent(new SetScoreEvent(serviceRecordId, score, feedback));
		}

		/// <summary>
		/// 设置服务反馈信息
		/// </summary>
		/// <param name="serviceRecordId">服务记录标识</param>
		/// <param name="clientFocusKeyPoint">客户关注点</param>
		/// <param name="continue">是否继续</param>
		/// <param name="modificationRequirement">更改需求</param>
		/// <param name="newRequirement">新需求</param>
		public void SetServiceRecordInfo(Guid serviceRecordId, string clientFocusKeyPoint, bool @continue,
			string modificationRequirement, string newRequirement)
		{
			ApplyChangedEvent(new SetServiceRecordInfoEvent(serviceRecordId, clientFocusKeyPoint, @continue,
				modificationRequirement, newRequirement));
		}

		private void Apply(CreateServicePlanEvent @event)
		{
			ProductId = @event.ProductId;
			_name = @event.Name;
			_beginTime = @event.BeginTime;
			_endTime = @event.EndTime;
			User = @event.User;
			_planType = @event.PlanType;
			_planState = ServicePlanState.AwaitingSubmit;
		}

		private void Apply(CreateRoadShowPlanEvent @event)
		{
			_name = @event.Name;
			_beginTime = @event.BeginTime;
			_endTime = @event.EndTime;

			_planState = ServicePlanState.Submitted;
			_planType = ServicePlanType.RoadShow;
			Creator = @event.CreatorUser;
			User = @event.User;
			RoadShow = new RoadShow(@event.ClientUsers, @event.Address);
		}

		private void Apply(DeleteServicePlanEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingSubmit)
			{
				throw new ServicePlanException("服务计划已提交，无法删除");
			}

			_deleted = true;
		}

		private void Apply(SubmitPlanEvent @event)
		{
			if (_deleted)
			{
				throw new ServicePlanException("服务计划已删除或不存在");
			}

			if (_planState != ServicePlanState.AwaitingSubmit)
			{
				throw new ServicePlanException("服务计划已提交");
			}

			_planState = ServicePlanState.Submitted;
		}

		private void Apply(SetTitleAndAbstractEvent @event)
		{
			if (_planType != ServicePlanType.Data)
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			DataReport = new DataReport(@event.Title, @event.Abstract);
		}

		private void Apply(SubmitAuditEvent @event)
		{
			if (_planType != ServicePlanType.Data)
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			if (string.IsNullOrWhiteSpace(DataReport.Abstract) ||
			    string.IsNullOrWhiteSpace(DataReport.ReportTitle))
			{
				throw new ServicePlanException("未设置报告摘要或标题");
			}

			if (_planState == ServicePlanState.Submitted || _planState == ServicePlanState.AwaitingAudit &&
			    (_auditState == AuditState.Dismissed ||
			     _validationState == ValidationState.Dismissed))
			{
				_planState = ServicePlanState.AwaitingAudit;
				_auditState = AuditState.AwaitingValidation;
				_validationState = ValidationState.AwaitingValidation;

				_auditHistories.Add(new AuditHistory(@event.User, "submit", "success"));
			}
			else
			{
				throw new ServicePlanException("状态不正确");
			}
		}

		private void Apply(QcVerifySuccessEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingAudit)
			{
				throw new ServicePlanException("尚未提交审核");
			}

			QcUser = @event.User;
			_validationState = ValidationState.Confirmed;
			if (_auditState == AuditState.Confirmed)
			{
				_planState = ServicePlanState.AwaitingComplete;
			}

			_auditHistories.Add(new AuditHistory(@event.User, "qc", "success"));
		}

		private void Apply(QcVerifyFailedEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingAudit)
			{
				throw new ServicePlanException("尚未提交审核");
			}

			QcUser = @event.User;
			_validationState = ValidationState.Dismissed;
			_auditHistories.Add(new AuditHistory(@event.User, "qc", "failed"));
		}

		private void Apply(AuditSuccessEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingAudit)
			{
				throw new ServicePlanException("尚未提交审核");
			}

			_validationState = ValidationState.Confirmed;
			AuditUser = @event.User;
			if (_validationState == ValidationState.Confirmed)
			{
				_planState = ServicePlanState.AwaitingComplete;
			}

			_auditHistories.Add(new AuditHistory(@event.User, "audit", "success"));
		}

		private void Apply(AuditFailedEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingAudit)
			{
				throw new ServicePlanException("尚未提交审核");
			}

			AuditUser = @event.User;
			_validationState = ValidationState.Dismissed;
			_auditHistories.Add(new AuditHistory(@event.User, "audit", "failed"));
		}

		private void Apply(SendEmailEvent @event)
		{
			if (_planType != ServicePlanType.Data)
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			var notifiers = new List<Guid>();
			var clientUsers = @event.ClientUsers;
			foreach (var clientUser in clientUsers)
			{
				var recordId = Guid.NewGuid();
				_emailRecords.Add(new EmailRecord(clientUser, @event.CreationTime, recordId));
				notifiers.Add(recordId);
			}

			//todo 根据模板生成邮件内容，创建发送邮件领域事件
		}

		private void Apply(SetEmailSentSuccessEvent @event)
		{
			var record = _emailRecords.FirstOrDefault(a => a.Id == @event.Identity);
			if (record == null)
			{
				throw new ServicePlanException($"未找到标识为 {@event.Identity} 的邮件记录");
			}

			record.SetSuccess(@event.ResponseTime);
		}

		private void Apply(SetEmailSentFailedEvent @event)
		{
			var record = _emailRecords.FirstOrDefault(a => a.Id == @event.Identity);
			if (record == null)
			{
				throw new ServicePlanException($"未找到标识为 {@event.Identity} 的邮件记录");
			}

			record.SetFailed(@event.ResponseTime);
		}

		private void Apply(CompletePlanEvent @event)
		{
			if (_planState != ServicePlanState.AwaitingComplete)
			{
				throw new ServicePlanException("状态不正确");
			}

			switch (_planType)
			{
				case ServicePlanType.Data:
				{
					var records = _emailRecords.Where(a => a.Success == true).GroupBy(a => a.ClientUser)
						.Select(a => a.First()).ToArray();

					if (!records.Any())
					{
						throw new ServicePlanException("未发送邮件");
					}

					foreach (var record in records)
					{
						_serviceRecords.Add(new ServiceRecord(record.ResponseTime.Value, _planType, @event.Subject,
							@event.IndustryId, new List<ClientUser> {record.ClientUser}));
					}

					break;
				}
				case ServicePlanType.RoadShow:
				case ServicePlanType.Survey:
				case ServicePlanType.Tel:
				case ServicePlanType.Conference:
					_serviceRecords.Add(new ServiceRecord(_beginTime, _planType, @event.Subject, @event.IndustryId,
						RoadShow.ClientUsers.ToList()));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_planState = ServicePlanState.Complete;
		}

		private void Apply(UploadAttachmentsEvent @event)
		{
			_attachments.AddRange(@event.Attachments);
		}

		private void Apply(SetScoreEvent @event)
		{
			if (_planState != ServicePlanState.Complete)
			{
				throw new ServicePlanException("状态不正确");
			}

			var serviceRecord = _serviceRecords.FirstOrDefault(a => a.Id == @event.ServiceRecordId);
			serviceRecord.NotNull(nameof(serviceRecord));
			serviceRecord.SetScore(@event.Score, @event.Feedback);
		}

		private void Apply(SetServiceRecordInfoEvent @event)
		{
			if (_planState != ServicePlanState.Complete)
			{
				throw new ServicePlanException("状态不正确");
			}

			var serviceRecord = _serviceRecords.FirstOrDefault(a => a.Id == @event.ServiceRecordId);
			serviceRecord.NotNull(nameof(serviceRecord));
			serviceRecord.SetInfo(@event.ClientFocusKeyPoint, @event.Continue,
				@event.ModificationRequirement, @event.NewRequest);
		}

		private void Apply(SetClientUsersEvent @event)
		{
			if (_planState != ServicePlanState.Complete)
			{
				throw new ServicePlanException("状态不正确");
			}

			if (!_planType.Equals(ServicePlanType.RoadShow))
			{
				throw new ServicePlanException("只有路演计划才能更改客户联系人");
			}

			var serviceRecord = _serviceRecords.FirstOrDefault(a => a.Id == @event.ServiceRecordId);
			serviceRecord.NotNull(nameof(serviceRecord));
			serviceRecord.SetClientUsers(@event.ClientUsers);
		}

		private void Apply(CreateServiceRecordEvent @event)
		{
			if (_planState != ServicePlanState.Complete)
			{
				throw new ServicePlanException("状态不正确");
			}
			
			_serviceRecords.Add(@event.ServiceRecord);
		}
	}
}