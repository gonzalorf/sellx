namespace SellX.Domain.SeedWork;

public abstract class AuditableEntity<TIdType> : Entity<TIdType>, IAuditableEntity where TIdType : TypedIdValueBase
{
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }

    protected AuditableEntity(TIdType id) : base(id) { }
    protected AuditableEntity() { }

}
