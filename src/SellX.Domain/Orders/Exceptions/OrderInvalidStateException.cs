﻿namespace SellX.Domain.Orders.Exceptions;
public class OrderInvalidStateException : ApplicationException
{
    public OrderInvalidStateException(string message) : base(message) { }
}