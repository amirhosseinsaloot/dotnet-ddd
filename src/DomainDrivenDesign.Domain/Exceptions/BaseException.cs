namespace DomainDrivenDesign.Domain.Exceptions;

/// <summary>
/// Represents errors that occur during execution of application with appropriate status code.
/// </summary>
public abstract class BaseException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public ExceptionCode Code { get; }

    protected BaseException(HttpStatusCode httpStatusCode, ExceptionCode code, string? message = null)
        : base(message)
    {
        HttpStatusCode = httpStatusCode;
        Code = code;
    }
}
