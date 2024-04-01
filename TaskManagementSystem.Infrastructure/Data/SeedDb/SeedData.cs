using Microsoft.AspNetCore.Identity;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser AssigneeUser { get; set; }

        public IdentityUser GuestUser { get; set; }

        public Assignee Assignee { get; set; }

        public Category MinimalCategory { get; set; }

        public Category HighThreatCategory { get; set; }

        public Category CriticalCategory { get; set; }

        public Assignment FirstAssignment { get; set; }

        public Assignment SecondAssignment { get; set; }

        public Assignment ThirdAssignment { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAssignees();
            SeedCategories();
            SeedAssignments();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AssigneeUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AssigneeUser.PasswordHash =
                 hasher.HashPassword(AssigneeUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AssigneeUser, "guest123");
        }

        private void SeedAssignees()
        {
            Assignee = new Assignee()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AssigneeUser.Id
            };
        }

        private void SeedCategories()
        {
            MinimalCategory = new Category()
            {
                Id = 1,
                Name = "Minimal"
            };

            HighThreatCategory = new Category()
            {
                Id = 2,
                Name = "High Threat"
            };

            CriticalCategory = new Category()
            {
                Id = 3,
                Name = "Critical"
            };
        }

        private void SeedAssignments()
        {
            FirstAssignment = new Assignment()
            {
                Id = 1,
                Title = "Domain Tables",
                Description = "The domain tables have the wrong properties.",
                Paid = 2100.00M,
                Assigned = "03/27/2024",
                DoneBy = "04/05/2024",
                CategoryId = CriticalCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };

            SecondAssignment = new Assignment()
            {
                Id = 2,
                Title = "More Data Seeded Needed (Testing Purposes)",
                Description = "We require more guest users, alongside a new level of threat inside the categories (modify the domain tables).",
                Paid = 2100.00M,
                Assigned = "03/23/2024",
                DoneBy = "05/22/2024",
                CategoryId = MinimalCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };

            ThirdAssignment = new Assignment()
            {
                Id = 3,
                Title = "Pressure Test",
                Description = "Find a way to test if the application is durable to pressure.",
                Paid = 2100.00M,
                Assigned = "03/01/2024",
                DoneBy = "04/15/2024",
                CategoryId = HighThreatCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };
        }

    }
}
