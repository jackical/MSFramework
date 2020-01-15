using System;
using MediatR;
using MSFramework.AspNetCore;
using MSFramework.Http;

namespace Ordering.Application.Command
{
	public class DeleteOrderCommand : IRequest<ApiResult>
	{
		public Guid OrderId { get; private set; }

		public DeleteOrderCommand(Guid orderId)
		{
			OrderId = orderId;
		}
	}
}