using System.Linq.Expressions;

namespace DomainDrivenDesign.Domain.Interfaces.Specification;

public interface ISpecification<TEntity> where TEntity : IAggregateRoot
{
    public Expression<Func<TEntity, bool>> Criteria { get; }
}
