namespace DomainDrivenDesign.Api.Dtos.Responses.Shared;

public class ApiResponse
{
    public string? Message { get; }

    protected ApiResponse(string? message)
    {
        Message = message;
    }
}

public class ApiResponse<TData> : ApiResponse where TData : class
{
    public TData? Data { get; }

    public ApiResponse(TData? data, string? message)
        : base(message)
    {
        Data = data;
    }
}
