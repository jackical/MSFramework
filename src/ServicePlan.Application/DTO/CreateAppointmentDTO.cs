using System;
using MSFramework.Domain;

namespace ServicePlan.Application.DTO
{
	public class CreateAppointmentDTO
	{
		public string Location { get; }

		public DateTime BeginTime { get; }

		public DateTime EndTime { get; }

		public CreateAppointmentDTO(string location, DateTime beginTime, DateTime endTime)
		{
			Location = location;
			BeginTime = beginTime;
			EndTime = endTime;
		}
	}
}