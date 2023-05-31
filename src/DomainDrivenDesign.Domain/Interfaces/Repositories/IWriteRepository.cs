namespace DomainDrivenDesign.Domain.Interfaces.Repositories;

public interface IWriteRepository<TEntity> where TEntity : class, IAggregateRoot
{
    /// <summary>
    /// Asynchronously adds given model to database.
    /// </summary>
    /// <param name="entity">Model to be add on database</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains added entity.</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}
