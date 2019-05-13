using System;
using System.Collections.Generic;
using MSFramework.Data;
using MSFramework.Domain;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 可路演时间
	/// </summary>
	public class Appointment : EntityBase<Guid>
	{
		/// <summary>
		/// 是否预定
		/// </summary>
		private bool _booked;

		private DateTime? _bookTime;

		/// <summary>
		/// 可路演地点
		/// </summary>
		private string _location;

		/// <summary>
		/// 地址
		/// </summary>
		private string _address;

		/// <summary>
		/// 客户联系人
		/// </summary>
		private List<ClientUser> _clientUsers;

		/// <summary>
		/// 描述
		/// </summary>
		private string _description;

		/// <summary>
		/// 计划标识
		/// </summary>
		public Guid? PlanId { get; private set; }
		
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime { get; private set; }

		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime { get; private set; }

		/// <summary>
		/// 销售
		/// </summary>
		public string Sale { get; private set; }

		/// <summary>
		/// 客户联系人
		/// </summary>
		public IReadOnlyCollection<ClientUser> ClientUsers => _clientUsers;

		public bool Booked => _booked;

		public Appointment(string location, DateTime beginTime, DateTime endTime)
		{
			_location = location;
			BeginTime = beginTime;
			EndTime = endTime;
			_booked = false;
		}

		public void MakeAppointWithClient(string address, List<ClientUser> clientUsers, string sale, string description,
			DateTime bookTime)
		{
			if (_booked)
			{
				throw new ServicePlanException("该时间段已被预约");
			}

			_address = address;
			_clientUsers = clientUsers;
			Sale = sale;
			_bookTime = bookTime;
			_description = description;
			_booked = true;
		}

		public void SetPlanId(Guid planId)
		{
			PlanId = planId;
		}

		public void Cancel()
		{
			_booked = false;
			_location = string.Empty;
			PlanId = Guid.Empty;
			_bookTime = null;
		}
	}
}