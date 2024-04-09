using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticAPIController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticAPIController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();

            return Ok(result);
        }
    }
}
