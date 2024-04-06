namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssigneeService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber);

        Task<bool> UserHasAssignmentsAsync(string userId);

        Task CreateAsync(string userId, string phoneNumber);
    }
}
