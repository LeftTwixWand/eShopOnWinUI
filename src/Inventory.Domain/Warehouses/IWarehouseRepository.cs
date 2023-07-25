﻿using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses;

public interface IWarehousesRepository
{
    Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Warehouse>> GetManyByIdsAsync(List<ProductId> usedProducts, CancellationToken cancellationToken);
}