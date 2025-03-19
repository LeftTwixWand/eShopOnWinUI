using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Warehouses.Rules;

internal sealed record AttachedDocumentIdMustNotBeEmpty(DocumentId DocumentId) : IBusinessRule
{
    public string Message => "Attached document must not be empty.";

    public bool BrokenWhen => DocumentId.IsEmpty;
}