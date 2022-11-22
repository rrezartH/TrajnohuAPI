using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.DTOs;

namespace TrajnohuAPI.Data.Services
{
    public class FitnessPlanService
    {
        private readonly TrajnohuDbContext _context;
        private readonly IMapper _mapper;

        public FitnessPlanService(TrajnohuDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetFitnessPlanDTO> GetFitnessPlanById(int id)
        {
            var dbFitnessPlan = await _context.FitnessPlans
                                                .Where(p => p.Id == id)
                                                    .Select(pl => new GetFitnessPlanDTO
                                                    {
                                                        Name = pl.Name,
                                                        UserId = pl.UserId,
                                                        TrainingDays = pl.TrainingDays!.Select(t => new TrainingDayDTO
                                                        {
                                                            Name = t.Name,
                                                            Exercises = t.TrainingDay_Exercises!.Select(e => _mapper.Map<GetExerciseDTO>(e.FitnessExercise))
                                                                                                .ToList()
                                                        })
                                                        .ToList()
                                                    })
                                                    .FirstOrDefaultAsync();
            return dbFitnessPlan;
        }
    }
}