using SellX.Application.Configuration.Commands;
using SellX.Domain.SeedWork;
using MediatR;
using SellX.Infrastructure.Domain;

namespace SellX.Infrastructure.Database.Behaviors;
/// <summary>
/// This behavior is only for Commands, not Queries.
/// </summary>
/// <typeparam name="TRequest">Type of Command.</typeparam>
/// <typeparam name="TResponse">Return type specified in the Command.</typeparam>
public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, ICommand
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IDomainEventsDispatcher domainEventsDispatcher;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork, IDomainEventsDispatcher domainEventsDispatcher)
    {
        this.unitOfWork = unitOfWork;
        this.domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {

        var response = await next();

        await domainEventsDispatcher.DispatchEventsAsync();

        _ = await unitOfWork.CommitAsync(cancellationToken);

        return response;
    }
}
