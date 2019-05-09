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

		public Guid SchedulerId { get; }

		public Guid AppointmentId { get; }

		public CreateRoadShowPlanDTO()
		{
		}

		public CreateRoadShowPlanDTO(List<ClientUser> clientUsers, User user, User creator, string address,
			DateTime beginTime, DateTime endTime, Guid schedulerId, Guid appointmentId)
		{
			ClientUsers = clientUsers;
			User = user;
			Creator = creator;
			Address = address;
			BeginTime = beginTime;
			EndTime = endTime;
			SchedulerId = schedulerId;
			AppointmentId = appointmentId;
		}
	}
}