namespace DomainDrivenDesign.Api.Exceptions;

/// <summary>
/// Represents errors that occur when invalid arguments passed.
/// </summary>
public sealed class BadRequestException : BaseException
{
    public BadRequestException(ExceptionCode code, string? message = null)
        : base(HttpStatusCode.BadRequest, code, message)
    {
    }
}
