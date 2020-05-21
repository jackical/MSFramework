using Microsoft.Extensions.DependencyInjection;

namespace MSFramework.Mapster
{
	public static class ServiceCollectionExtensions
	{
		public static MSFrameworkBuilder AddMapster(this MSFrameworkBuilder builder)
		{
			builder.Services.AddScoped<MSFramework.Data.IMapper, Mapper>();
			return builder;
		}
	}
}