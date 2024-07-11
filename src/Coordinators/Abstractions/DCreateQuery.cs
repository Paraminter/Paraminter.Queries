namespace Paraminter.Queries.Coordinators;

/// <summary>Creates a query.</summary>
/// <typeparam name="TQuery">The type of the created query.</typeparam>
/// <typeparam name="TQueryFactory">The type used to create the query.</typeparam>
/// <param name="queryFactory">The factory used to create the query.</param>
/// <returns>The created query.</returns>
public delegate TQuery DCreateQuery<out TQuery, in TQueryFactory>(TQueryFactory queryFactory)
    where TQuery : IQuery;
