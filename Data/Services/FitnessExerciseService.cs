using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data.Services
{
    public class FitnessExerciseService
    {
        private readonly TrajnohuDbContext _context;
        private readonly IMapper _mapper;

        public FitnessExerciseService(TrajnohuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetFitnessExerciseDTO>> GetFitnessExercises()
        {
            return _mapper.Map<List<GetFitnessExerciseDTO>>(await _context.FitnessExercises.ToListAsync());
        }

        public async Task<GetFitnessExerciseDTO> GetFitnessExercise(int id)
        {
            return _mapper.Map<GetFitnessExerciseDTO>(await _context.FitnessExercises.FindAsync(id));
        }

        public async Task AddFitnessExercise(AddFitnessExerciseDTO addFitnessExerciseDTO)
        {
            var fitnessExercise = _mapper.Map<FitnessExercise>(addFitnessExerciseDTO);
            await _context.FitnessExercises.AddAsync(fitnessExercise);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateFitnessExercise(int id, UpdateFitnesExerciseDTO updateFitnessExerciseDTO)
        {
            var dbFitnessExercise = await _context.FitnessExercises.FindAsync(id);
            if (dbFitnessExercise == null)
                return false;

            dbFitnessExercise.Name = updateFitnessExerciseDTO.Name ?? dbFitnessExercise.Name;
            dbFitnessExercise.BodyTarget = updateFitnessExerciseDTO.BodyTarget ?? dbFitnessExercise.BodyTarget;
            dbFitnessExercise.BodyPart = updateFitnessExerciseDTO.BodyPart ?? dbFitnessExercise.BodyPart;
            dbFitnessExercise.Equipment = updateFitnessExerciseDTO.Equipment ?? dbFitnessExercise.Equipment;
            dbFitnessExercise.GifURL = updateFitnessExerciseDTO.GifURL ?? dbFitnessExercise.GifURL;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFitnessExerciseById(int id)
        {
            var dbFitnessExercise = await _context.FitnessExercises.FindAsync(id);
            if (dbFitnessExercise == null)
                return false;

            _context.FitnessExercises.Remove(dbFitnessExercise);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
