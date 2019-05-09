using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	public class ServiceRecord : EntityBase<Guid>
	{
		/// <summary>
		/// 服务时间
		/// </summary>
		private DateTime _serviceTime;

		/// <summary>
		/// 服务计划类型
		/// </summary>
		private ServicePlanType _servicePlanType;
		
		/// <summary>
		/// 主题
		/// </summary>
		private string _subject;

		/// <summary>
		/// 行业
		/// </summary>
		private string _industryId;

		/// <summary>
		/// 客户联系人
		/// </summary>
		private List<ClientUser> _clientUsers;

		/// <summary>
		/// 客户关注点及原因
		/// </summary>
		private string _clientFocusKeyPoint;

		/// <summary>
		/// 是否继续委托
		/// </summary>
		private bool? _continue;

		/// <summary>
		/// 修改要求
		/// </summary>
		private string _modificationRequirement;

		/// <summary>
		/// 新增需求
		/// </summary>
		private string _newRequirement;

		/// <summary>
		/// 销售打分
		/// </summary>
		private int? _score;

		/// <summary>
		/// 销售反馈
		/// </summary>
		private string _feedback;

		public IReadOnlyCollection<ClientUser> ClientUsers => _clientUsers;

		private ServiceRecord()
		{
		}

		public ServiceRecord(DateTime serviceTime, ServicePlanType planType, string subject, string industryId, List<ClientUser> clientUsers)
		{
			_serviceTime = serviceTime;
			_servicePlanType = planType;
			_subject = subject;
			_industryId = industryId;
			_clientUsers = clientUsers;
		}

		public void SetScore(int score, string feedback)
		{
			_score = score;
			_feedback = feedback;
		}

		public void SetInfo(string clientFocusKeyPoint, bool @continue, string modificationRequirement,
			string newRequirement)
		{
			_clientFocusKeyPoint = clientFocusKeyPoint;
			_continue = @continue;
			_modificationRequirement = modificationRequirement;
			_newRequirement = newRequirement;
		}

		public void SetClientUsers(List<ClientUser> clientUsers)
		{
			_clientUsers = clientUsers;
		}
	}
}