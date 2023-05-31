using Core.Entities.Tickets;

namespace Infrastructure.Data.EntityConfigurations.Tickets;

public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.Property(p => p.Type).IsRequired().HasMaxLength(30);
    }
}

