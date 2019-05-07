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
		/// 所属预约路演信息
		/// </summary>
		public Guid Owner { get; }

		/// <summary>
		/// 预约地址
		/// </summary>
		public string Address { get; }

		public RoadShow(List<ClientUser> clientUsers, string address, Guid owner)
		{
			ClientUsers = clientUsers;
			Owner = owner;
			Address = address;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return ClientUsers;
			yield return Owner;
			yield return Address;
		}
	}
}