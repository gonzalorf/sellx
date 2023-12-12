using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;
using SellX.Domain.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quartz;
using SellX.Infrastructure.Outbox;
using SellX.Infrastructure.Domain;

namespace SellX.Infrastructure.BackgroundJobs;
[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob : IJob
{
    private readonly System.IServiceProvider serviceProvider;

    public ProcessOutboxMessagesJob(System.IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var messagesUnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        var outboxMessageRepository = serviceProvider.GetRequiredService<IOutboxMessageRepository>();

        var messages = await outboxMessageRepository.GetUnprocessed(10);

        foreach (var message in messages)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                    message.Data
                    , new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore,
                    }
                );

                if (domainEvent is null)
                {
                    continue;
                }

                try
                {
                    var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();
                    var eventUnitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var currentUserService = scope.ServiceProvider.GetRequiredService<ICurrentUserService>();
                    var domainEventsDispatcher = scope.ServiceProvider.GetRequiredService<IDomainEventsDispatcher>();

                    currentUserService.OverrideTenantId(message.TenantId);
                    currentUserService.OverrideUserId(message.UserId == null ? null : new UserId(message.UserId.Value));

                    await publisher.Publish(domainEvent, context.CancellationToken);

                    await domainEventsDispatcher.DispatchEventsAsync();

                    message.ProcessedDate = DateTime.Now;

                    _ = await eventUnitOfWork.CommitAsync(context.CancellationToken);
                }
                catch (Exception pubEx)
                {
                    message.Error = pubEx.Message;
                }
            }
            catch (Exception)
            {
            }
        }

        _ = await messagesUnitOfWork.CommitAsync(context.CancellationToken);
    }
}
