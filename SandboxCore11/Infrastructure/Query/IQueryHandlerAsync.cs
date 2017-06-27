namespace SandboxCore11.Infrastructure.Query
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a query handler.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandlerAsync<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Handles the query asynchronously.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <returns>The query results.</returns>
        Task<TResult> HandleAsync(TQuery query);
    }
}
