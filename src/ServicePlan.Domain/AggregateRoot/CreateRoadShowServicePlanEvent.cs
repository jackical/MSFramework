using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 创建路演服务计划领域事件
	/// </summary>
	public class CreateRoadShowServicePlanEvent : LocalDomainEvent
	{
		public Guid SchedulerId { get; }

		public Guid AppointmentId { get; }

		public string Client { get; }

		public List<ClientUser> ClientUsers { get; }

		public string Address { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public string User { get; }

		public string CreatorUser { get; }

		public CreateRoadShowServicePlanEvent(Guid schedulerId, string client, List<ClientUser> clientUsers, string address, string user,
			string creator, DateTime beginTime, DateTime endTime, Guid appointmentId)
		{
			SchedulerId = schedulerId;
			Client = client;
			ClientUsers = clientUsers;
			User = user;
			CreatorUser = creator;
			Address = address;
			BeginTime = beginTime;
			EndTime = endTime;
			AppointmentId = appointmentId;
		}
	}
}