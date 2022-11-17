using AutoMapper;
using TrajnohuAPI.Data.DTOs;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FitnessExercise, GetFitnessExerciseDTO>();
            CreateMap<AddFitnessExerciseDTO, FitnessExercise>();
        }
    }
}
