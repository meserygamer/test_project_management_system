using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Configurations;

public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatusEntity>
{
    public void Configure(EntityTypeBuilder<TaskStatusEntity> builder)
    {
        builder.ToTable("TaskStatuses")
            .HasKey(ts => ts.Id);

        builder.Property(ts => ts.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ts => ts.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(ts => ts.Tasks)
            .WithOne(pt => pt.TaskStatus)
            .HasForeignKey(pt => pt.TaskStatusId);
        
        builder.HasData(
            new TaskStatusEntity {Id = 1, Title = "Не в работе"},
            new TaskStatusEntity {Id = 2, Title = "В работе"},
            new TaskStatusEntity {Id = 3, Title = "Заблокировано"},
            new TaskStatusEntity {Id = 4, Title = "Готово"},
            new TaskStatusEntity {Id = 5, Title = "Удалено"}
        );
    }
}