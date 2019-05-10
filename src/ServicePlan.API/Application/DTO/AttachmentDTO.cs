using System;

namespace ServicePlan.API.Application.DTO
{
	public class AttachmentDTO
	{
		public Guid Id { get; }

		public string Name { get; }

		public string Path { get; }

		public string Type { get; }

		public AttachmentDTO(Guid id, string name, string path, string type)
		{
			Id = id;
			Name = name;
			Path = path;
			Type = type;
		}
	}
}