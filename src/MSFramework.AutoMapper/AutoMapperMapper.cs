using IAutoMapper = AutoMapper.IMapper;

namespace MSFramework.AutoMapper
{
	public class AutoMapperMapper : Mapper.IObjectMapper
	{
		private readonly IAutoMapper _mapper;

		public AutoMapperMapper(IAutoMapper mapper)
		{
			_mapper = mapper;
		}

		public TDestination Map<TDestination>(object source)
		{
			return _mapper.Map<TDestination>(source);
		}

		public TDestination Map<TSource, TDestination>(TSource source)
		{
			return _mapper.Map<TSource, TDestination>(source);
		}

		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return _mapper.Map(source, destination);
		}
	}
}