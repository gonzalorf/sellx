using FluentValidation;
using SellX.Domain.Orders.Exceptions;

namespace SellX.Domain.Orders;

public class OrderDetailValidator : AbstractValidator<OrderDetail>
{
    public OrderDetailValidator()
    {
        RuleFor(p => p.Quantity).GreaterThan(0);
    }

    public static void ValidateOrderDetail(OrderDetail orderDetail)
    {
        var validator = new OrderDetailValidator();
        var validationResult = validator.Validate(orderDetail);

        if (!validationResult.IsValid)
        {
            throw new OrderInvalidStateException(validationResult.ToString());
        }
    }
}