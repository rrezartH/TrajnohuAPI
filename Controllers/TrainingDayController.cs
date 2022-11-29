using Microsoft.AspNetCore.Mvc;
using TrajnohuAPI.Data;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Services;

namespace TrajnohuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : ControllerBase
    {
        private readonly TrajnohuDbContext _context;
        private readonly TrainingDayService _trainingDayService;

        public TrainingDayController(TrainingDayService trainingDayService, TrajnohuDbContext context)
        {
            _context = context;
            _trainingDayService = trainingDayService;
        }

        [HttpGet("get-fitness-plan-training-days-by-id{id}")]
        public async Task<ActionResult<ICollection<GetTrainingDayDTO>>> GetFitnessPlanTrainingDaysById(int id)
        {
            var dbTrainingDay = await _trainingDayService.GetUserTrainingDaysById(id);
            if (dbTrainingDay == null)
                return NotFound("This training day doesn't exist!");
            return Ok(dbTrainingDay);
        }

        [HttpPost("add-training-day-to-fitness-plan-by-id/{fitnessPlanId}")]
        public async Task<ActionResult> AddTrainingDayToFitnessPlanById(int fitnessPlanId, AddTrainingDTO addTrainingDTO)
        {
            if (addTrainingDTO == null)
                return BadRequest("You can't add an empty exercise day!");

            await _trainingDayService.AddTrainingDayToFitnessPlan(fitnessPlanId, addTrainingDTO);
            return Ok();
        }

        [HttpPost("add-exercises-to-training-day-by-id/{trainingDayId}")]
        public async Task<ActionResult> AddExercisesToTrainingDayById(int trainingDayId, int[] exerciseIds)
        {
            if (exerciseIds.Length == 0) return BadRequest("You can't add empty exercises!");

            await _trainingDayService.AddExercisesToTrainingDayById(trainingDayId, exerciseIds);

            return Ok("Exercises were added succesfully!");
        }

        [HttpDelete("delete-training-by-id/{id}")]
        public async Task<ActionResult> DeleteTrainingDayById(int id)
        {
            var dbTrainingDay = await _context.TrainingDays.FindAsync(id);

            if (dbTrainingDay == null) return BadRequest("This training day doesn't exist.");

            await _trainingDayService.DeleteTrainingDay(dbTrainingDay);

            return Ok("This training day was deleted succesfully.");
        }
    }
}
