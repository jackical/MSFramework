using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class User : ValueObject
	{
		public Guid UserId { get; }

		public string FirstName { get; }

		public string LastName { get; }

		/// <summary>
		/// 所在组
		/// </summary>
		public string GroupName { get; }

		/// <summary>
		/// 所在团队
		/// </summary>
		public string TeamName { get; }

		/// <summary>
		/// 邮箱地址
		/// </summary>
		public string Email { get; }
		
		private User()
		{
		}

		public User(Guid id, string firstName, string lastName, string groupName, string teamName, string email)
		{
			UserId = id;
			FirstName = firstName;
			LastName = lastName;
			GroupName = groupName;
			TeamName = teamName;
			Email = email;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return UserId;
			yield return FirstName;
			yield return LastName;
			yield return GroupName;
			yield return TeamName;
			yield return Email;
		}
	}
}