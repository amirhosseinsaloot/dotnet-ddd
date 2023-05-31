namespace DomainDrivenDesign.Api.Dtos.Responses.Shared;

public record class PaginatedResponse<T> where T : class
{
    public List<T> Items { get; init; } = null!;

    public int TotalCount { get; init; }
}
