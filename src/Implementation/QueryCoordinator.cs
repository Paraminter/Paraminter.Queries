namespace Paraminter;

using System;

/// <inheritdoc cref="IQueryCoordinator{TQuery, TResponse, TQueryFactory}"/>
public sealed class QueryCoordinator<TQuery, TResponse, TQueryFactory>
    : IQueryCoordinator<TQuery, TResponse, TQueryFactory>
    where TQuery : IQuery
{
    private readonly TQueryFactory QueryFactory;
    private readonly IQueryHandler<TQuery, TResponse> QueryHandler;

    /// <summary>Instantiates a <see cref="QueryCoordinator{TQuery, TResponse, TQueryFactory}"/>, coordinating creation and handling of queries.</summary>
    /// <param name="queryFactory">Handles creation of queries.</param>
    /// <param name="queryHandler">Handles queries.</param>
    public QueryCoordinator(
        TQueryFactory queryFactory,
        IQueryHandler<TQuery, TResponse> queryHandler)
    {
        QueryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        QueryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    TResponse IQueryCoordinator<TQuery, TResponse, TQueryFactory>.Handle(
        DCreateQuery<TQuery, TQueryFactory> queryCreationDelegate)
    {
        if (queryCreationDelegate is null)
        {
            throw new ArgumentNullException(nameof(queryCreationDelegate));
        }

        var query = queryCreationDelegate(QueryFactory);

        return QueryHandler.Handle(query);
    }
}
