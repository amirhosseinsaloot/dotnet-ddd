using System.Linq.Expressions;
using DomainDrivenDesign.Domain.Entities.TeamAggregate;

namespace DomainDrivenDesign.Domain.Interfaces.Specification;

public abstract class SpecificationBase<TEntity> : ISpecification<TEntity> where TEntity : IAggregateRoot
{
    public Expression<Func<TEntity, bool>> Criteria { get; protected set; } = null!;
}


// Sample usage

// public class SampleSpecification : SpecificationBase<Team>
// {
//     public SampleSpecification()
//     {
//         Criteria = (team) => team.Description == "X";
//     }
// }
