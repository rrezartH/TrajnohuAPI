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

        public async Task<ActionResult<ICollection<GetTrainingDayDTO>>> GetFitnessPlanTrainingDaysById(int id)
        {
            var dbTrainingDays = await _context.TrainingDays
                                                .Where(t => t.FitnessPlanId == id)
                                                .Select(td => new GetTrainingDayDTO
                                                {
                                                    Id = td.Id,
                                                    Name = td.Name,
                                                    Exercises = td.TrainingDay_Exercises!
                                                                .Where(trr => trr.TrainingDayId == td.Id)
                                                                .Select(tr => _mapper.Map<GetExerciseDTO>(tr.FitnessExercise))
                                                                .ToList()
                                                })
                                                .ToListAsync();

            if (dbTrainingDays.Count < 1)
                return new NotFoundObjectResult("There are no training days for this user.");

            return new OkObjectResult(dbTrainingDays);
        }

        public async Task<ActionResult> AddTrainingDayToFitnessPlan(int fitnessPlanId, AddTrainingDayDTO addTrainingDTO)
        {
            if (await _context.FitnessPlans.FindAsync(fitnessPlanId) == null)
                return new NotFoundObjectResult("The fitness plan you are trying to add the training day doesn't exist.");

            if (addTrainingDTO == null)
                return new BadRequestObjectResult("You can't add an empty training day.");

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

            return new OkObjectResult("Training day added succesfully.");
        }

        public async Task<ActionResult> AddExercisesToTrainingDayById(int trainingDayId, int[] exerciseIds)
        {
            if (await _context.TrainingDays.FindAsync(trainingDayId) == null)
                return new NotFoundObjectResult("The training day you are trying to add the exercises doesn't exist.");

            if (exerciseIds == null || exerciseIds.Length < 1)
                return new BadRequestObjectResult("There are no exercises to be added.");

            foreach (int exerciseId in exerciseIds)
            {
                var trainingDay_Exercise = new TrainingDay_Exercise
                {
                    FitnessExerciseId = exerciseId,
                    TrainingDayId = trainingDayId
                };
                await _context.TrainingDay_Exercises.AddAsync(trainingDay_Exercise);
            }
            await _context.SaveChangesAsync();
            return new OkObjectResult("Exercises added succesfully.");
        }

        public async Task<ActionResult> UpdateTrainingDay(int id, UpdateTrainingDayDTO updateTrainingDayDTO)
        {
            if (updateTrainingDayDTO == null)
                return new BadRequestObjectResult("There's nothing to update.");

            var dbTrainingDay = await _context.TrainingDays.FindAsync(id);
            if (dbTrainingDay == null)
                return new NotFoundObjectResult("The training day couldn't be found.");

            dbTrainingDay.Name = updateTrainingDayDTO.Name ?? dbTrainingDay.Name;
            if (updateTrainingDayDTO.ExerciseIds != null)
            {
                //get exercises that the user has already in its training day
                var selectedExercises = await _context.TrainingDay_Exercises
                                                        .Where(t => t.TrainingDayId == id)
                                                        .Select(tr => tr.FitnessExerciseId)
                                                        .ToListAsync();

                foreach (int exerciseId in updateTrainingDayDTO.ExerciseIds.Except(selectedExercises))
                {
                    var trainingDay_Exercise = new TrainingDay_Exercise
                    {
                        TrainingDayId = dbTrainingDay.Id,
                        FitnessExerciseId = exerciseId,
                    };
                    await _context.TrainingDay_Exercises.AddAsync(trainingDay_Exercise);
                }
            }
            await _context.SaveChangesAsync();
            return new OkObjectResult("Training day updated succesfully.");
        }

        public async Task<ActionResult> RemoveExercisesFromTrainingDay(int id, int[] exerciseIds)
        {
            if (await _context.TrainingDays.FindAsync(id) == null)
                return new NotFoundObjectResult("This training day doesn't exist.");

            foreach(int exerciseId in exerciseIds)
            {
                var dbTrEx = await _context.TrainingDay_Exercises.Where(e => e.TrainingDayId == id && e.FitnessExerciseId == exerciseId)
                                                    .FirstOrDefaultAsync();

                if (dbTrEx != null)
                    _context.TrainingDay_Exercises.Remove(dbTrEx);
            }
            await _context.SaveChangesAsync();

            return new OkObjectResult("The exercises were removed succesfully from your training day.");
        }

        public async Task<ActionResult> DeleteTrainingDay(int id)
        {
            var dbTrainingDay = await _context.TrainingDays.FindAsync(id);
            if (dbTrainingDay == null)
                return new NotFoundObjectResult("Training day can't be null.");

            _context.TrainingDays.Remove(dbTrainingDay);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Training day deleted succesfully");
        }

    }
}
