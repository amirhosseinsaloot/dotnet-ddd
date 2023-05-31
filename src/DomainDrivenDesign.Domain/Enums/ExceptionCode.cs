using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Domain.Enums;

public enum ExceptionCode : byte
{
    [Display(Name = "Default")]
    Default = 1,
}
