using System.Text.Json;

namespace DomainDrivenDesign.Api.Dtos.Responses.Shared;

public class ErrorDetails
{
    public ExceptionCode ExceptionCode { get; }

    public string Description { get; }

    public ErrorDetails(ExceptionCode exceptionCode)
    {
        ExceptionCode = exceptionCode;
        Description = exceptionCode.GetDisplayName()!;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
