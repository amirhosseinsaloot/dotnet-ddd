using DomainDrivenDesign.Domain.Interfaces;
using DomainDrivenDesign.Domain.Interfaces.Repositories;

namespace DomainDrivenDesign.Infrastructure.Data.Repository;

public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IAggregateRoot
{
    private readonly ApplicationDbContext _dbContext;

    protected readonly DbSet<TEntity> _dbSet;

    public WriteRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    /// <inheritdoc/>
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
