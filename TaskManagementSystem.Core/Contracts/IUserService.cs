using TaskManagementSystem.Core.Models.Admin.User;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}