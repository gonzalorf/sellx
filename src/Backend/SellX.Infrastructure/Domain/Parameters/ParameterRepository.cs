using SellX.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain.Parameters;
internal class ParameterRepository : IParameterRepository
{
    private readonly ApplicationDbContext context;

    public ParameterRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<T> Get<T>(string name)
    {
        var parameter = await context.Set<Parameter>().SingleAsync(p => p.Name == name);

        return (T)Convert.ChangeType(parameter.Value, typeof(T));
    }
}
