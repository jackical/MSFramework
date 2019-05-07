using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 创建周度计划
	/// </summary>
	public class CreateWeekSchedulerEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		public User User { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public CreateWeekSchedulerEvent(User user, DateTime beginTime, DateTime endTime)
		{
			User = user;
			BeginTime = beginTime;
			EndTime = endTime;
		}
	}

	/// <summary>
	/// 添加可路演时间
	/// </summary>
	public class AddIdleDateTimeEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		public Appointment NewDateTime { get; }

		public AddIdleDateTimeEvent(Appointment freeDateTime)
		{
			NewDateTime = freeDateTime;
		}
	}

	/// <summary>
	/// 预约路演事件
	/// </summary>
	public class MakeAppointWithClientEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		/// <summary>
		/// 预约项
		/// </summary>
		public Guid AppointmentId { get; }
		
		public string Address { get; }

		public Client Client { get; }

		public List<ClientUser> ClientUsers { get; }

		public User Sale { get; }

		/// <summary>
		/// 预定时间
		/// </summary>
		public DateTime BookTime { get; }

		public string Description { get; }

		public MakeAppointWithClientEvent(Guid appointmentId, string address, Client client,
			List<ClientUser> clientUsers, User sale, string description, DateTime bookTime)
		{
			Address = address;
			Client = client;
			ClientUsers = clientUsers;
			Sale = sale;
			AppointmentId = appointmentId;
			BookTime = bookTime;
			Description = description;
		}
	}

	/// <summary>
	/// 删除预约事件
	/// </summary>
	public class CancelAppointEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		public Guid AppointmentId { get; }

		public CancelAppointEvent(Guid appointmentId)
		{
			AppointmentId = appointmentId;
		}
	}

	/// <summary>
	/// 移除可路演时间
	/// </summary>
	public class RemoveIdleDateTimeEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		public Guid AppointmentId { get; }
		
		public RemoveIdleDateTimeEvent(Guid appointmentId)
		{
			AppointmentId = appointmentId;
		}
	}

	/// <summary>
	/// 关联核心观点和主题
	/// </summary>
	public class BindKeyIdeaAndTopicEvent : AggregateRootChangedEvent<RoadShowWeekScheduler, Guid>
	{
		public string KeyIdeaAndTopic { get; }

		public BindKeyIdeaAndTopicEvent(string keyIdeaAndTopic)
		{
			KeyIdeaAndTopic = keyIdeaAndTopic;
		}
	}
}