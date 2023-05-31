using System.Linq.Expressions;

namespace DomainDrivenDesign.Domain.Interfaces.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity, IAggregateRoot
{
    /// <summary>
    /// Asynchronously find the first element of a sequence based on a predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param> 
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains a TEntity? that contains The entity found.
    /// </returns>
    /// <exception cref="ArgumentNullException">Occured if predicate is null.</exception>
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="limit">Returns a specified range of contiguous elements from a sequence.</param>
    /// <param name="offset">Bypasses a specified number of elements in a sequence and then returns the remaining elements.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>
    ///  A task that represents the asynchronous operation. 
    ///  The task result contains a IList of TEntity that filters a sequence of values based on a predicate that mapped to TEntity.
    /// </returns>
    /// <exception cref="ArgumentNullException">Occured if predicate is null.</exception>
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate
        , int limit, int offset, CancellationToken cancellationToken);

    /// <summary>
    /// Get count of entities based on the given predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>Count of entities based on the given predicate.</returns>
    /// <exception cref="ArgumentNullException">Occured if predicate is null.</exception>
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously determines whether any element of a sequence satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains "true" if any elements in the source sequence pass the test in the specified
    /// predicate; otherwise, "false".</returns>
    /// <exception cref="ArgumentNullException">Occured if predicate is null.</exception>
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously adds given entity that its type is TEntity? to database.
    /// </summary>
    /// <param name="entity">The entity to add that its type is TEntity.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param> 
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// Entity that have been added to database.
    /// </returns>
    /// <exception cref="ArgumentNullException">Occured if entity is null.</exception>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously updates given database model.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    /// <exception cref="ArgumentNullException">Occured if entity is null.</exception>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
