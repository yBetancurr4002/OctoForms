using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctoForms.Data.Entities;

namespace OctoForms.Data.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<QuestionResponse> QuestionResponses { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }

    public virtual DbSet<SurveyStatus> SurveyStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07F54C8B08");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_QuestionType");

            entity.HasOne(d => d.Survey).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Survey");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07F77A69C7");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionOptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Options_Question");
        });

        modelBuilder.Entity<QuestionResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC077CEFECB2");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionResponses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QResponses_Question");

            entity.HasOne(d => d.SurveyResponse).WithMany(p => p.QuestionResponses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QResponses_Response");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC074AEEA42A");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Surveys__3214EC0763F72C2E");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.Surveys)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Surveys_Users");

            entity.HasOne(d => d.Status).WithMany(p => p.Surveys)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Surveys_Status");
        });

        modelBuilder.Entity<SurveyResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SurveyRe__3214EC07C785946B");

            entity.Property(e => e.SubmittedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyResponses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Responses_Survey");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyResponses).HasConstraintName("FK_Responses_User");
        });

        modelBuilder.Entity<SurveyStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SurveySt__3214EC0773E4E21C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0750A78254");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
