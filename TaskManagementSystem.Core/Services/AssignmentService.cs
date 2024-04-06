using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Core.Models.Home;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository repository;

        public AssignmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AssignmentCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new AssignmentCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(AssignmentFormModel model, int assigneeId)
        {
            Assignment assignment = new Assignment()
            {
                Description = model.Description,
                AssigneeId = assigneeId,
                CategoryId = model.CategoryId,
                Paid = model.Paid,
                Title = model.Title,
                DoneBy = model.DoneBy,
            };
            await repository.AddAsync(assignment);
            await repository.SaveChangesAsync();

            return assignment.Id;
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
