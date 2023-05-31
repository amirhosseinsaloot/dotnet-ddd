namespace DomainDrivenDesign.Domain.Interfaces.Entities;

/// <summary>
/// Provides properties that need implement in entities. 
/// </summary>
public abstract class BaseEntity<T> : IEntity where T : struct
{
    public T Id { get; protected set; }
}
