using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Infrastructure.Data.SeedDb
{
    internal class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
                .HasOne(h => h.Category)
                .WithMany(c => c.Assignments)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Assignee)
                .WithMany(a => a.Assignments)
                .HasForeignKey(h => h.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Assignment[] { data.ThirdAssignment, data.FirstAssignment, data.SecondAssignment });
        }
    }
}
