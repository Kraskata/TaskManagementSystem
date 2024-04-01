using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Infrastructure.Data.SeedDb
{
    internal class AssigneeConfiguration : IEntityTypeConfiguration<Assignee>
    {
        public void Configure(EntityTypeBuilder<Assignee> builder)
        {
            var data = new SeedData();

            builder.HasData(new Assignee[] { data.Assignee });
        }
    }
}
