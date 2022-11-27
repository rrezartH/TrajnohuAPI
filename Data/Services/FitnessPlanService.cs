using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

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

        public async Task<GetFitnessPlanDTO?> GetFitnessPlanById(int id)
        {
            var dbFitnessPlan = await _context.FitnessPlans
                                                .Where(p => p.Id == id)
                                                    .Select(pl => new GetFitnessPlanDTO
                                                    {
                                                        Name = pl.Name,
                                                        UserId = pl.UserId,
                                                        TrainingDays = pl.TrainingDays!.Select(t => new GetTrainingDayDTO
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

        public async Task<List<GetFitnessPlanDTO>> GetFitnessPlansByUserId(int id)
        {
            var dbFitnessPlans = await _context.FitnessPlans
                                                .Where(p => p.UserId == id)
                                                    .Select(pl => new GetFitnessPlanDTO
                                                    {
                                                        Name = pl.Name,
                                                        UserId = pl.UserId,
                                                        TrainingDays = pl.TrainingDays!.Select(t => new GetTrainingDayDTO
                                                        {
                                                            Name = t.Name,
                                                            Exercises = t.TrainingDay_Exercises!.Select(e => _mapper.Map<GetExerciseDTO>(e.FitnessExercise))
                                                                                                .ToList()
                                                        })
                                                        .ToList()
                                                    })
                                                    .ToListAsync();

            return dbFitnessPlans;
        }

        public async Task<FitnessPlan> AddFitnessPlan(AddFitnessPlanDTO fitnessPlanDTO)
        {
            var fitnessPlan = new FitnessPlan
            {
                Name = fitnessPlanDTO.Name,
                UserId = fitnessPlanDTO.UserId
            };
            await _context.FitnessPlans.AddAsync(fitnessPlan);
            await _context.SaveChangesAsync();

            if (fitnessPlanDTO.TrainingDays != null)
            {
                foreach (AddTrainingDTO tD in fitnessPlanDTO.TrainingDays)
                {
                    var trainingDay = new TrainingDay
                    {
                        Name = tD.Name,
                        FitnessPlanId = fitnessPlan.Id
                    };
                    await _context.TrainingDays.AddAsync(trainingDay);
                    await _context.SaveChangesAsync();

                    if (tD.ExerciseIds != null)
                    {
                        foreach (int exerciseID in tD.ExerciseIds)
                        {
                            var trainingDay_Exercise = new TrainingDay_Exercise
                            {
                                FitnessExerciseId = exerciseID,
                                TrainingDayId = trainingDay.Id
                            };
                            await _context.TrainingDay_Exercises.AddAsync(trainingDay_Exercise);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
            }
            return fitnessPlan;
        }
    }
}