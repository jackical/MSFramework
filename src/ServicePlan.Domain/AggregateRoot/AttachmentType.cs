using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public enum AttachmentType : byte
	{
		/// <summary>
		/// 报告
		/// </summary>
		Report,
		/// <summary>
		/// 邀请
		/// </summary>
		Invitation,
		/// <summary>
		/// 其他
		/// </summary>
		Other
	}
}