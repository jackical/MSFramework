using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class RoadShow : ValueObject
	{
		/// <summary>
		/// 客户联系人
		/// </summary>
		public List<ClientUser> ClientUsers { get; }

		/// <summary>
		/// 预约地址
		/// </summary>
		public string Address { get; }

		private RoadShow()
		{
		}

		public RoadShow(List<ClientUser> clientUsers, string address)
		{
			ClientUsers = clientUsers;
			Address = address;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return ClientUsers;
			yield return Address;
		}
	}
}