﻿namespace SellX.Infrastructure.Security;

public class JwtOptions
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string SecurityKey { get; set; }
}
