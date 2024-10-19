﻿namespace Paraminter.Cqs;

using System.Threading.Tasks;

/// <summary>Handles queries.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response of the query handler.</typeparam>
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery
{
    /// <summary>Handles the provided query.</summary>
    /// <param name="query">The handled query.</param>
    /// <returns>The response of the query handler.</returns>
    public abstract Task<TResponse> Handle(TQuery query);
}
