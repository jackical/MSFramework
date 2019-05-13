using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MSFramework.Application;
using ServicePlan.API.Application.DTO;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Application.Services
{
	public interface IServicePlanAppService : IApplicationService
	{
		Task CreateRoadShowAsync(CreateRoadShowPlanDTO dto);
		
		Task CancelRoadShowAsync(Guid planId);

		Task CreateAsync(CreateServicePlanDTO dto);
		
		Task SubmitAsync(Guid planId);

		Task DeleteAsync(Guid planId);

		Task UploadAttachmentsAsync(Guid planId, List<AttachmentDTO> attachments);

		Task QcSuccessAsync(Guid planId);
		
		Task QcFailedAsync(Guid planId);

		Task AuditSuccessAsync(Guid planId);
		
		Task AuditFailedAsync(Guid planId);

		Task SendEmailAsync(Guid planId, List<ClientUser> clientUsers);

		Task SetComplete(Guid planId, CompletePlanDTO dto);

		Task SetServiceRecordUsersAsync(Guid planId, Guid serviceRecordId, List<ClientUser> clientUsers);

		Task SetServiceRecordInfoAsync(Guid planId, Guid serviceRecordId, ServiceRecordInfoDTO dto);

		Task SetScoreAndFeedbackAsync(Guid planId, Guid serviceRecordId, ServiceRecordScoreTDO dto);

		Task CreateServiceRecordAsync(Guid planId, CreateServiceRecordDTO dto);
	}
}