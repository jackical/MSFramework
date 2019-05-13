using System;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Application.DTO
{
	public class CreateServicePlanDTO
	{
		public string ProductId { get; set; }

		public ServicePlanType PlanType { get; set; }

		public string User { get; set; }

		public string PlanName { get; set; }

		public DateTime BeginTime { get; set; }

		public DateTime EndTime { get; set; }
	}
}