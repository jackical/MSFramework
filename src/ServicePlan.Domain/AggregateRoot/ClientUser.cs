using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class ClientUser : ValueObject
	{
		private Guid _id;
		
		public Guid ClientId { get; private set; }

		public string ClientName { get; private set; }

		public string ClientShortName { get; private set; }

		public Guid ClientUserId { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		private ClientUser()
		{
		}

		public ClientUser(Guid clientUserId, string firstName, string lastName, Guid clientId, string clientName,
			string clientShortName) 
		{
			ClientUserId = clientUserId;
			FirstName = firstName;
			LastName = lastName;
			ClientId = clientId;
			ClientName = clientName;
			ClientShortName = clientShortName;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return ClientUserId;
			yield return FirstName;
			yield return LastName;
			yield return ClientId;
			yield return ClientName;
			yield return ClientShortName;
		}

		public static ClientUser Empty()
		{
			return new ClientUser();
		}
	}
}