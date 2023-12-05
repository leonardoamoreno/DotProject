using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotProject.Infra.Data.Mappings
{
    public class TaskMap : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300);

            builder.Property(c => c.ExpirationDate);

            builder.Property(c => c.Status);
        }
    }
}
