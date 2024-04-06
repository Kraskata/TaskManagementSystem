using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Core.Services
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IRepository repository;

        public AssigneeService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Assignee>()
                .AnyAsync(a => a.UserId == userId);
        }

        public Task<bool> UserHasAssignmentsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
