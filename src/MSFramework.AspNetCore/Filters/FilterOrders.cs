namespace MSFramework.AspNetCore.Filters
{
	/// <summary>
	/// Filter 的顺序，越大则先运行
	/// </summary>
	public static class FilterOrders
	{
		public const int FunctionFilter = 0;
		public const int InvalidModelStateFilter = 1000;
		public const int UnitOfWork = 2000;
		public const int Audit = 3000;
	}
}