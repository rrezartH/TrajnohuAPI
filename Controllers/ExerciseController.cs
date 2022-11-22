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
            var fitnessExercise = await _exerciseService.GetExerciseById(id);
            if (fitnessExercise == null)
                return NotFound("This exercise doesn't exist!");
            return Ok(fitnessExercise);
        }

        [HttpPost("add-exercise")]
        public async Task<ActionResult> AddExercise(AddExerciseDTO addFitnessExerciseDTO)
        {
            if (addFitnessExerciseDTO == null)
                return BadRequest("A fitness exercise can't be null!");
            await _exerciseService.AddExercise(addFitnessExerciseDTO);
            return Ok("You added a fitness exercise succesfully!");
        }

        [HttpPut("update-exercise/{id}")]
        public async Task<ActionResult> UpdateExercise(int id, UpdateExerciseDTO updateFitnessExerciseDTO)
        {
            if (updateFitnessExerciseDTO == null)
                return BadRequest("A fitness exercise can't be null!");

            if (await _exerciseService.UpdateExercise(id, updateFitnessExerciseDTO))
                return Ok("You have updated the fitness exercise succesfully!");

            return NotFound("The fitness exercise with this ID couldn't be found!");
        }

        [HttpDelete("delete-exercise/{id}")]
        public async Task<ActionResult> DeleteExercise(int id)
        {
            if (await _exerciseService.DeleteExerciseById(id))
                return Ok("You have deleted the fitness exercise succesfully!");
            return NotFound("The fitness exercise with this ID couldn't be found!");
        }
    }
}
