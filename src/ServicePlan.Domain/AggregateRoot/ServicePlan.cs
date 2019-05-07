using System;
using System.Collections.Generic;
using System.Linq;
using MSFramework.Data;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	//todo ProductSubscriberChangedEventHandler
	/// <summary>
	/// 服务计划
	/// </summary>
	public class ServicePlan : AggregateRootBase<ServicePlan, Guid>
	{
		/// <summary>
		/// 产品
		/// </summary>
		private Product _product;

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
		/// 最后质量审核人
		/// </summary>
		private User _qcUser;

		/// <summary>
		/// 最后合规人
		/// </summary>
		private User _auditUser;
		
		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime _beginTime;

		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime _endTime;

		/// <summary>
		/// 负责人， 服务计划的团队以负责人为准
		/// </summary>
		private User _user;
		
		/// <summary>
		/// 创建人
		/// </summary>
		private User _creator;

		/// <summary>
		/// 路演实体
		/// </summary>
		private RoadShow _roadShow;

		/// <summary>
		/// 数据报告实体
		/// </summary>
		private DataReport _dataReport;

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
		/// 新建服务计划
		/// </summary>
		/// <param name="product">产品</param>
		/// <param name="name">计划名称</param>
		/// <param name="user">用户信息</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public ServicePlan(Product product, User user, string name,
			DateTime beginTime, DateTime endTime)
		{
			ApplyChangedEvent(new CreateServicePlanEvent(product, user, name, beginTime, endTime));
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
		/// <param name="ownerId">所属标识</param>
		/// <param name="user">用户</param>
		public ServicePlan(List<ClientUser> clientUsers, User user, User creator, string name,
			string address, DateTime beginTime, DateTime endTime, Guid ownerId)
		{
			ApplyChangedEvent(new CreateRoadShowPlanEvent(clientUsers, user, creator, name, address,
				beginTime, endTime, ownerId));
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
		public void SubmitAudit(User user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new SubmitAuditEvent(user));
		}

		/// <summary>
		/// 质量审核通过
		/// </summary>
		/// <param name="user">审核人</param>
		public void QcVerifySuccess(User user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new QcVerifySuccessEvent(user));
		}

		/// <summary>
		/// 质量审核失败
		/// </summary>
		/// <param name="user">审核人</param>
		public void QcVerifyFailed(User user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new QcVerifyFailedEvent(user));
		}

		/// <summary>
		/// 合规审核通过
		/// </summary>
		/// <param name="user">审核人</param>
		public void AuditSuccess(User user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new AuditSuccessEvent(user));
		}
		
		/// <summary>
		/// 合规审核失败
		/// </summary>
		/// <param name="user">审核人</param>
		public void AuditFailed(User user)
		{
			user.NotNull(nameof(user));
			ApplyChangedEvent(new AuditFailedEvent(user));
		}

		/// <summary>
		/// 发送报告给客户（限数据产品）
		/// </summary>
		/// <param name="clientUsers">客户联系人</param>
		public void SendEmail(List<Guid> clientUsers)
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
		/// <param name="clientFocusKeyPoint">客户关注点</param>
		/// <param name="continue">是否继续</param>
		/// <param name="modificationRequirement">更改需求</param>
		/// <param name="newRequirement">新需求</param>
		/// <param name="score">打分</param>
		/// <param name="feedback">反馈信息</param>
		public void SetScore(Guid serviceRecordId, string clientFocusKeyPoint, bool @continue,
			string modificationRequirement, string newRequirement, int score, string feedback)
		{
			ApplyChangedEvent(new SetScoreEvent(serviceRecordId, clientFocusKeyPoint, @continue,
				modificationRequirement, newRequirement, score, feedback));
		}

		private void Apply(CreateServicePlanEvent @event)
		{
			_product = @event.Product;
			_name = @event.Name;
			_beginTime = @event.BeginTime;
			_endTime = @event.EndTime;
			_user = @event.User;
			_planType = new ServicePlanType(_product.Type.Id, _product.Type.Name); 
			_planState = ServicePlanState.AwaitingSubmit;
		}

		private void Apply(CreateRoadShowPlanEvent @event)
		{
			_name = @event.Name;
			_beginTime = @event.BeginTime;
			_endTime = @event.EndTime;

			_planState = ServicePlanState.Submitted;
			_planType = ServicePlanType.RoadShow;
			_creator = @event.CreatorUser;
			_roadShow = new RoadShow(@event.ClientUsers, @event.Address, @event.OwnerId);
		}

		private void Apply(DeleteServicePlanEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.AwaitingSubmit))
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
			
			if (!_planState.Equals(ServicePlanState.AwaitingSubmit))
			{
				throw new ServicePlanException("服务计划已提交");
			}
			
			_planState = ServicePlanState.Submitted;
		}

		private void Apply(SetTitleAndAbstractEvent @event)
		{
			if (!_planType.Equals(ServicePlanType.Data))
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			_dataReport = new DataReport(@event.Title, @event.Abstract);
		}

		private void Apply(SubmitAuditEvent @event)
		{
			if (!_planType.Equals(ServicePlanType.Data))
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			if (_dataReport == null || string.IsNullOrWhiteSpace(_dataReport.Abstract) ||
			    string.IsNullOrWhiteSpace(_dataReport.ReportTitle))
			{
				throw new ServicePlanException("未设置报告摘要或标题");
			}

			if (_planState.Equals(ServicePlanState.Submitted) || _planState.Equals(ServicePlanState.AwaitingAudit) &&
			    (_auditState.Equals(AuditState.Dismissed) ||
			     _validationState.Equals(ValidationState.Dismissed)))
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
			if (!_planState.Equals(ServicePlanState.AwaitingAudit))
			{
				throw new ServicePlanException("尚未提交审核");
			}

			_qcUser = @event.User;
			_validationState = ValidationState.Confirmed;
			if (_auditState.Equals(AuditState.Confirmed))
			{
				_planState = ServicePlanState.AwaitingComplete;
			}
			
			_auditHistories.Add(new AuditHistory(@event.User, "qc", "success"));
		}

		private void Apply(QcVerifyFailedEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.AwaitingAudit))
			{
				throw new ServicePlanException("尚未提交审核");
			}

			_qcUser = @event.User;
			_validationState = ValidationState.Dismissed;
			_auditHistories.Add(new AuditHistory(@event.User, "qc", "failed"));
		}

		private void Apply(AuditSuccessEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.AwaitingAudit))
			{
				throw new ServicePlanException("尚未提交审核");
			}

			_validationState = ValidationState.Confirmed;
			_auditUser = @event.User;
			if (_validationState.Equals(ValidationState.Confirmed))
			{
				_planState = ServicePlanState.AwaitingComplete;
			}
			_auditHistories.Add(new AuditHistory(@event.User, "audit", "success"));
		}
		
		private void Apply(AuditFailedEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.AwaitingAudit))
			{
				throw new ServicePlanException("尚未提交审核");
			}

			_auditUser = @event.User;
			_validationState = ValidationState.Dismissed;
			_auditHistories.Add(new AuditHistory(@event.User, "audit", "failed"));
		}

		private void Apply(SendEmailEvent @event)
		{
			if (!_planType.Equals(ServicePlanType.Data))
			{
				throw new ServicePlanException("计划类型不匹配");
			}

			var notifiers = new List<Guid>();
			var clientUsers = _product.Subscriber.Where(a => @event.ClientUsers.Contains(a.ClientUserId)).ToArray();
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
			if (!_planState.Equals(ServicePlanState.AwaitingComplete))
			{
				throw new ServicePlanException("状态不正确");
			}

			if (_planType.Equals(ServicePlanType.Data))
			{
				var records = _emailRecords.Where(a => a.Success).GroupBy(a => a.ClientUser.ClientUserId)
					.Select(a => a.First()).ToArray();

				if (!records.Any())
				{
					throw new ServicePlanException("未发送邮件");
				}
			
				var clientUsers = _product.Subscriber;
				if (records.Length != clientUsers.Count)
				{
					throw  new ServicePlanException("有部分客户尚未发送邮件或发送邮件没有成功");
				}

				foreach (var record in records)
				{
					_serviceRecords.Add(new ServiceRecord(record.ResponseTime, _planType, @event.Subject,
						@event.IndustryId, new List<ClientUser> {record.ClientUser}));
				}
			}
			else if (_planType.Equals(ServicePlanType.RoadShow))
			{
				_serviceRecords.Add(new ServiceRecord(_beginTime, _planType, @event.Subject, @event.IndustryId,
					_roadShow.ClientUsers));
			}

			_planState = ServicePlanState.Complete;
		}

		private void Apply(SetScoreEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.Complete))
			{
				throw new ServicePlanException("状态不正确");
			}

			var serviceRecord = _serviceRecords.FirstOrDefault(a => a.Id == @event.ServiceRecordId);
			serviceRecord.NotNull(nameof(serviceRecord));
			serviceRecord.SetScoreAndFeedback(@event.ClientFocusKeyPoint, @event.Continue,
				@event.ModificationRequirement, @event.NewRequest, @event.Score, @event.Feedback);
		}

		private void Apply(SetClientUsersEvent @event)
		{
			if (!_planState.Equals(ServicePlanState.Complete))
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
	}
}