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
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(pt => pt.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(pt => pt.Description);

        builder.Property(pt => pt.StartTime)
            .IsRequired();

        builder.Property(pt => pt.TaskStatusId)
            .IsRequired();

        builder.Property(pt => pt.ResponsibleUserId)
            .IsRequired();

        builder.HasOne(pt => pt.TaskStatus)
            .WithMany(ts => ts.Tasks)
            .HasForeignKey(pt => pt.TaskStatusId);

        builder.HasOne(pt => pt.ResponsibleUser)
            .WithMany(u => u.Tasks)
            .HasForeignKey(pt => pt.ResponsibleUserId);
    }
}