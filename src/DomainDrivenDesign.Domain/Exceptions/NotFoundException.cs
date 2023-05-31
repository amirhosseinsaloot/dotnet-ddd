namespace DomainDrivenDesign.Domain.Exceptions;

/// <summary>
/// Represents errors when the requested data could not be found.
/// </summary>
public sealed class NotFoundException : BaseException
{
    public NotFoundException(ExceptionCode code, string? message = null)
        : base(HttpStatusCode.NotFound, code, message)
    {
    }
}
