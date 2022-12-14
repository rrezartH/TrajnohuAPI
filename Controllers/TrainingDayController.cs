using Microsoft.AspNetCore.Mvc;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Services;

namespace TrajnohuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : ControllerBase
    {
        private readonly TrainingDayService _trainingDayService;

        public TrainingDayController(TrainingDayService trainingDayService)
        {
            _trainingDayService = trainingDayService;
        }

        [HttpGet("get-fitness-plan-training-days-by-id{id}")]
        public async Task<ActionResult<ICollection<GetTrainingDayDTO>>> GetFitnessPlanTrainingDaysById(int id)
        {
            return await _trainingDayService.GetFitnessPlanTrainingDaysById(id);
        }

        [HttpPost("add-training-day-to-fitness-plan-by-id/{fitnessPlanId}")]
        public async Task<ActionResult> AddTrainingDayToFitnessPlanById(int fitnessPlanId, AddTrainingDayDTO addTrainingDTO)
        {          
            return await _trainingDayService.AddTrainingDayToFitnessPlan(fitnessPlanId, addTrainingDTO);
        }

        [HttpPost("add-exercises-to-training-day-by-id/{trainingDayId}")]
        public async Task<ActionResult> AddExercisesToTrainingDayById(int trainingDayId, int[] exerciseIds)
        {
            return await _trainingDayService.AddExercisesToTrainingDayById(trainingDayId, exerciseIds); ;
        }

        [HttpPut("update-training-day/{id}")]
        public async Task<ActionResult> UpdateTrainingDay(int id, UpdateTrainingDayDTO updateTrainingDayDTO)
        {
            return await _trainingDayService.UpdateTrainingDay(id, updateTrainingDayDTO);
        }

        [HttpDelete("remove-exercises-from-training-day/{id}")]
        public async Task<ActionResult> RemoveExercisesFromTrainingDay(int id, int[] exerciseIds)
        {
            return await _trainingDayService.RemoveExercisesFromTrainingDay(id, exerciseIds);
        }

        [HttpDelete("delete-training-by-id/{id}")]
        public async Task<ActionResult> DeleteTrainingDayById(int id)
        {
            return await _trainingDayService.DeleteTrainingDay(id); ;
        }
    }
}
