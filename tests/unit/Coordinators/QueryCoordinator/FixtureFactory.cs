namespace Paraminter.Queries.Coordinators;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TQuery, TResponse, TQueryFactory> Create<TQuery, TResponse, TQueryFactory>()
        where TQuery : IQuery
        where TQueryFactory : class
    {
        Mock<TQueryFactory> queryFactoryMock = new();
        Mock<IQueryHandler<TQuery, TResponse>> queryHandlerMock = new();

        QueryCoordinator<TQuery, TResponse, TQueryFactory> sut = new(queryFactoryMock.Object, queryHandlerMock.Object);

        return new Fixture<TQuery, TResponse, TQueryFactory>(sut, queryFactoryMock, queryHandlerMock);
    }

    private sealed class Fixture<TQuery, TResponse, TQueryFactory>
        : IFixture<TQuery, TResponse, TQueryFactory>
        where TQuery : IQuery
        where TQueryFactory : class
    {
        private readonly IQueryCoordinator<TQuery, TResponse, TQueryFactory> Sut;

        private readonly Mock<TQueryFactory> QueryFactoryMock;
        private readonly Mock<IQueryHandler<TQuery, TResponse>> QueryHandlerMock;

        public Fixture(
            IQueryCoordinator<TQuery, TResponse, TQueryFactory> sut,
            Mock<TQueryFactory> queryFactoryMock,
            Mock<IQueryHandler<TQuery, TResponse>> queryHandlerMock)
        {
            Sut = sut;

            QueryFactoryMock = queryFactoryMock;
            QueryHandlerMock = queryHandlerMock;
        }

        IQueryCoordinator<TQuery, TResponse, TQueryFactory> IFixture<TQuery, TResponse, TQueryFactory>.Sut => Sut;

        Mock<TQueryFactory> IFixture<TQuery, TResponse, TQueryFactory>.QueryFactoryMock => QueryFactoryMock;
        Mock<IQueryHandler<TQuery, TResponse>> IFixture<TQuery, TResponse, TQueryFactory>.QueryHandlerMock => QueryHandlerMock;
    }
}
