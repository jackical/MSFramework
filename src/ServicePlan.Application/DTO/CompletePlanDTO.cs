using System;

namespace ServicePlan.Application.DTO
{
	public class CompletePlanDTO
	{
		public string Subject { get; }

		public string IndustryId { get; }

		public CompletePlanDTO(string subject, string industryId)
		{
			Subject = subject;
			IndustryId = industryId;
		}
	}
}