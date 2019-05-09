using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class AuditHistory : ValueObject
	{
		private Guid _id;

		public User User { get; private set; }

		public string Operation { get; private set; }

		public string Result { get; private set; }

		private AuditHistory()
		{
			_id = Guid.NewGuid();
		}

		public AuditHistory(User user, string operation, string result) : this()
		{
			User = user;
			Operation = operation;
			Result = result;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return User;
			yield return Operation;
			yield return Result;
		}
	}
}