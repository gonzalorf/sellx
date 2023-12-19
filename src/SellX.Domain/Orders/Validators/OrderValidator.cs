using FluentValidation;
using SellX.Domain.Orders.Exceptions;

namespace SellX.Domain.Orders;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(p => p.Quantity).GreaterThan(0);
    }

    public static void ValidateOrder(Order order)
    {
        var validator = new OrderValidator();
        var validationResult = validator.Validate(order);

        if (!validationResult.IsValid)
        {
            throw new OrderInvalidStateException(validationResult.ToString());
        }
    }
}