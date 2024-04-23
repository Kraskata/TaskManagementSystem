using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignee;
using TaskManagementSystem.Core.Services;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;
using TaskManagementSystem.Tests.Mocks;
using static TaskManagementSystem.Tests.Mocks.TestDatabaseSeed;
using static TaskManagementSystem.Tests.Mocks.UserManagerMock;

namespace TaskManagementSystem.Tests.Services
{
    public class AssigneeServiceTests
    {
        private TaskManagementDbContext context;

        private IRepository repository;

        private IAssigneeService assigneeService;

        private Assignee? assignee;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<TaskManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskManagementSystemDb")
                .Options;

            context = new TaskManagementDbContext(options);

            context.Database.EnsureCreated();

            SeedDatabase(context);

            repository = new Repository(context);

            assigneeService = new AssigneeService(repository);
            assignee = await context.Assignees.FirstOrDefaultAsync(m => m.Id == 1);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAssigneeIdAsyncShouldWork()
        {
            var result = await assigneeService.GetAssigneeIdAsync(assignee.UserId);

            Assert.That(result, Is.EqualTo(assignee.Id));
        }
    }
}
