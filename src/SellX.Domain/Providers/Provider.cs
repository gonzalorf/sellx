using SellX.Domain.SeedWork;

namespace SellX.Domain.Providers;

public class Provider : AuditableEntity<ProviderId>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string BankAccountNumber { get; private set; } = string.Empty;
    public string BankAccountAlias { get; private set; } = string.Empty;
}
