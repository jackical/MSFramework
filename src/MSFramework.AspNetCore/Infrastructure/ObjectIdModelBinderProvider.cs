using Microsoft.AspNetCore.Mvc.ModelBinding;
using MSFramework.Common;

namespace MSFramework.AspNetCore.Infrastructure
{
	public class ObjectIdModelBinderProvider : IModelBinderProvider
	{
		public ObjectIdModelBinderProvider()
		{
		}

		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			return context.Metadata.ModelType == typeof(ObjectId) ? new ObjectIdModelBinder() : null;
		}
	}
}