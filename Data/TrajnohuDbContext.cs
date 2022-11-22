using Microsoft.EntityFrameworkCore;
using TrajnohuAPI.Data.Models;
using TrajnohuAPI.Data.Models.FitnessPlanModels;

namespace TrajnohuAPI.Data
{
    public class TrajnohuDbContext : DbContext
    {
        public TrajnohuDbContext(DbContextOptions<TrajnohuDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FitnessPlan>()
                .HasOne(t => t.User)
                .WithMany(tr => tr.FitnessPlans)
                .HasForeignKey(tk => tk.UserId);

            modelBuilder.Entity<User>()
                .HasMany(t => t.FitnessPlans)
                .WithOne(tr => tr.User);

            modelBuilder.Entity<TrainingDay>()
                .HasOne(t => t.FitnessPlan)
                .WithMany(tr => tr.TrainingDays)
                .HasForeignKey(tk => tk.FitnessPlanId);

            modelBuilder.Entity<FitnessPlan>()
                .HasMany(t => t.TrainingDays)
                .WithOne(tr => tr.FitnessPlan);

            modelBuilder.Entity<TrainingDay_Exercise>()
                .HasOne(t => t.FitnessExercise)
                .WithMany(tr => tr.TrainingDay_Exercises)
                .HasForeignKey(tk => tk.FitnessExerciseId);

            modelBuilder.Entity<TrainingDay_Exercise>()
                .HasOne(t => t.TrainingDay)
                .WithMany(tr => tr.TrainingDay_Exercises)
                .HasForeignKey(tk => tk.TrainingDayId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<FitnessPlan> FitnessPlans { get; set; }
        public DbSet<TrainingDay> TrainingDays { get; set; }
        public DbSet<TrainingDay_Exercise> TrainingDay_Exercises { get; set; }
    }
}
