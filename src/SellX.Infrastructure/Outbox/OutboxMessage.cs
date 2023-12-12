using SellX.Domain.SeedWork;

namespace SellX.Infrastructure.Outbox;
public class OutboxMessage
{
    public Guid Id { get; set; }

    public TenantId? TenantId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime OccurredOn { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Data { get; set; } = string.Empty;

    public DateTime? ProcessedDate { get; set; }

    public string Error { get; set; } = string.Empty;

    private OutboxMessage()
    {

    }

    public OutboxMessage(TenantId tenantId, Guid? userId, DateTime occurredOn, string type, string data)
    {
        Id = Guid.NewGuid();
        TenantId = tenantId;
        UserId = userId;
        OccurredOn = occurredOn;
        Type = type;
        Data = data;
    }
}
