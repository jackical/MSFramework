using System;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class RoadShowPlanCanceledEvent : LocalDomainEvent
	{
		public Guid PlanId { get; }

		public RoadShowPlanCanceledEvent(Guid planId)
		{
			PlanId = planId;
		}
	}
}