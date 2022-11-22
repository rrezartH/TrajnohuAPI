using AutoMapper;
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

        public async Task<GetExerciseDTO> GetExerciseById(int id)
        {
            return _mapper.Map<GetExerciseDTO>(await _context.Exercises.FindAsync(id));
        }

        public async Task AddExercise(AddExerciseDTO addExerciseDTO)
        {
            var fitnessExercise = _mapper.Map<Exercise>(addExerciseDTO);
            await _context.Exercises.AddAsync(fitnessExercise);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateExercise(int id, UpdateExerciseDTO updateExerciseDTO)
        {
            var dbExercise = await _context.Exercises.FindAsync(id);
            if (dbExercise == null)
                return false;

            dbExercise.Name = updateExerciseDTO.Name ?? dbExercise.Name;
            dbExercise.BodyTarget = updateExerciseDTO.BodyTarget ?? dbExercise.BodyTarget;
            dbExercise.BodyPart = updateExerciseDTO.BodyPart ?? dbExercise.BodyPart;
            dbExercise.Equipment = updateExerciseDTO.Equipment ?? dbExercise.Equipment;
            dbExercise.GifURL = updateExerciseDTO.GifURL ?? dbExercise.GifURL;
            dbExercise.IsHomeExercise = updateExerciseDTO.IsHomeExercise;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExerciseById(int id)
        {
            var dbExercise = await _context.Exercises.FindAsync(id);
            if (dbExercise == null)
                return false;

            _context.Exercises.Remove(dbExercise);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
