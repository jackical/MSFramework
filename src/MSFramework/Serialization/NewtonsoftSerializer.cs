using System;
using Newtonsoft.Json;

namespace MicroserviceFramework.Serialization
{
	public class NewtonsoftSerializer : ISerializer
	{
		public string Serialize(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		public object Deserialize(string json, Type type)
		{
			return JsonConvert.DeserializeObject(json, type);
		}
	}
}