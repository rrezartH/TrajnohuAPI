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

        public async Task<ActionResult> GetFitnessPlanById(int id)
        {
            var dbFitnessPlan = await _context.FitnessPlans
                                                .Where(p => p.Id == id)
                                                    .Select(pl => new GetFitnessPlanDTO
                                                    {
                                                        Id = pl.Id,
                                                        Name = pl.Name,
                                                        UserId = pl.UserId,
                                                        TrainingDays = pl.TrainingDays!.Select(t => new GetTrainingDayDTO
                                                        {
                                                            Id = t.Id,
                                                            Name = t.Name,
                                                            Exercises = t.TrainingDay_Exercises!.Select(e => _mapper.Map<GetExerciseDTO>(e.FitnessExercise))
                                                                                                .ToList()
                                                        })
                                                        .ToList()
                                                    })
                                                    .FirstOrDefaultAsync();

            if (dbFitnessPlan == null)
                return new NotFoundObjectResult("Fitness plan couldn't be found.");

            return new OkObjectResult(dbFitnessPlan);
        }

        public async Task<ActionResult> GetFitnessPlansByUserId(int id)
        {
            var dbFitnessPlans = await _context.FitnessPlans
                                                .Where(p => p.UserId == id)
                                                    .Select(pl => new GetFitnessPlanDTO
                                                    {
                                                        Id = pl.Id,
                                                        Name = pl.Name,
                                                        UserId = pl.UserId,
                                                        TrainingDays = pl.TrainingDays!.Select(t => new GetTrainingDayDTO
                                                        {
                                                            Id = t.Id,
                                                            Name = t.Name,
                                                            Exercises = t.TrainingDay_Exercises!.Select(e => _mapper.Map<GetExerciseDTO>(e.FitnessExercise))
                                                                                                .ToList()
                                                        })
                                                        .ToList()
                                                    })
                                                    .ToListAsync();

            if (dbFitnessPlans.Count < 1 )
                return new NotFoundObjectResult("There are no fitness plans.");

            return new OkObjectResult(dbFitnessPlans);
        }

        public async Task<ActionResult> AddFitnessPlan(AddFitnessPlanDTO fitnessPlanDTO)
        {
            if (fitnessPlanDTO == null)
                return new BadRequestObjectResult("You can't add an empty fitness plan.");

            var fitnessPlan = new FitnessPlan
            {
                Name = fitnessPlanDTO.Name,
                UserId = fitnessPlanDTO.UserId
            };
            await _context.FitnessPlans.AddAsync(fitnessPlan);
            await _context.SaveChangesAsync();

            if (fitnessPlanDTO.TrainingDays != null)
            {
                foreach (AddTrainingDayDTO tD in fitnessPlanDTO.TrainingDays)
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
            return new OkObjectResult("Fitness plan added succesfully!");
        }
    }
}