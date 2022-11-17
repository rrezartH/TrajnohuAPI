using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrajnohuAPI.Data;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Services;

namespace TrajnohuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessExerciseController : ControllerBase
    {
        private readonly FitnessExerciseService _fitnessExerciseService;

        public FitnessExerciseController(FitnessExerciseService fitnessExerciseService)
        {
            _fitnessExerciseService = fitnessExerciseService;
        }

        [HttpGet("get-fitness-exercises")]
        public async Task<ActionResult<GetFitnessExerciseDTO>> GetFitnessExercises()
        {
            return Ok(await _fitnessExerciseService.GetFitnessExercises());
        }

        [HttpGet("get-fitness-exercise-by-id/{id}")]
        public async Task<ActionResult<GetFitnessExerciseDTO>> GetFitnessExerciseById(int id)
        {
            var fitnessExercise = await _fitnessExerciseService.GetFitnessExercise(id);
            if (fitnessExercise == null)
                return NotFound("This exercise doesn't exist!");
            return Ok(fitnessExercise);
        }

        [HttpPost("add-fitness-exercise")]
        public async Task<ActionResult> AddFitnessExercise(AddFitnessExerciseDTO addFitnessExerciseDTO)
        {
            if (addFitnessExerciseDTO == null)
                return BadRequest("A fitness exercise can't be null!");
            await _fitnessExerciseService.AddFitnessExercise(addFitnessExerciseDTO);
            return Ok("You added a fitness exercise succesfully!");
        }

        [HttpPut("update-fitness-exercise/{id}")]
        public async Task<ActionResult> UpdateFitnessExercise(int id, UpdateFitnesExerciseDTO updateFitnessExerciseDTO)
        {
            if (updateFitnessExerciseDTO == null)
                return BadRequest("A fitness exercise can't be null!");

            if (await _fitnessExerciseService.UpdateFitnessExercise(id, updateFitnessExerciseDTO))
                return Ok("You have updated the fitness exercise succesfully!");

            return NotFound("The fitness exercise with this ID couldn't be found!");
        }

        [HttpDelete("delete-fitness-exercise/{id}")]
        public async Task<ActionResult> DeleteFitnessExercise(int id)
        {
            if (await _fitnessExerciseService.DeleteFitnessExerciseById(id))
                return Ok("You have deleted the fitness exercise succesfully!");
            return NotFound("The fitness exercise with this ID couldn't be found!");
        }
    }
}
