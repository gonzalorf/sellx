using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SellX.Infrastructure.Database.Converters;
public class StringListToStringConverter : ValueConverter<IReadOnlyCollection<string>, string>
{
    public StringListToStringConverter() : base(
         i => string.Join(",", i),
            s => string.IsNullOrWhiteSpace(s) ? new List<string>() : s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(v => v).ToList())
    { }
}
