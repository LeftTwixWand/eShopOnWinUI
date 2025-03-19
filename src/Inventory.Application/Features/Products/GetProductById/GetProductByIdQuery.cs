using System;
using Inventory.Application.CQRS.Queries;
using Inventory.Application.Models;

namespace Inventory.Application.Features.Products.GetProductById;

internal sealed record GetProductByIdQuery(Guid ProductId) : QueryBase<ProductModel?>;