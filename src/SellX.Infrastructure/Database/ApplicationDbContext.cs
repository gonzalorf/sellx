using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query;
using SellX.Application.Usuarios.Services;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;
using SellX.Domain.Tenants;
using SellX.Domain.Users;
using SellX.Infrastructure.Database.Interceptors;
using SellX.Infrastructure.Domain.Parameters;
using System.Linq.Expressions;

namespace SellX.Infrastructure.Database;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;
    private readonly SoftDeleteSaveChangesInterceptor softDeleteSaveChangesInterceptor;
    private readonly MultiTenancyInterceptor multiTenancyInterceptor;
    private readonly QueryInterceptor queryInterceptor;
    private readonly ICurrentUserService currentUserService;

    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(
        DbContextOptions options
        , AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
        , SoftDeleteSaveChangesInterceptor softDeleteSaveChangesInterceptor
        , MultiTenancyInterceptor multiTenancyInterceptor
        , QueryInterceptor queryInterceptor
        , ICurrentUserService currentUserService) : base(options)
    {
        this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        this.softDeleteSaveChangesInterceptor = softDeleteSaveChangesInterceptor;
        this.multiTenancyInterceptor = multiTenancyInterceptor;
        this.queryInterceptor = queryInterceptor;
        this.currentUserService = currentUserService;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Filtro Multi Tenant y Delete        
        modelBuilder.ApplyGlobalFilters<IEntity>(e =>
            e.TenantId == currentUserService.TenantId
            && !e.Deleted);


#if DEBUG

        // Poblado inicial

        var cityplusTenantId = new TenantId(Guid.Parse("00000001-0001-0001-0001-000000000001"));
        var municipalidadNorteTenantId = new TenantId(Guid.Parse("863e9564-4b31-409d-805f-88465b949f5a"));
        var municipalidadSurTenantId = new TenantId(Guid.Parse("1420a446-4d7b-415f-bb4f-7b8f6f29a349"));

        _ = modelBuilder.Entity<Tenant>().HasData(
            Tenant.CreateTenant(
                cityplusTenantId
                , "Cityplus Argentina"
            )
        );

        _ = modelBuilder.Entity<Tenant>().HasData(
            Tenant.CreateTenant(
                municipalidadNorteTenantId
                , "Municipalidad Norte"
            )
        );

        _ = modelBuilder.Entity<Tenant>().HasData(
            Tenant.CreateTenant(
                municipalidadSurTenantId
                , "Municipalidad Sur"
            )
        );

        var firstUser = User.CreateUser(
            "Steve"
            , "Jobs"
            , "steve@apple.com"
            , "steve"
            , "123"
            );
        firstUser.TenantId = cityplusTenantId;
        _ = modelBuilder.Entity<User>().HasData(
           firstUser
        );

        var firstUserNorte = User.CreateUser(
            "Santiago"
            , "Ayala"
            , "sayala@music.com"
            , "chucaro"
            , "123"
            );
        firstUserNorte.TenantId = municipalidadNorteTenantId;
        _ = modelBuilder.Entity<User>().HasData(
           firstUserNorte
        );

        var firstUserSur = User.CreateUser(
            "Jorge"
            , "Cafrune"
            , "jcafrune@music.com"
            , "turco"
            , "123"
            );
        firstUserSur.TenantId = municipalidadSurTenantId;
        _ = modelBuilder.Entity<User>().HasData(
           firstUserSur
        );


#endif

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
        _ = optionsBuilder.AddInterceptors(softDeleteSaveChangesInterceptor);
        _ = optionsBuilder.AddInterceptors(multiTenancyInterceptor);
        _ = optionsBuilder.AddInterceptors(queryInterceptor);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        _ = configurationBuilder.Properties<string>()
            .HaveMaxLength(256);
    }
}

public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            _ = modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
    }
}

#if DEBUG
public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        _ = optionsBuilder.UseSqlServer("Data Source=localhost\\SQLExpress;Initial Catalog=SellX;persist security info=True;Integrated Security=SSPI;Encrypt=false;");

        return new ApplicationDbContext(optionsBuilder.Options, null, null, null, null, null);
    }
}
#endif

/* ELIMINAR TODAS LAS TABLAS

DECLARE @TableName NVARCHAR(128)
DECLARE @ConstraintName NVARCHAR(128)

-- Eliminar restricciones de clave foránea
DECLARE constraint_cursor CURSOR FOR
SELECT
    t.name AS TableName,
    fk.name AS ConstraintName
FROM
    sys.tables t
INNER JOIN
    sys.foreign_keys fk ON t.object_id = fk.parent_object_id

OPEN constraint_cursor

FETCH NEXT FROM constraint_cursor INTO @TableName, @ConstraintName

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @Sql NVARCHAR(MAX)
    SET @Sql = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' DROP CONSTRAINT ' + QUOTENAME(@ConstraintName)
    EXEC sp_executesql @Sql
    FETCH NEXT FROM constraint_cursor INTO @TableName, @ConstraintName
END

CLOSE constraint_cursor
DEALLOCATE constraint_cursor

-- Eliminar tablas
DECLARE table_cursor CURSOR FOR
SELECT name
FROM sys.tables
WHERE schema_id = SCHEMA_ID('dbo') AND OBJECTPROPERTY(object_id, 'IsMSShipped') = 0

OPEN table_cursor

FETCH NEXT FROM table_cursor INTO @TableName

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @SqlT NVARCHAR(MAX)
    SET @SqlT = 'DROP TABLE ' + QUOTENAME(@TableName)
    EXEC sp_executesql @SqlT
    FETCH NEXT FROM table_cursor INTO @TableName
END

CLOSE table_cursor
DEALLOCATE table_cursor


*/