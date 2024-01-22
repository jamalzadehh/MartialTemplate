using MarialaTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarialaTemplate.Configurations
{
    public class ServiceConfigurations : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(64);

        }
    }
}
