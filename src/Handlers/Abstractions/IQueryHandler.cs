namespace Paraminter.Queries.Handlers;

/// <summary>Handles queries.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponseCollector">The type collecting the responses from handling queries.</typeparam>
public interface IQueryHandler<in TQuery, in TResponseCollector>
    where TQuery : IQuery
{
    /// <summary>Handles the provided query.</summary>
    /// <param name="query">The handled query.</param>
    /// <param name="responseCollector">Collects the response from handling the query.</param>
    public abstract void Handle(TQuery query, TResponseCollector responseCollector);
}
