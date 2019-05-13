using System;

namespace ServicePlan.API.Application.DTO
{
	public class AttachmentDTO
	{
		public Guid Id { get; }

		public string Name { get; set;}

		public string Path { get; set;}

		public string Type { get; set; }
	}
}