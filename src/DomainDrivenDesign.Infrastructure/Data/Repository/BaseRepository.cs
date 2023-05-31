using System.Linq.Expressions;
using DomainDrivenDesign.Domain.Interfaces;
using DomainDrivenDesign.Domain.Interfaces.Entities;
using DomainDrivenDesign.Domain.Interfaces.Repositories;

namespace DomainDrivenDesign.Infrastructure.Data.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity, IAggregateRoot
{
    private readonly ApplicationDbContext _dbContext;

    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int limit,
        int offset, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .Skip(offset)
            .Take(limit)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .CountAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .AnyAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
