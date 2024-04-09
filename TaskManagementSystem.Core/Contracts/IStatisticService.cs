using TaskManagementSystem.Core.Models.Statistics;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
