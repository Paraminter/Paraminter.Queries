namespace Paraminter.Queries.Handlers;

using Paraminter.Queries.Collectors;

/// <summary>Handles queries.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TQueryResponseCollector">The type collecting the responses from handling queries.</typeparam>
public interface IQueryHandler<in TQuery, in TQueryResponseCollector>
    where TQuery : IQuery
    where TQueryResponseCollector : IQueryResponseCollector
{
    /// <summary>Handles the provided query.</summary>
    /// <param name="query">The handled query.</param>
    /// <param name="queryResponseCollector">Collects the response from handling the query.</param>
    public abstract void Handle(TQuery query, TQueryResponseCollector queryResponseCollector);
}
