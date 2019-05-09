using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 合规审核装填
	/// </summary>
	public enum AuditState : byte
	{
		/// <summary>
		/// 待审核
		/// </summary>
		AwaitingValidation,

		/// <summary>
		/// 审核通过
		/// </summary>
		Confirmed,

		/// <summary>
		/// 审核失败
		/// </summary>
		Dismissed
	}
}