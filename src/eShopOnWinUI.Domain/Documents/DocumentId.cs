namespace eShopOnWinUI.Domain.Documents;

public readonly record struct DocumentId(Guid Value)
{
    public static DocumentId New = new(Guid.NewGuid());

    public static DocumentId Empty = new(Guid.Empty);

    public bool IsEmpty => Value == Guid.Empty;
}