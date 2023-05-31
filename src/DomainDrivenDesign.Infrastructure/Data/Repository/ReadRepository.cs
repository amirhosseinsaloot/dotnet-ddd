using DomainDrivenDesign.Domain.Interfaces;
using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Domain.Interfaces.Specification;

namespace DomainDrivenDesign.Infrastructure.Data.Repository;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IAggregateRoot
{
    protected readonly DbSet<TEntity> _dbSet;

    public ReadRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(specification.Criteria).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<TEntity>?> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(specification.Criteria).ToListAsync(cancellationToken);
    }
}

