using System.Linq;
using System.Threading.Tasks;
using MicroserviceFramework.Ef;
using MicroserviceFramework.Ef.Repositories;
using MicroserviceFramework.Extensions;
using MicroserviceFramework.Shared;
using Ordering.Domain.AggregateRoots;
using Ordering.Domain.Repositories;

namespace Ordering.Infrastructure.Repositories
{
	public class ProductRepository : EfRepository<Product>, IProductRepository
	{
		public ProductRepository(DbContextFactory dbContextFactory) : base(dbContextFactory)
		{
		}

		public Product GetFirst()
		{
			return CurrentSet.FirstOrDefault();
		}

		public async Task<PagedResult<Product>> PagedQueryAsync(int page, int limit)
		{
			return await CurrentSet.PagedQueryAsync(page, limit);
		}
	}
}