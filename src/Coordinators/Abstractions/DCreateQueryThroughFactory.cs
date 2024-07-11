namespace Paraminter.Queries.Coordinators;

/// <summary>Creates a query.</summary>
/// <typeparam name="TQueryFactory">The type used to create the query.</typeparam>
/// <typeparam name="TQuery">The type of the created query.</typeparam>
/// <param name="queryFactory">The factory used to create the query.</param>
/// <returns>The created query.</returns>
public delegate TQuery DCreateQueryThroughFactory<in TQueryFactory, out TQuery>(TQueryFactory queryFactory)
    where TQuery : IQuery;
