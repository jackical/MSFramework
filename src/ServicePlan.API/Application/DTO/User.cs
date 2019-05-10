using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class User : ValueObject
	{
		public string UserId { get; private set; }

		public string UserName { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		/// <summary>
		/// 所在组
		/// </summary>
		public string GroupName { get; private set; }

		/// <summary>
		/// 所在团队
		/// </summary>
		public string TeamName { get; private set; }

		/// <summary>
		/// 邮箱地址
		/// </summary>
		public string Email { get; private set; }
		
		private User()
		{
		}

		public User(string id, string userName, string firstName, string lastName, string groupName, string teamName,
			string email)
		{
			UserId = id;
			UserName = userName;
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

		public static User Empty()
		{
			return new User();
		}
	}
}