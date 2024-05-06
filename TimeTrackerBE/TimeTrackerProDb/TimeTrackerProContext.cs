using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TimeTrackerProDb;

public partial class TimeTrackerProContext : DbContext
{
    public TimeTrackerProContext()
    {
    }

    public TimeTrackerProContext(DbContextOptions<TimeTrackerProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectScheduleTime> ProjectScheduleTimes { get; set; }

    public virtual DbSet<WorkScheduleTime> WorkScheduleTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\mssqllocaldb;attachdbfilename=C:\\Users\\jakob\\Documents\\Schule\\Pos\\Databases\\TimeTrackerPro.mdf;integrated security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Activity");

            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Employee");

            entity.Property(e => e.Firstname).HasMaxLength(64);
            entity.Property(e => e.Lastname).HasMaxLength(64);
            entity.Property(e => e.Username).HasMaxLength(64);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Project");

            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<ProjectScheduleTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProjectScheduleTime");

            entity.Property(e => e.Description).HasMaxLength(64);

            entity.HasOne(d => d.Activity).WithMany(p => p.ProjectScheduleTimes)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectScheduleTime_Activity");

            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectScheduleTimes)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectScheduleTime_Employee");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectScheduleTimes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectScheduleTime_Project");
        });

        modelBuilder.Entity<WorkScheduleTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WorkScheduleTime");

            entity.Property(e => e.Description).HasMaxLength(64);

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkScheduleTimes)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkScheduleTime_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
