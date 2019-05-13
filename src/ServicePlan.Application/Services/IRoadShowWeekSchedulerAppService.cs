using System;
using System.Threading.Tasks;
using MSFramework.Application;
using ServicePlan.Application.DTO;

namespace ServicePlan.Application.Services
{
	public interface IRoadShowWeekSchedulerAppService : IApplicationService
	{
		Task RoadShowPlanCreatedAsync(Guid eventSchedulerId, Guid eventAppointmentId, Guid eventPlanId);

		Task CreateAsync(CreateRoadShowWeekSchedulerDTO dto);

		Task CreateAppointmentAsync(Guid schedulerId, CreateAppointmentDTO dto);

		Task DeleteAppointmentAsync(Guid schedulerId, Guid appointmentId);

		Task MakeAppointmentWithClientAsync(Guid schedulerId, Guid appointmentId, MakeAppointmentDTO dto);
		
		Task CancelAppointmentWithClientAsync(Guid schedulerId, Guid appointmentId);
		
		Task SetRoadShowTopicAsync(Guid schedulerId, string topic);
	}
}