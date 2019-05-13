using System.Collections.Generic;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.DTO
{
	public class MakeAppointmentDTO
	{
		public string Address { get; set; }

		public string Client { get; set; }

		public List<ClientUser> ClientUsers { get; set; }

		public string Sale { get; set; }

		public string Description { get; set; }
	}
}