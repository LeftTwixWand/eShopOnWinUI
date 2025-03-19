using Inventory.Domain.Documents;
using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record AttachedDocumentIdMustNotBeEmptyRule(DocumentId DocumentId) : IBusinessRule
{
    public string Message => "Attached document must not be empty.";

    public bool BrokenWhen => DocumentId.IsEmpty;
}