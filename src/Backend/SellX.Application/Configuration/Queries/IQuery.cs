using MediatR;

namespace SellX.Application.Configuration.Queries;
public interface IQuery<out TResult> : IRequest<TResult>
{
}