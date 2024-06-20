using SellX.Domain.SeedWork;

namespace SellX.Domain.Providers.Events;
public record ProviderCreatedEvent(ProviderId ProviderId) : DomainEventBase;