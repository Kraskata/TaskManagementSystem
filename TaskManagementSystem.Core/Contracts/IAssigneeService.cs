namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssigneeService
    {
        Task<bool> ExistById(string userId);
    }
}
