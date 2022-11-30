using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrajnohuAPI.Data;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Services;

namespace TrajnohuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService fitnessExerciseService)
        {
            _exerciseService = fitnessExerciseService;
        }

        [HttpGet("get-exercises")]
        public async Task<ActionResult<GetExerciseDTO>> GetExercises()
        {
            return Ok(await _exerciseService.GetExercises());
        }

        [HttpGet("get-exercise-by-id/{id}")]
        public async Task<ActionResult<GetExerciseDTO>> GetExerciseById(int id)
        {
            return await _exerciseService.GetExerciseById(id);
        }

        [HttpPost("add-exercise")]
        public async Task<ActionResult> AddExercise(AddExerciseDTO addExerciseDTO)
        {
            return await _exerciseService.AddExercise(addExerciseDTO);
        }

        [HttpPut("update-exercise/{id}")]
        public async Task<ActionResult> UpdateExercise(int id, UpdateExerciseDTO updateExerciseDTO)
        {
            return await _exerciseService.UpdateExercise(id, updateExerciseDTO);
        }

        [HttpDelete("delete-exercise/{id}")]
        public async Task<ActionResult> DeleteExercise(int id)
        {
            return await _exerciseService.DeleteExerciseById(id);
        }
    }
}
 