using eShopOnWinUI.Domain.Products.Rules;
using eShopOnWinUI.Domain.SeedWork.Entities;

namespace eShopOnWinUI.Domain.Products;

public sealed class Product : Entity
{
    private Product(ProductId id, string name, string category, string? description, byte[]? image)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Image = image;
    }

    public ProductId Id { get; private set; }

    public string Name { get; private set; }

    public string Category { get; private set; }

    public string? Description { get; private set; }

    public byte[]? Image { get; private set; }

    public static Product Create(string name, string category, string? description = default, byte[]? image = default)
    {
        CheckRule(new NameMustNotBeEmpty(name));
        CheckRule(new CategoryMustNotBeEmpty(category));

        return new Product(ProductId.New, name, category, description, image);
    }
}