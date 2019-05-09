using System;
using System.Collections.Generic;
using System.Text;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 服务计划状态
	/// </summary>
	public enum ServicePlanState : byte
	{
		/// <summary>
		/// 等待提交
		/// </summary>
		AwaitingSubmit,

		/// <summary>
		/// 已提交
		/// </summary>
		Submitted,

		/// <summary>
		/// 待审核
		/// </summary>
		AwaitingAudit,

		/// <summary>
		/// 待完成
		/// </summary>
		AwaitingComplete,

		/// <summary>
		/// 已完成
		/// </summary>
		Complete
	}
}
