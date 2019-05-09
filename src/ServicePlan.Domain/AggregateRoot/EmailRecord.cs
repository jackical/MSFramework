using System;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 邮件发送服务记录
	/// </summary>
	public class EmailRecord : EntityBase<Guid>
	{
		/// <summary>
		/// 创建时间
		/// </summary>
		private DateTime _creationTime;

		/// <summary>
		/// 是否发送成功
		/// </summary>
		public bool? Success { get; private set; }

		/// <summary>
		/// 邮件响应时间
		/// </summary>
		public DateTime? ResponseTime { get; private set; }

		/// <summary>
		/// 客户联系人
		/// </summary>
		public ClientUser ClientUser { get; }

		private EmailRecord()
		{
		}

		public EmailRecord(ClientUser clientUser, DateTime creationTime, Guid identity) : base(identity)
		{
			ClientUser = clientUser;
			_creationTime = creationTime;
		}

		public void SetSuccess(DateTime responseTime)
		{
			ResponseTime = responseTime;
			Success = true;
		}

		public void SetFailed(DateTime responseTime)
		{
			ResponseTime = responseTime;
			Success = false;
		}
	}
}