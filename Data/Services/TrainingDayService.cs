using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data.Services
{
    public class TrainingDayService
    {
        private readonly TrajnohuDbContext _context;
        private readonly IMapper _mapper;

        public TrainingDayService(TrajnohuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<GetTrainingDayDTO>> GetUserTrainingDaysById(int id)
        {
            var dbTrainingDays = await _context.TrainingDays
                                                .Where(t => t.FitnessPlanId == id)
                                                .Select(td => new GetTrainingDayDTO
                                                {
                                                    Id = td.Id,
                                                    Name = td.Name,
                                                    Exercises = td.TrainingDay_Exercises
                                                                .Where(trr => trr.TrainingDayId == td.Id)
                                                                .Select(tr => _mapper.Map<GetExerciseDTO>(tr.FitnessExercise))
                                                                .ToList()
                                                })
                                                .ToListAsync();

            return dbTrainingDays;
        }

        public async Task AddTrainingDayToFitnessPlan(int fitnessPlanId, AddTrainingDTO addTrainingDTO)
        {
            var trainingDay = new TrainingDay
            {
                Name = addTrainingDTO.Name,
                FitnessPlanId = fitnessPlanId
            };

            await _context.TrainingDays.AddAsync(trainingDay);
            await _context.SaveChangesAsync();

            if (addTrainingDTO.ExerciseIds != null)
            {
                foreach (int exerciseID in addTrainingDTO.ExerciseIds)
                {
                    var trainingDay_Exercise = new TrainingDay_Exercise
                    {
                        FitnessExerciseId = exerciseID,
                        TrainingDayId = trainingDay.Id
                    };
                    await _context.TrainingDay_Exercises.AddAsync(trainingDay_Exercise);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddExercisesToTrainingDayById(int trainingDayId, int[] exerciseIds)
        {
            foreach(int exerciseId in exerciseIds)
            {
                var trainingDay_Exercise = new TrainingDay_Exercise
                {
                    FitnessExerciseId = exerciseId,
                    TrainingDayId = trainingDayId
                };
                await _context.TrainingDay_Exercises.AddAsync(trainingDay_Exercise);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainingDay(TrainingDay trainingDay)
        {
            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();
        }
    }
}
