﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrajnohuAPI.Data;

#nullable disable

namespace TrajnohuAPI.Migrations
{
    [DbContext(typeof(TrajnohuDbContext))]
    [Migration("20221117175626_UserModelAdded")]
    partial class UserModelAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodyTarget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GifURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FitnessExercises");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessExercise_TrainingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FitnessExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("FitnessPlanId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingDayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FitnessExerciseId");

                    b.HasIndex("FitnessPlanId");

                    b.HasIndex("TrainingDayId");

                    b.ToTable("FitnessExercise_TrainingDays");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FitnessPlans");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.TrainingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingDays");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessExercise_TrainingDay", b =>
                {
                    b.HasOne("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessExercise", "FitnessExercise")
                        .WithMany("FitnessExercise_TrainingDay")
                        .HasForeignKey("FitnessExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessPlan", "FitnessPlan")
                        .WithMany("FitnessExercise_TrainingDays")
                        .HasForeignKey("FitnessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrajnohuAPI.Data.Models.FitnessPlanModels.TrainingDay", "TrainingDay")
                        .WithMany("FitnessExercise_TrainingDay")
                        .HasForeignKey("TrainingDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessExercise");

                    b.Navigation("FitnessPlan");

                    b.Navigation("TrainingDay");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessPlan", b =>
                {
                    b.HasOne("TrajnohuAPI.Data.Models.User", "User")
                        .WithMany("FitnessPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessExercise", b =>
                {
                    b.Navigation("FitnessExercise_TrainingDay");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.FitnessPlan", b =>
                {
                    b.Navigation("FitnessExercise_TrainingDays");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.FitnessPlanModels.TrainingDay", b =>
                {
                    b.Navigation("FitnessExercise_TrainingDay");
                });

            modelBuilder.Entity("TrajnohuAPI.Data.Models.User", b =>
                {
                    b.Navigation("FitnessPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
