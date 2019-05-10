using System;

namespace ServicePlan.API.Application.DTO
{
	public class ServiceRecordInfoDTO
	{
		public string ClientFocusKeyPoint { get; }

		public bool Continue { get; }

		public string ModificationRequirement { get; }

		public string NewRequest { get; }

		public ServiceRecordInfoDTO(string clientFocusKeyPoint, bool @continue,
			string modificationRequirement, string newRequirement)
		{
			ClientFocusKeyPoint = clientFocusKeyPoint;
			Continue = @continue;
			ModificationRequirement = modificationRequirement;
			NewRequest = newRequirement;
		}
	}
}