using System;
using System.Collections.Generic;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Application.DTO
{
	public class CreateServiceRecordDTO
	{
		/// <summary>
		/// 服务时间
		/// </summary>
		public DateTime ServiceTime { get; set; }

		/// <summary>
		/// 服务计划类型
		/// </summary>
		public ServicePlanType ServicePlanType { get; set; }

		/// <summary>
		/// 主题
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// 行业
		/// </summary>
		public string IndustryId{ get; set; }

		/// <summary>
		/// 客户联系人
		/// </summary>
		public List<ClientUser> ClientUsers{ get; set; }

		/// <summary>
		/// 客户关注点及原因
		/// </summary>
		public string ClientFocusKeyPoint{ get; set; }

		/// <summary>
		/// 是否继续委托
		/// </summary>
		public bool Continue{ get; set; }

		/// <summary>
		/// 修改要求
		/// </summary>
		public string ModificationRequirement{ get; set; }

		/// <summary>
		/// 新增需求
		/// </summary>
		public string NewRequirement{ get; set; }

		/// <summary>
		/// 销售打分
		/// </summary>
		public int Score{ get; set; }

		/// <summary>
		/// 销售反馈
		/// </summary>
		public string Feedback{ get; set; }
	}
}