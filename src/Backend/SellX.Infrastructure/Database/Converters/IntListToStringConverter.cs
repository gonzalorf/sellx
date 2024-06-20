using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SellX.Infrastructure.Database.Converters;
public class IntListToStringConverter : ValueConverter<IReadOnlyCollection<int>, string>
{
    public IntListToStringConverter() : base(
         i => string.Join(",", i),
            s => string.IsNullOrWhiteSpace(s) ? new List<int>() : s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToList())
    { }
}
