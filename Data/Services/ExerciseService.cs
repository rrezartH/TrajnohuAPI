using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data.Services
{
    public class ExerciseService
    {
        private readonly TrajnohuDbContext _context;
        private readonly IMapper _mapper;

        public ExerciseService(TrajnohuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetExerciseDTO>> GetExercises()
        {
            return _mapper.Map<List<GetExerciseDTO>>(await _context.Exercises.ToListAsync());
        }

        public async Task<ActionResult> GetExerciseById(int id)
        {
            var mappedExercise = _mapper.Map<GetExerciseDTO>(await _context.Exercises.FindAsync(id));
            if (mappedExercise == null)
                return new NotFoundObjectResult("Exercise couldn't be found.");
            return new OkObjectResult(mappedExercise);
        }

        public async Task<ActionResult> AddExercise(AddExerciseDTO addExerciseDTO)
        {
            if (addExerciseDTO == null)
                return new BadRequestObjectResult("A fitness exercise can't be null!");
            var fitnessExercise = _mapper.Map<Exercise>(addExerciseDTO);
            await _context.Exercises.AddAsync(fitnessExercise);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Exercise added succesfully.");
        }

        public async Task<ActionResult> UpdateExercise(int id, UpdateExerciseDTO updateExerciseDTO)
        {
            if (updateExerciseDTO == null)
                return new BadRequestObjectResult("A fitness exercise can't be null!");

            var dbExercise = await _context.Exercises.FindAsync(id);
            if (dbExercise == null)
                return new NotFoundObjectResult("This exercise doesn't exist.");

            dbExercise.Name = updateExerciseDTO.Name ?? dbExercise.Name;
            dbExercise.BodyTarget = updateExerciseDTO.BodyTarget ?? dbExercise.BodyTarget;
            dbExercise.BodyPart = updateExerciseDTO.BodyPart ?? dbExercise.BodyPart;
            dbExercise.Equipment = updateExerciseDTO.Equipment ?? dbExercise.Equipment;
            dbExercise.GifURL = updateExerciseDTO.GifURL ?? dbExercise.GifURL;
            dbExercise.IsHomeExercise = updateExerciseDTO.IsHomeExercise;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Exercise updated succesfully.");
        }

        public async Task<ActionResult> DeleteExerciseById(int id)
        {
            var dbExercise = await _context.Exercises.FindAsync(id);
            if (dbExercise == null)
                return new NotFoundObjectResult("This exercise doesn't exist.");

            _context.Exercises.Remove(dbExercise);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Exercise deleted succesfully!");
        }
    }
}
