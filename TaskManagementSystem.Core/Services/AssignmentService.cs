using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Home;
using TaskManagementSystem.Infrastructure.Data.Common;

namespace TaskManagementSystem.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository repository;

        public AssignmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AssignmentIndexServiceModel>> NewestThreeAssignmentsAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Assignment>()
                .OrderBy(a => a.Id)
                .Take(3)
                .Select(a => new AssignmentIndexServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Category = a.Category
                })
                .ToListAsync();
        }
    }
}
