namespace Paraminter;

/// <summary>Coordinates creation and handling of queries.</summary>
/// <typeparam name="TQuery">The type of the created and handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response of handled queries.</typeparam>
/// <typeparam name="TQueryFactory">The type used to create queries.</typeparam>
public interface IQueryCoordinator<TQuery, TResponse, TQueryFactory>
    where TQuery : IQuery
{
    /// <summary>Creates and handles a query.</summary>
    /// <param name="queryCreationDelegate">Creates the query to be handled.</param>
    /// <returns>The response of the created and handled query.</returns>
    public abstract TResponse Handle(
        DCreateQuery<TQuery, TQueryFactory> queryCreationDelegate);
}
