using System;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class CancelRoadShowServicePlanEvent : LocalDomainEvent
	{
		public Guid AppointmentId { get; }

		public CancelRoadShowServicePlanEvent(Guid appointmentId)
		{
			AppointmentId = appointmentId;
		}
	}
}