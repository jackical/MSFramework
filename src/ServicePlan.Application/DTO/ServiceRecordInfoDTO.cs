using System;

namespace ServicePlan.Application.DTO
{
	public class ServiceRecordInfoDTO
	{
		public string ClientFocusKeyPoint { get; set; }

		public bool Continue { get; set; }

		public string ModificationRequirement { get; set; }

		public string NewRequest { get; set; }
	}
}