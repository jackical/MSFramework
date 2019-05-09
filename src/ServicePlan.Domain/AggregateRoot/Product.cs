using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class Product : ValueObject
	{
		public Guid ProductId { get; }

		public string Name { get;}

		public ProductType Type { get; }

		/// <summary>
		/// 订阅者
		/// </summary>
		public List<ClientUser> Subscriber { get; }

		private Product()
		{
		}

		public Product(Guid id, string name, ProductType productType, List<ClientUser> subscriber)
		{
			ProductId = id;
			Name = name;
			Type = productType;
			Subscriber = subscriber;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return ProductId;
			yield return Name;
			yield return Type;
			yield return Subscriber;
		}
	}
}