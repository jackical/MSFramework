using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class Product : ValueObject
	{
		public Guid ProductId { get; private set; }

		public string Name { get; private set; }

		public ProductType Type { get; private set; }

		private readonly List<ClientUser> _subscriber;

		/// <summary>
		/// 订阅者
		/// </summary>
		public IReadOnlyCollection<ClientUser> Subscriber => _subscriber;

		private Product()
		{
		}

		public Product(Guid id, string name, ProductType productType, List<ClientUser> subscriber)
		{
			ProductId = id;
			Name = name;
			Type = productType;
			_subscriber = subscriber;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return ProductId;
			yield return Name;
			yield return Type;
			yield return _subscriber;
		}
	}
}