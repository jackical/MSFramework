using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 计划类型
	/// </summary>
	public enum ServicePlanType : byte
	{
		/// <summary>
		/// 数据产品
		/// </summary>
		Data,

		/// <summary>
		/// 调研
		/// </summary>
		Survey,

		/// <summary>
		/// 电话
		/// </summary>
		Tel,

		/// <summary>
		/// 会议
		/// </summary>
		Conference,

		/// <summary>
		/// 路演
		/// </summary>
		RoadShow
	}
}