using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Quartz;
using SellX.API.Middleware;
using SellX.API.OptionsConfig;
using SellX.API.Services;
using SellX.Application.Configuration.Services;
using SellX.Application.Usuarios.Services;
using SellX.Infrastructure.BackgroundJobs;
using SellX.Infrastructure.Security;
using SellX.Application;
using SellX.Infrastructure;

namespace SellX.API;
public class Program
{
    [Obsolete]
    public static void Main(string[] args)
    {
        //var culture = new CultureInfo("es-AR");
        //CultureInfo.DefaultThreadCurrentCulture = culture;
        //CultureInfo.DefaultThreadCurrentUICulture = culture;
        //CultureInfo.CurrentCulture = culture;
        //CultureInfo.CurrentUICulture = culture;

        var builder = WebApplication.CreateBuilder(args);

        //_ = builder.Services.Configure<RequestLocalizationOptions>(options =>
        //{
        //    options.DefaultRequestCulture = new RequestCulture("es-AR");
        //    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("es-AR") };
        //});

        // Add services to the container.
        _ = builder.Services.AddAuthorization();

#if DEBUG
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JWTToken_Auth_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
            c.CustomSchemaIds(x => x.FullName);
        });
#endif

        // Endpoint Modules
        _ = builder.Services.AddCarter();

        // MediatR - CQRS
        _ = builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // Current User
        _ = builder.Services.AddHttpContextAccessor();
        _ = builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Clean Architecture
        _ = builder.Services.AddApplication();
        _ = builder.Services.AddInfrastructure(builder.Configuration);

        // Security
        _ = builder.Services.ConfigureOptions<JwtOptionsConfig>();
        _ = builder.Services.ConfigureOptions<JwtBearerOptionsConfig>();
        _ = builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        _ = builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerOptionsConfig>();
        _ = builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

        // Background Jobs
        _ = builder.Services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

            _ = configure.AddJob<ProcessOutboxMessagesJob>(jobKey)
            .AddTrigger(
                trigger =>
                trigger.ForJob(jobKey)
                .WithSimpleSchedule(
                    schedule =>
                    schedule.WithIntervalInSeconds(20).RepeatForever()
                    ));

            configure.UseMicrosoftDependencyInjectionJobFactory();
        }
        );
        _ = builder.Services.AddQuartzHostedService();

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseCors("AllowAll");

        _ = app.UseAuthorization();

        // Middlewares
        _ = app.UseUnhandledException();

        _ = app.MapCarter();

        app.Run();
    }
}
