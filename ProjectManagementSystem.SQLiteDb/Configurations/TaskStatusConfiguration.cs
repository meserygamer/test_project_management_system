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
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(ts => ts.Title)
            .IsRequired();

        builder.HasMany(ts => ts.Tasks)
            .WithOne(pt => pt.TaskStatus)
            .HasForeignKey(pt => pt.TaskStatusId);
    }
}