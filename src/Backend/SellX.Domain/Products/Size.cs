using SellX.Domain.Products.Events;
using SellX.Domain.Products.Validators;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public class Size : Entity<SizeId>
{
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal StrikethroughPrice { get; private set; }

    private Size() : base() { }

    private Size(SizeId id, string name, string code, decimal price, decimal strikethroughPrice) : base(id)
    {
        Name = name;
        Code = code;
        Price = price;
        StrikethroughPrice = strikethroughPrice;
    }

    public static Size CreateSize(string name, string code, decimal price, decimal strikethroughPrice)
    {
        var size = new Size(new SizeId(Guid.NewGuid()), name, code, price, strikethroughPrice);
        SizeValidator.ValidateSize(size);       

        return size;
    }
}
