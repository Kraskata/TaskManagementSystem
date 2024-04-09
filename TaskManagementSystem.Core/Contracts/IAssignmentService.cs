using TaskManagementSystem.Core.Enumerations;
using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Core.Models.Home;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentIndexServiceModel>> NewestFourAssignmentsAsync();

        Task<IEnumerable<AssignmentCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(AssignmentFormModel model, int assigneeId);

        Task<AssignmentQueryServiceModel> AllAsync(
            string? category = null,
            string? searchItem = null,
            AssignmentSorting sorting = AssignmentSorting.Newest,
            int currentPage = 1,
            int assignmentsPerPage = 4);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<AssignmentServiceModel>> AllAssignmentsByAssigneeIdAsync(int assigneeId);

        Task<IEnumerable<AssignmentServiceModel>> AllAssignmentsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<AssignmentDetailsServiceModel> AssignmentDetailsByIdAsync(int id);

        Task EditAsync(int assignmentId, AssignmentFormModel model);

        Task<bool> HasAssigneeWithIdAsync(int assignmentId, string userId);

        Task<AssignmentFormModel?> GetAssignmentFormModelByIdAsync(int id);

        Task DeleteAsync(int assignmentId);

        Task<bool> IsAcceptedAsync(int assignmentId);

        Task<bool> IsAcceptedByUserWithIdAsync(int assignmentId, string userId);

        Task AcceptAsync(int id, string userId);

        Task LeaveAsync(int assignmentId, string userId);
    }
}
