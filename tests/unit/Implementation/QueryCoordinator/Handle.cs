namespace Paraminter;

using Moq;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullQueryCreationDelegate_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IQuery, object, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesQueryAndReturnsResponse()
    {
        var fixture = FixtureFactory.Create<IQuery, object, object>();

        Mock<DCreateQuery<IQuery, object>> queryCreationDelegateMock = new();

        var query = Mock.Of<IQuery>();
        var response = Mock.Of<object>();

        queryCreationDelegateMock.Setup((factory) => factory.Invoke(fixture.QueryFactoryMock.Object)).Returns(query);

        fixture.QueryHandlerMock.Setup((handler) => handler.Handle(query)).Returns(response);

        var result = Target(fixture, queryCreationDelegateMock.Object);

        Assert.Same(response, result);

        fixture.QueryHandlerMock.Verify((handler) => handler.Handle(query), Times.Once);
    }

    private static TResponse Target<TQuery, TResponse, TQueryFactory>(
        IFixture<TQuery, TResponse, TQueryFactory> fixture,
        DCreateQuery<TQuery, TQueryFactory> queryCreationDelegate)
        where TQuery : IQuery
        where TQueryFactory : class
    {
        return fixture.Sut.Handle(queryCreationDelegate);
    }
}
