using AutoMapper;
using Template.Domain;
using Template.Domain.AggregateRoot;

namespace Template.Application.DTO
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Class1, Class1Out>();
			CreateMap<Class1, CreatClass1Out>();
		}
	}
}