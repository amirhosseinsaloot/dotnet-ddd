namespace DomainDrivenDesign.Domain.Exceptions;

/// <summary>
/// Represents errors that occur when an attempt was made to save a duplicate record .
/// </summary>
public sealed class DuplicateException : BaseException
{
    public DuplicateException(ExceptionCode code, string? message = null)
        : base(HttpStatusCode.Conflict, code, message)
    {
    }
}
