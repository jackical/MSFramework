using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFramework.AspNetCore;
using MSFramework.Domain;
using ServicePlan.Application.DTO;
using ServicePlan.Application.Services;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ServicePlanController : MSFrameworkControllerBase
	{
		private readonly IServicePlanAppService _servicePlanAppService;

		public ServicePlanController(
			IServicePlanAppService servicePlanAppService,
			IMSFrameworkSession session, ILogger<ServicePlanController> logger) : base(session, logger)
		{
			_servicePlanAppService = servicePlanAppService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAsync([FromBody] CreateServicePlanDTO dto)
		{
			await _servicePlanAppService.CreateAsync(dto);
			return Ok(true);
		}

		[HttpPut("{planId}/submit")]
		public async Task<IActionResult> SubmitAsync([FromBody] Guid planId)
		{
			await _servicePlanAppService.SubmitAsync(planId);
			return Ok(true);
		}

		[HttpDelete("{planId}")]
		public async Task<IActionResult> DeleteAsync([FromBody] Guid planId)
		{
			await _servicePlanAppService.DeleteAsync(planId);
			return Ok(true);
		}

		[HttpPut("{planId}/Upload")]
		public async Task<IActionResult> UploadAttachmentsAsync(Guid planId, [FromBody] List<AttachmentDTO> attachments)
		{
			await _servicePlanAppService.UploadAttachmentsAsync(planId, attachments);
			return Ok(true);
		}

		[HttpPut("{planId}/qc-success")]
		public async Task<IActionResult> QcSuccessAsync(Guid planId)
		{
			await _servicePlanAppService.QcSuccessAsync(planId);
			return Ok(true);
		}

		[HttpPut("{planId}/qc-failed")]
		public async Task<IActionResult> QcFailedAsync(Guid planId)
		{
			await _servicePlanAppService.QcFailedAsync(planId);
			return Ok(true);
		}

		[HttpPut("{planId}/audit-success")]
		public async Task<IActionResult> AuditSuccessAsync(Guid planId)
		{
			await _servicePlanAppService.AuditSuccessAsync(planId);
			return Ok(true);
		}

		[HttpPut("{planId}/audit-failed")]
		public async Task<IActionResult> UploadAttachmentsAsync(Guid planId)
		{
			await _servicePlanAppService.AuditFailedAsync(planId);
			return Ok(true);
		}

		[HttpPut("{planId}/send")]
		public async Task<IActionResult> SendEmailAsync(Guid planId, [FromBody] List<ClientUser> clientUsers)
		{
			await _servicePlanAppService.SendEmailAsync(planId, clientUsers);
			return Ok(true);
		}

		[HttpPut("{planId}/complete")]
		public async Task<IActionResult> CompleteAsync(Guid planId, [FromBody] CompletePlanDTO dto)
		{
			await _servicePlanAppService.SetComplete(planId, dto);
			return Ok(true);
		}
		
		[HttpPost("{planId}")]
		public async Task<IActionResult> CreateServiceRecord(Guid planId, [FromBody] CreateServiceRecordDTO dto)
		{
			await _servicePlanAppService.CreateServiceRecordAsync(planId, dto);
			return Ok(true);
		}

		[HttpPut("{planId}/{serviceRecordId}/set-client-users")]
		public async Task<IActionResult> SetServiceRecordUsersAsync(Guid planId, Guid serviceRecordId,
			[FromBody] List<ClientUser> clientUsers)
		{
			await _servicePlanAppService.SetServiceRecordUsersAsync(planId, serviceRecordId, clientUsers);
			return Ok(true);
		}

		[HttpPut("{planId}/{serviceRecordId}/set-record-info")]
		public async Task<IActionResult> SetServiceRecordInfoAsync(Guid planId, Guid serviceRecordId,
			[FromBody] ServiceRecordInfoDTO dto)
		{
			await _servicePlanAppService.SetServiceRecordInfoAsync(planId, serviceRecordId, dto);
			return Ok(true);
		}

		[HttpPut("{planId}/{serviceRecordId}/set-score")]
		public async Task<IActionResult> SetServiceRecordScoreAsync(Guid planId, Guid serviceRecordId,
			[FromBody] ServiceRecordScoreTDO dto)
		{
			await _servicePlanAppService.SetScoreAndFeedbackAsync(planId, serviceRecordId, dto);
			return Ok(true);
		}
	}
}
