using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Statistics;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalAssignments = await repository.AllReadOnly<Assignment>()
                .CountAsync();

            int totalAccepted = await repository.AllReadOnly<Assignment>()
                .Where(h => h.WorkerId != null)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalAssignments = totalAssignments,
                TotalAccepted = totalAccepted
            };
        }
    }
}