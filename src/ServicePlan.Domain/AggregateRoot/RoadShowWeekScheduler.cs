using MSFramework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MSFramework.Data;

namespace ServicePlan.Domain.AggregateRoot
{
	/// <summary>
	/// 路演周计划
	/// </summary>
	public class RoadShowWeekScheduler : AggregateRootBase<RoadShowWeekScheduler, Guid>
	{
		/// <summary>
		/// 路演
		/// </summary>
		private readonly List<Appointment> _appointments = new List<Appointment>(0);

		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime _beginTime;

		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime _endTime;

		/// <summary>
		/// 核心观点与服务
		/// </summary>
		private string _keyIdeaAndTopic;

		/// <summary>
		/// 可路演时间
		/// </summary>
		public IReadOnlyCollection<Appointment> Appointments => _appointments;

		/// <summary>
		/// 负责人
		/// </summary>
		public string User { get; private set; }

		private RoadShowWeekScheduler()
		{
		}

		/// <summary>
		/// 路演计划
		/// </summary>
		/// <param name="user">用户</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public RoadShowWeekScheduler(string user, DateTime beginTime, DateTime endTime)
		{
			ApplyChangedEvent(new CreateWeekSchedulerEvent(user, beginTime, endTime));
		}

		/// <summary>
		/// 设置核心观点与服务
		/// </summary>
		/// <param name="keyIdeaAndTopic">核心观点与服务</param>
		public void SetKeyIdeaAndTopic(string keyIdeaAndTopic)
		{
			keyIdeaAndTopic.NotNull(nameof(keyIdeaAndTopic));
			
			ApplyChangedEvent(new BindKeyIdeaAndTopicEvent(keyIdeaAndTopic));
		}

		/// <summary>
		/// 添加可路演时间
		/// </summary>
		/// <param name="location">可路演地点</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public void AddAppointment(string location, DateTime beginTime, DateTime endTime)
		{
			ApplyChangedEvent(new AddIdleDateTimeEvent(new Appointment(location, beginTime, endTime)));
		}

		/// <summary>
		/// 删除可路演时间
		/// </summary>
		/// <param name="appointmentId">预约标识</param>
		public void DeleteAppointment(Guid appointmentId)
		{
			ApplyChangedEvent(new RemoveIdleDateTimeEvent(appointmentId));
		}

		/// <summary>
		/// 销售预约客户路演
		/// </summary>
		/// <param name="appointmentId">预约id</param>
		/// <param name="address">路演地址</param>
		/// <param name="client">客户信息</param>
		/// <param name="clientUsers">客户联系人</param>
		/// <param name="sale">销售信息</param>
		/// <param name="description">描述</param>
		public void MakeAppointWithClient(Guid appointmentId, string address, string client,
			List<ClientUser> clientUsers, string sale, string description)
		{
			address.NotNull(nameof(address));
			client.NotNull(nameof(client));
			clientUsers.NotNull(nameof(clientUsers));
			sale.NotNull(nameof(sale));

			ApplyChangedEvent(new MakeAppointWithClientEvent(appointmentId, address, client, clientUsers, sale,
				description, DateTime.Now));

			// 发送添加服务计划的事件
			AddDomainEvent(
				new CreateRoadShowServicePlanEvent(Id, client, clientUsers, address, User, sale, _beginTime, _endTime,
					appointmentId));
		}

		/// <summary>
		/// 销售撤销预约
		/// </summary>
		/// <param name="appointmentId">预约标识</param>
		public void CancelAppointWithClient(Guid appointmentId)
		{
			var appointment = _appointments.FirstOrDefault(a => a.Id == appointmentId);
			appointment.NotNull(nameof(appointment));
			
			ApplyChangedEvent(new CancelAppointEvent(appointment));
			
			// 发送删除服务计划的事件
			AddDomainEvent(new RoadShowPlanCanceledEvent(appointment.PlanId.Value));
		}

		/// <summary>
		/// 路演计划创建后
		/// </summary>
		/// <param name="appointmentId">预约标识</param>
		/// <param name="planId">计划标识</param>
		public void RoadShowPlanCreated(Guid appointmentId, Guid planId)
		{
			ApplyChangedEvent(new RoadShowPlanCreatedAggregateEvent(appointmentId, planId));
		}

		#region ApplyMethods

		private void Apply(BindKeyIdeaAndTopicEvent @event)
		{
			_keyIdeaAndTopic = @event.KeyIdeaAndTopic;
		}

		private void Apply(CreateWeekSchedulerEvent @event)
		{
			User = @event.User;
			_beginTime = @event.BeginTime;
			_endTime = @event.EndTime;
		}

		private void Apply(AddIdleDateTimeEvent @event)
		{
			_appointments.Add(@event.NewDateTime);
		}

		private void Apply(MakeAppointWithClientEvent @event)
		{
			var appointment = _appointments.FirstOrDefault(a => a.Id == @event.AppointmentId);
			appointment.NotNull(nameof(appointment));
			appointment.MakeAppointWithClient(@event.Address, @event.ClientUsers, @event.Sale,
				@event.Description, @event.BookTime);
		}

		private void Apply(CancelAppointEvent @event)
		{
			var appointment = @event.Appointment;
			if (!appointment.Booked)
			{
				throw new ServicePlanException("未预约");
			}
			
			appointment.Cancel();
		}

		private void Apply(RemoveIdleDateTimeEvent @event)
		{
			var appointment = _appointments.FirstOrDefault(a => a.Id == @event.AppointmentId);
			appointment.NotNull(nameof(appointment));
			
			if (appointment.Booked)
			{
				throw new ServicePlanException("已预约,无法删除");
			}
			_appointments.Remove(appointment);
		}

		private void Apply(RoadShowPlanCreatedAggregateEvent @event)
		{
			var appointment = _appointments.FirstOrDefault(a => a.Id == @event.AppointmentId);
			appointment.NotNull(nameof(appointment));
			
			appointment.SetPlanId(@event.PlanId);
		}

		#endregion
	}
}
