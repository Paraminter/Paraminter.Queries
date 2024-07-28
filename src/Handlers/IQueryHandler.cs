namespace Paraminter.Queries.Handlers;

/// <summary>Handles queries.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TQueryResponseHandler">The type handling the responses from the query handler.</typeparam>
public interface IQueryHandler<in TQuery, in TQueryResponseHandler>
    where TQuery : IQuery
    where TQueryResponseHandler : IQueryResponseHandler
{
    /// <summary>Handles the provided query.</summary>
    /// <param name="query">The handled query.</param>
    /// <param name="queryResponseHandler">Handles the response from the query handler.</param>
    public abstract void Handle(TQuery query, TQueryResponseHandler queryResponseHandler);
}
