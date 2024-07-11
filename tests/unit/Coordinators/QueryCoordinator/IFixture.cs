﻿namespace Paraminter.Queries.Coordinators;

using Moq;

internal interface IFixture<TQuery, TResponse, TQueryFactory>
    where TQuery : IQuery
    where TQueryFactory : class
{
    public abstract IQueryCoordinator<TQuery, TResponse, TQueryFactory> Sut { get; }

    public abstract Mock<TQueryFactory> QueryFactoryMock { get; }
    public abstract Mock<IQueryHandler<TQuery, TResponse>> QueryHandlerMock { get; }
}