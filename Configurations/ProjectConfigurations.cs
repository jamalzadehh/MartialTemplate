using MarialaTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MarialaTemplate.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
         builder.Property(x=>x.Name).IsRequired().HasMaxLength(64);
         builder.Property(x=>x.Description).IsRequired().HasMaxLength(64);
        }
    }
}
