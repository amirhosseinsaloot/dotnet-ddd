using Core.Entities.Logging;

namespace Infrastructure.Data.Configurations.Logging;

public class EmailsLogConfiguration : IEntityTypeConfiguration<EmailsLog>
{
    public void Configure(EntityTypeBuilder<EmailsLog> builder)
    {
        builder.Property(p => p.ToEmail).HasMaxLength(320);

        builder.HasOne(p => p.ToUser)
               .WithMany(p => p.EmailsLogs)
               .HasForeignKey(p => p.ToUserId);
    }
}
