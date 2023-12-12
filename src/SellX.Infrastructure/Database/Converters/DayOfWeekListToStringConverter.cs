using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SellX.Infrastructure.Database.Converters;
public class DayOfWeekListToStringConverter : ValueConverter<IReadOnlyCollection<DayOfWeek>, string>
{
    public DayOfWeekListToStringConverter() : base(
         i => string.Join(",", i),
            s => string.IsNullOrWhiteSpace(s) ? new List<DayOfWeek>() : s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(v => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), v)).ToList())
    { }
}
