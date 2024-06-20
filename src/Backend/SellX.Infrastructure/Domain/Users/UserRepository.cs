using Microsoft.EntityFrameworkCore;
using SellX.Domain.Users;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain.Users;
public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext context;

    public UserRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(User user)
    {
        _ = await context.Users.AddAsync(user);
    }

    public void Remove(User user)
    {
        _ = context.Users.Remove(user);
    }

    public void Update(User user)
    {
        _ = context.Users.Update(user);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await context.Users.SingleOrDefaultAsync(p => p.Email == email);
    }

    public async Task<User?> GetByLogin(string login)
    {
        return await context.Users.IgnoreQueryFilters().SingleOrDefaultAsync(p => p.Login == login);
    }

    public async Task<User?> GetById(UserId id)
    {
        return await context.Users.SingleOrDefaultAsync(p => p.Id == id);
    }
}
