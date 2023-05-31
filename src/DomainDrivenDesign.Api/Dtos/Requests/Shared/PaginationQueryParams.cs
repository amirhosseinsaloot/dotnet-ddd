namespace DomainDrivenDesign.Api.Dtos.Requests.Shared;

public record class PaginationQueryParams
{
    public int Offset { get; init; } = 0;

    public int Limit { get; init; } = 10;
}

public class PaginationQueryParamsValidator : CustomAbstractValidator<PaginationQueryParams>
{
    public PaginationQueryParamsValidator()
    {
        RuleFor(paginationQueryParams => paginationQueryParams.Offset).GreaterThanOrEqualTo(0);
        RuleFor(paginationQueryParams => paginationQueryParams.Limit).GreaterThanOrEqualTo(0).LessThanOrEqualTo(50);
    }
}
