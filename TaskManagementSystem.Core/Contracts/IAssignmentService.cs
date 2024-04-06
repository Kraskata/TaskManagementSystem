using TaskManagementSystem.Core.Models.Home;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentIndexServiceModel>> NewestThreeAssignmentsAsync();
    }
}
