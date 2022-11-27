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
            var fitnessPlan = await _fitnessPlanService.GetFitnessPlanById(id);
            if (fitnessPlan == null)
                return NotFound("This fitness plan doesn't exist!");
            return Ok(fitnessPlan);
        }

        [HttpGet("get-fitness-plans-by-user-id/{id}")]
        public async Task<ActionResult<List<GetFitnessPlanDTO>>> GetFitnessPlansByUserId(int id)
        {
            var dbFitnessPlans = await _fitnessPlanService.GetFitnessPlansByUserId(id);
            if (!dbFitnessPlans.Any())
                return NotFound("This user doesn't have any fitness plans!");
            return Ok(dbFitnessPlans);
        }

        [HttpPost("add-fitness-plan")]
        public async Task<ActionResult<FitnessPlan>> AddFitnessPlan(AddFitnessPlanDTO fitnessPlanDTO)
        {
            if (fitnessPlanDTO == null)
                return BadRequest("You can't add an empty fitness plan!");
            await _fitnessPlanService.AddFitnessPlan(fitnessPlanDTO);
            return Ok("You added a fitness plan succesfully!");
        }
    }
}
