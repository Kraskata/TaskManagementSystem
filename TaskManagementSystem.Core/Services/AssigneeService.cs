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

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Assignee()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();    
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Assignee>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserHasAssignmentsAsync(string userId)
        {
            return await repository.AllReadOnly<Assignment>()
                .AnyAsync(a => a.WorkerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Assignee>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
