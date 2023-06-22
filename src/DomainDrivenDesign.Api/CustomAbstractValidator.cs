using FluentValidation.AspNetCore;
using FluentValidation.Results;

namespace DomainDrivenDesign.Api;

public abstract class CustomAbstractValidator<TDto> : AbstractValidator<TDto>, IValidatorInterceptor
    where TDto : class, new()
{
    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext,
        ValidationResult result)
    {
        return result.IsValid is false
            ? throw new BadRequestException(ExceptionCode.Default,
                result.Errors.ToString() ?? "Input has validation errors")
            : result;
    }

    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }
}
