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

            modelBuilder.Entity<FitnessPlan>()
                .HasMany(t => t.FitnessExercise_TrainingDays)
                .WithOne(tr => tr.FitnessPlan);

            modelBuilder.Entity<FitnessPlan_FitnessExercise>()
                .HasOne(t => t.FitnessPlan)
                .WithMany(tr => tr.FitnessExercise_TrainingDays)
                .HasForeignKey(tk => tk.FitnessPlanId);

            modelBuilder.Entity<FitnessPlan_FitnessExercise>()
                .HasOne(t => t.FitnessExercise)
                .WithMany(tr => tr.FitnessExercise_TrainingDay)
                .HasForeignKey(tk => tk.FitnessExerciseId);            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FitnessExercise> FitnessExercises { get; set; }
        public DbSet<FitnessPlan> FitnessPlans { get; set; }
        public DbSet<FitnessPlan_FitnessExercise> FitnessExercise_TrainingDays { get; set; }
    }
}
