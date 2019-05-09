using System;
using MSFramework.Domain;

namespace ServicePlan.API.Application
{
	/// <summary>
	/// 路演创建后事件
	/// </summary>
	public class RoadShowPlanCreatedEvent : LocalDomainEvent
	{
		public Guid SchedulerId { get; }

		public Guid PlanId { get; }

		public Guid AppointmentId { get; }

		public RoadShowPlanCreatedEvent(Guid schedulerId, Guid appointmentId, Guid planId)
		{
			SchedulerId = schedulerId;
			PlanId = planId;
			AppointmentId = appointmentId;
		}
	}
}