using Core.Entities.Identity;
using Core.Entities.Logging;

namespace Core.Entities.Files;

public class FileModel : IBaseEntity, ICreatedOn
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    public User? User { get; set; }

    public ICollection<EmailsLogFileModel>? EmailsLogFileModels { get; set; }
}