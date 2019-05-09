using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 质量审核状态
	/// </summary>
	public enum ValidationState : byte
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