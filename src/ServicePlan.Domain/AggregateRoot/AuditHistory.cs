using System.Collections.Generic;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class AuditHistory : ValueObject
	{
		public User User { get; }

		public string Operation { get; }

		public string Result { get; }

		private AuditHistory()
		{
		}

		public AuditHistory(User user, string operation, string result)
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