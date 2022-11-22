using AutoMapper;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Exercise, GetExerciseDTO>();
            CreateMap<AddExerciseDTO, Exercise>();
            CreateMap<FitnessPlan, GetFitnessPlanDTO>();
            CreateMap<TrainingDay_Exercise, TrainingDayDTO>();  
        }
    }
}
