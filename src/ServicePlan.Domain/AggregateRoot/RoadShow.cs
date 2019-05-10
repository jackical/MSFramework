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
		private List<ClientUser> _clientUsers;

		/// <summary>
		/// 预约地址
		/// </summary>
		public string Address { get; private set; }

		public IReadOnlyCollection<ClientUser> ClientUsers => _clientUsers;

		private RoadShow()
		{
		}

		public RoadShow(List<ClientUser> clientUsers, string address)
		{
			_clientUsers = clientUsers;
			Address = address;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return _clientUsers;
			yield return Address;
		}

		public static RoadShow Empty()
		{
			return new RoadShow();
		}
	}
}