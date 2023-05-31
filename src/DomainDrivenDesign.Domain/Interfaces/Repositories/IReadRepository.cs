using DomainDrivenDesign.Domain.Interfaces.Specification;

namespace DomainDrivenDesign.Domain.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : class, IAggregateRoot
{
    /// <summary>
    /// Asynchronously finds an entity with the given primary key values.
    /// </summary>
    /// <typeparam name="TId">The type of primary key.</typeparam>
    /// <param name="id">The values of the primary key for the entity to be found.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains entity found.</returns>
    Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

    /// <summary>
    /// Asynchronously find the first element of a sequence based on given specification.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains entity found.</returns>
    Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Filters a sequence of values based on given specification.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    ///  Result contains a List<TEntity?> that filters a sequence of values based on a given specification.
    Task<List<TEntity>?> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
}
