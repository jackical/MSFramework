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
		public Guid OwnerId { get; }

		public Client Client { get; }

		public List<ClientUser> ClientUsers { get; }

		public string Address { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public User User { get; }

		public User CreatorUser { get; }

		public CreateRoadShowServicePlanEvent(Client client, List<ClientUser> clientUsers, string address, User user,
			User creator, DateTime beginTime, DateTime endTime, Guid ownerId)
		{
			Client = client;
			ClientUsers = clientUsers;
			User = user;
			CreatorUser = creator;
			Address = address;
			BeginTime = beginTime;
			EndTime = endTime;
			OwnerId = ownerId;
		}
	}
}