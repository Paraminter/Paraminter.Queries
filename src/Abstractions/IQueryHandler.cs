namespace Paraminter;

/// <summary>Handles queries.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response of handled queries.</typeparam>
public interface IQueryHandler<in TQuery, out TResponse>
    where TQuery : IQuery
{
    /// <summary>Handles the provided query.</summary>
    /// <param name="query">The handled query.</param>
    /// <returns>The response of the handled query.</returns>
    public abstract TResponse Handle(TQuery query);
}
