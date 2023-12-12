using SellX.Application.Common.Services;

namespace SellX.Infrastructure.Services;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}
