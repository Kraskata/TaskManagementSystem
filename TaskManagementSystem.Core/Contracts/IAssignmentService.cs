using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Core.Models.Home;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentIndexServiceModel>> NewestThreeAssignmentsAsync();

        Task<IEnumerable<AssignmentCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(AssignmentFormModel model, int assigneeId);
    }
}
