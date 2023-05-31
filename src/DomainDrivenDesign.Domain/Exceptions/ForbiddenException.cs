namespace DomainDrivenDesign.Domain.Exceptions;

/// <summary>
/// Represents errors that occur when server understands the request but refuses to authorize it (unauthorized to access intended resource).
/// </summary>
public sealed class ForbiddenException : BaseException
{
    public ForbiddenException(ExceptionCode code, string? message = null)
        : base(HttpStatusCode.Forbidden, code, message)
    {
    }
}
