using SellX.Domain.SeedWork;

namespace SellX.Domain.Users.Events;
public record LoginPerformedEvent(UserId UserId) : DomainEventBase;