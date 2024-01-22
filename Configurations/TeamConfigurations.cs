using MarialaTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarialaTemplate.Configurations
{
    public class TeamConfigurations : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(64);

        }
    }
}
