using System;
using System.Collections.Generic;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.DTO
{
	public class CreateRoadShowPlanDTO
	{
		public List<ClientUser> ClientUsers { get; }

		public User User { get; }

		public User Creator { get; }

		public string Address { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public Guid Owner { get; }

		public CreateRoadShowPlanDTO()
		{
		}

		public CreateRoadShowPlanDTO(List<ClientUser> clientUsers, User user, User creator, string address,
			DateTime beginTime, DateTime endTime, Guid owner)
		{
			ClientUsers = clientUsers;
			User = user;
			Creator = creator;
			Address = address;
			BeginTime = beginTime;
			EndTime = endTime;
			Owner = owner;
		}
	}
}