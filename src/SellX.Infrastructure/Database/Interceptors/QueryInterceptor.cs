using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SellX.Infrastructure.Database.Interceptors;
public class QueryInterceptor : DbCommandInterceptor
{
    //public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    //{
    //    return base.ReaderExecuting(command, eventData, result);
    //}

    //public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
    //{
    //    return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    //}

    //public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    //{
    //    return base.NonQueryExecuting(command, eventData, result);
    //}

    //public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    //{
    //    return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    //}

    //public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    //{
    //    return base.ScalarExecuting(command, eventData, result);
    //}

    //public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
    //{
    //    return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    //}
}
