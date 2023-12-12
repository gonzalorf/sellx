﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SellX.Infrastructure.Database.Converters;
public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    { }
}
