using eShopOnWinUI.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopOnWinUI.Persistence.Configurations;

internal sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
            .HasColumnName(nameof(Product.Id))
            .HasConversion(id => id.Value, value => new ProductId(value));

        builder.Property(product => product.Name)
            .HasColumnName(nameof(Product.Name))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.Category)
            .HasColumnName(nameof(Product.Category))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasColumnName(nameof(Product.Description))
            .HasMaxLength(1000);

        builder.Property(product => product.Image)
            .HasColumnName(nameof(Product.Image));
    }
}