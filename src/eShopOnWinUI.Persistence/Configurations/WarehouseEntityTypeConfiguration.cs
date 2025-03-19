using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopOnWinUI.Persistence.Configurations;

internal sealed class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(warehouse => warehouse.ProductId);

        builder.Property(warehouse => warehouse.ProductId)
            .HasColumnName(nameof(Product.Id))
            .HasConversion(id => id.Value, value => new ProductId(value));

        builder.HasMany(warehouse => warehouse.DomainEvents);
    }
}

// "I’m limited by the technology of my time"
// © Howard Stark

// Now it's impossible to have TPH (Table Per Hierarchy) with owned types.
// Related issue: https://github.com/dotnet/efcore/issues/9630

//internal sealed class WarehouseEventBaseTypeConfiguration : IEntityTypeConfiguration<WarehouseEventBase>
//{
//    public void Configure(EntityTypeBuilder<WarehouseEventBase> builder)
//    {
//        builder.HasKey(@event => @event.ProductId);

//        builder.Property(@event => @event.ProductId)
//            .HasColumnName(nameof(Product.Id))
//            .HasConversion(id => id.Value, value => new ProductId(value));

//        builder.HasDiscriminator<string>(nameof(WarehouseEventBase))
//            .HasValue<WarehouseCreatedEvent>(nameof(WarehouseCreatedEvent))
//            .HasValue<ProductsShippedEvent>(nameof(ProductsShippedEvent))
//            .HasValue<ProductsMissedEvent>(nameof(ProductsMissedEvent))
//            .HasValue<ProductsReceivedEvent>(nameof(ProductsReceivedEvent));
//    }
//}