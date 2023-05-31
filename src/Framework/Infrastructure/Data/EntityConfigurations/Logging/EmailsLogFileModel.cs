using Core.Entities.Logging;

namespace Infrastructure.Data.EntityConfigurations.Logging;

public class EmailsLogFileModelConfiguration : IEntityTypeConfiguration<EmailsLogFileModel>
{
    public void Configure(EntityTypeBuilder<EmailsLogFileModel> builder)
    {
        builder.HasIndex(p => p.FileModelId).IsUnique();

        builder.HasOne(p => p.EmailsLog)
               .WithMany(p => p.EmailsLogFileModels)
               .HasForeignKey(p => p.EmailsLogId);

        builder.HasOne(p => p.FileModel)
               .WithMany(p => p.EmailsLogFileModels)
               .HasForeignKey(p => p.FileModelId);
    }
}
