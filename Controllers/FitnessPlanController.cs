using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Services;

namespace TrajnohuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPlanController : ControllerBase
    {
        private readonly FitnessPlanService _fitnessPlanService;

        public FitnessPlanController(FitnessPlanService fitnessPlanService)
        {
            _fitnessPlanService = fitnessPlanService;
        }

        [HttpGet("get-fitness-plan-by-id/{id}")]
        public async Task<ActionResult<GetFitnessPlanDTO>> GetFitnessPlanById(int id)
        {
            var fitnessPlan = await _fitnessPlanService.GetFitnessPlanById(id);
            return fitnessPlan;
        }
    }
}
