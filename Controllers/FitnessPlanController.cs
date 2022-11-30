using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;
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
            return await _fitnessPlanService.GetFitnessPlanById(id);
        }

        [HttpGet("get-fitness-plans-by-user-id/{id}")]
        public async Task<ActionResult<List<GetFitnessPlanDTO>>> GetFitnessPlansByUserId(int id)
        {
            return await _fitnessPlanService.GetFitnessPlansByUserId(id);
        }

        [HttpPost("add-fitness-plan")]
        public async Task<ActionResult> AddFitnessPlan(AddFitnessPlanDTO fitnessPlanDTO)
        {
            return await _fitnessPlanService.AddFitnessPlan(fitnessPlanDTO);
        }
    }
}
