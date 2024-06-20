namespace SellX.Domain.SeedWork;
public interface IParameterRepository
{
    Task<T> Get<T>(string name);
}
