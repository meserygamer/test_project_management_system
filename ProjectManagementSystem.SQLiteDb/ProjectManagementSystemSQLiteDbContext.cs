using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb;

public class ProjectManagementSystemSQLiteDbContext : DbContext
{
    public const string ConnectionString = "Data Source=ProjectManagementSystemSQLite.db";

    public ProjectManagementSystemSQLiteDbContext()
    {
        Database.Migrate();
    }

    public DbSet<ChangeOfTaskStatusEntity> ChangesOfTasksStatus { get; set; }
    public DbSet<ProjectTaskEntity> ProjectTasks { get; set; }
    public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectManagementSystemSQLiteDbContext).Assembly);
    }
}