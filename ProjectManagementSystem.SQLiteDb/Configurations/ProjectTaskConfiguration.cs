using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Configurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTaskEntity>
{
    public void Configure(EntityTypeBuilder<ProjectTaskEntity> builder)
    {
        builder.ToTable("ProjectTasks")
            .HasKey(pt => pt.Id);

        builder.Property(pt => pt.Id)
            .ValueGeneratedOnAdd();

        builder.Property(pt => pt.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(pt => pt.Description);

        builder.Property(pt => pt.StartTime)
            .IsRequired();

        builder.Property(pt => pt.TaskStatusId)
            .IsRequired();

        builder.Property(pt => pt.ResponsibleUserId);

        builder.HasOne(pt => pt.TaskStatus)
            .WithMany(ts => ts.Tasks)
            .HasForeignKey(pt => pt.TaskStatusId);

        builder.HasOne(pt => pt.ResponsibleUser)
            .WithMany(u => u.Tasks)
            .HasForeignKey(pt => pt.ResponsibleUserId);

        builder.HasData(new ProjectTaskEntity
        {
            Id = 1,
            Title = "Написать мапперы для пользователя",
            Description = "Написать маппер из класса UserEntity (Database) в User (Core)",
            StartTime = DateTime.Now,
            ResponsibleUserId = 1,
            TaskStatusId = 1
        }, new ProjectTaskEntity
        {
            Id = 2,
            Title = "Написать сущность и конфигурацию для хранения пользователей",
            Description = "Написать класс UserEntity отображающий пользователя в БД и конфигурацию UserConfiguration",
            StartTime = DateTime.Today,
            ResponsibleUserId = 1,
            TaskStatusId = 2
        });
    }
}