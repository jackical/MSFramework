using System;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.DTO
{
	public class CreateServicePlanDTO
	{
		public string ProductId { get; }

		public ServicePlanType PlanType { get; }

		public string User { get; }

		public string PlanName { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public CreateServicePlanDTO(string productId, ServicePlanType planType, string user, string planName,
			DateTime beginTime, DateTime endTime)
		{
			ProductId = productId;
			PlanType = planType;
			User = user;
			PlanName = planName;
			BeginTime = beginTime;
			EndTime = endTime;
		}
	}
}