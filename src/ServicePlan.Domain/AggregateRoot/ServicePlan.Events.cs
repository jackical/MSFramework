using System;
using System.Collections.Generic;
using MSFramework.Domain;
using ServicePlan.Domain.Services;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 创建服务计划事件
	/// </summary>
	public class CreateServicePlanEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string ProductId { get; }

		public string User { get; }

		public string Name { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public ServicePlanType PlanType { get; }

		public CreateServicePlanEvent(string productId, ServicePlanType planType,  string user, string name, DateTime beginTime, DateTime endTime)
		{
			ProductId = productId;
			PlanType = planType;
			User = user;
			Name = name;
			BeginTime = beginTime;
			EndTime = endTime;
		}
	}

	/// <summary>
	/// 创建路演计划事件
	/// </summary>
	public class CreateRoadShowPlanEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public List<ClientUser> ClientUsers { get; }
         
		public string Address { get; }
         
		public DateTime BeginTime { get; }
         
		public DateTime EndTime { get; }

		public string Name { get; }

		public string User { get; }

		public string CreatorUser { get; }

		public CreateRoadShowPlanEvent(List<ClientUser> clientUsers, string user, string creator,
			string name, string address,
			DateTime beginTime, DateTime endTime)
		{
			ClientUsers = clientUsers;
			User = user;
			CreatorUser = creator;
			Name = name;
			Address = address;
			BeginTime = beginTime;
			EndTime = endTime;
		}
	}

	/// <summary>
	/// 提交服务计划事件
	/// </summary>
	public class SubmitPlanEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
	}

	/// <summary>
	/// 完成服务计划事件
	/// </summary>
	public class CompletePlanEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string Subject { get; }

		public string IndustryId { get; }

		public CompletePlanEvent(string subject, string industryId)
		{
			Subject = subject;
			IndustryId = industryId;
		}
	}

	/// <summary>
	/// 上传附件事件
	/// </summary>
	public class UploadAttachmentsEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public List<Attachment> Attachments { get; }

		public UploadAttachmentsEvent(List<Attachment> attachments)
		{
			Attachments = attachments;
		}
	}

	public class QcVerifySuccessEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string User { get; }

		public QcVerifySuccessEvent(string user)
		{
			User = user;
		}
	}

	public class QcVerifyFailedEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string User { get; }

		public QcVerifyFailedEvent(string user)
		{
			User = user;
		}
	}
	
	public class AuditSuccessEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string User { get; }

		public AuditSuccessEvent(string user)
		{
			User = user;
		}
	}

	public class AuditFailedEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string User { get; }

		public AuditFailedEvent(string user)
		{
			User = user;
		}
	}

	public class SetTitleAndAbstractEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string Title { get; }

		public string Abstract { get; }

		public SetTitleAndAbstractEvent(string title, string @abstract)
		{
			Title = title;
			Abstract = @abstract;
		}
	}

	public class SubmitAuditEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public string User { get; }

		public SubmitAuditEvent(string user)
		{
			User = user;
		}
	}

	public class SendEmailEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public DateTime CreationTime { get; }

		public List<ClientUser> ClientUsers { get; }

		public SendEmailEvent(List<ClientUser> clientUsers, DateTime creationTime)
		{
			ClientUsers = clientUsers;
			CreationTime = creationTime;
		}
	}

	public class SetEmailSentSuccessEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public Guid Identity { get; }

		public DateTime ResponseTime { get; }

		public SetEmailSentSuccessEvent(Guid identity, DateTime responseTime)
		{
			Identity = identity;
			ResponseTime = responseTime;
		}
	}
	
	public class SetEmailSentFailedEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public Guid Identity { get; }

		public DateTime ResponseTime { get; }

		public SetEmailSentFailedEvent(Guid identity, DateTime responseTime)
		{
			Identity = identity;
			ResponseTime = responseTime;
		}
	}

	public class DeleteServicePlanEvent : DeletedEvent<ServicePlan, Guid>
	{
	}

	public class SetClientUsersEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public Guid ServiceRecordId { get; }

		public List<ClientUser> ClientUsers { get; }

		public SetClientUsersEvent(Guid serviceRecordId, List<ClientUser> clientUsers)
		{
			ServiceRecordId = serviceRecordId;
			ClientUsers = clientUsers;
		}
	}
	
	public class SetScoreEvent: AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public Guid ServiceRecordId { get; }
		
		public int Score { get; }

		public string Feedback { get; }

		public SetScoreEvent(Guid serviceRecordId, int score, string feedback)
		{
			ServiceRecordId = serviceRecordId;
			Score = score;
			Feedback = feedback;
		}
	}

	public class SetServiceRecordInfoEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public Guid ServiceRecordId { get; }

		public string ClientFocusKeyPoint { get; }

		public bool Continue { get; }

		public string ModificationRequirement { get; }

		public string NewRequest { get; }
		
		public SetServiceRecordInfoEvent(Guid serviceRecordId, string clientFocusKeyPoint, bool @continue,
			string modificationRequirement, string newRequirement)
		{
			ServiceRecordId = serviceRecordId;
			ClientFocusKeyPoint = clientFocusKeyPoint;
			Continue = @continue;
			ModificationRequirement = modificationRequirement;
			NewRequest = newRequirement;
		}
	}

	public class CreateServiceRecordEvent : AggregateRootChangedEvent<ServicePlan, Guid>
	{
		public ServiceRecord ServiceRecord { get; }

		public CreateServiceRecordEvent(ServiceRecord record)
		{
			ServiceRecord = record;
		}
	}
}