using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Configurations;

public class ChangeOfTaskStatusConfiguration : IEntityTypeConfiguration<ChangeOfTaskStatusEntity>
{
    public void Configure(EntityTypeBuilder<ChangeOfTaskStatusEntity> builder)
    {
        builder.ToTable("ChangesOfTasksStatus")
            .HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.TaskId)
            .IsRequired();

        builder.Property(c => c.ChangeDate)
            .IsRequired();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.NewStatusId)
            .IsRequired();

        builder.HasOne(c => c.Task)
            .WithMany(pt => pt.ChangesStatusHistory)
            .HasForeignKey(c => c.TaskId);
        
        builder.HasOne(c => c.User)
            .WithMany(u => u.ChangesTasksStatus)
            .HasForeignKey(c => c.UserId);

        builder.HasOne(c => c.NewStatus)
            .WithMany(ts => ts.ChangesTasksStatus)
            .HasForeignKey(c => c.NewStatusId);
    }
}