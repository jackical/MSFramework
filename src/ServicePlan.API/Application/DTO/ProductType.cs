using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 产品类型
	/// </summary>
	public enum ProductType : byte
	{
		/// <summary>
		/// 空
		/// </summary>
		None,
		
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
		Conference
	}
}