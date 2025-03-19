using eShopOnWinUI.Domain.Orders;
using eShopOnWinUI.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopOnWinUI.Persistence.Repositories;

internal sealed class OrdersRepository(DatabaseContext databaseContext) : IOrdersRepository
{
    public async Task<List<ProductId>> GetListOfUsedProducts(ProductId[] products, CancellationToken cancellationToken)
    {
        var result = await databaseContext
            .Orders
            .SelectMany(order => order.OrderItems)
            .Where(orderItem => products.Contains(orderItem.Product.Id))
            .Select(orderItem => orderItem.Product.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}