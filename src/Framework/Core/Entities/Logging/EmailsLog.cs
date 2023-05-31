using Core.Entities.Identity;

namespace Core.Entities.Logging;

public class EmailsLog : IBaseEntity, ICreatedOn
{
    public int Id { get; set; }

    public string? ToEmail { get; set; }

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public int? ToUserId { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public User? ToUser { get; set; }

    public ICollection<EmailsLogFileModel>? EmailsLogFileModels { get; set; }
}