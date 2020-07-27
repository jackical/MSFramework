using System.Threading;
using System.Threading.Tasks;
using MSFramework.Application;
using MSFramework.Domain;
using Ordering.Domain.Repository;

namespace Ordering.Application.Command
{
	public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
	{
		private readonly IOrderingRepository _orderRepository;
		private readonly IUnitOfWorkManager _unitOfWorkManager;

		public CancelOrderCommandHandler(IOrderingRepository orderRepository, IUnitOfWorkManager unitOfWorkManager)
		{
			_orderRepository = orderRepository;
			_unitOfWorkManager = unitOfWorkManager;
		}

		public async Task HandleAsync(CancelOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _orderRepository.GetAsync(request.OrderId);

			order.SetCancelledStatus();
			await _unitOfWorkManager.CommitAsync();
		}
	}
}