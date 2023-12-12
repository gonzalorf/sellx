using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SellX.Application.Common.Services;
using SellX.Application.Services;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;
using SellX.Domain.Tenants;
using SellX.Domain.Users;
using SellX.Infrastructure.Database;
using SellX.Infrastructure.Database.Behaviors;
using SellX.Infrastructure.Database.Interceptors;
using SellX.Infrastructure.Domain;
using SellX.Infrastructure.Domain.Parameters;
using SellX.Infrastructure.Domain.Products;
using SellX.Infrastructure.Domain.Tenants;
using SellX.Infrastructure.Domain.Users;
using SellX.Infrastructure.Outbox;
using SellX.Infrastructure.Services;

namespace SellX.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        _ = services.AddTransient<IDateTimeService, DateTimeService>();
        _ = services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        _ = services.AddScoped<SoftDeleteSaveChangesInterceptor>();
        _ = services.AddScoped<MultiTenancyInterceptor>();
        _ = services.AddScoped<QueryInterceptor>();

        _ = services.AddDbContext<ApplicationDbContext>(options =>
        {
            _ = options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        _ = services.AddScoped<IApplicationDbContext>(option =>
        {
            return option.GetService<ApplicationDbContext>();
        });

        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();

        _ = services.AddScoped<IUserRepository, UserRepository>();
        _ = services.AddScoped<ITenantRepository, TenantRepository>();
        _ = services.AddScoped<IProductRepository, ProductRepository>();

        _ = services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
        _ = services.AddScoped<IOutboxMessageRepository, OutboxMessageRepository>();
        _ = services.AddScoped<IParameterRepository, ParameterRepository>();

        _ = services.AddScoped<IPasswordHashService, PasswordHashService>();

        _ = services.AddMediatR(configuration =>
        {
            _ = configuration.RegisterServicesFromAssemblies(assembly);
            _ = configuration.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        return services;
    }
}
