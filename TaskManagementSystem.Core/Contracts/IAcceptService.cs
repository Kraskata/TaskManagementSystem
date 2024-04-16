using TaskManagementSystem.Core.Models.Admin;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IAcceptService
    {
        Task<IEnumerable<AcceptServiceModel>> AllAsync();
    }
}