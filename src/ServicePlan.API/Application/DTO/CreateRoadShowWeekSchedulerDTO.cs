using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.API.Application.DTO
{
	public class CreateRoadShowWeekSchedulerDTO
	{
		public string User { get; set; }

		public DateTime BeginTime { get; set; }

		public DateTime EndTime { get; set; }

		public List<CreateAppointmentDTO> Appointments { get; set; }
	}
}