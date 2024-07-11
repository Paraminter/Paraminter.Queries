namespace Paraminter.Queries.Coordinators;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullQueryFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object, object>(null!, Mock.Of<IQueryHandler<IQuery, object>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullQueryHandler_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object, object>(Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<object>(), Mock.Of<IQueryHandler<IQuery, object>>());

        Assert.NotNull(result);
    }

    private static QueryCoordinator<TQuery, TResponse, TQueryFactory> Target<TQuery, TResponse, TQueryFactory>(
        TQueryFactory queryFactory,
        IQueryHandler<TQuery, TResponse> queryHandler)
        where TQuery : IQuery
    {
        return new QueryCoordinator<TQuery, TResponse, TQueryFactory>(queryFactory, queryHandler);
    }
}
