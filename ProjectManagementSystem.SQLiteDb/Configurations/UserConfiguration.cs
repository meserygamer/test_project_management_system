using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users")
            .HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Surname)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Patronymic)
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.UserRoleId)
            .IsRequired();

        builder.Property(u => u.Login)
            .IsRequired();

        builder.Property(u => u.HashedPassword)
            .IsRequired();

        builder.HasOne(u => u.UserRole)
            .WithMany(ur => ur.Users)
            .HasForeignKey(u => u.UserRoleId);

        builder.HasMany(u => u.Tasks)
            .WithOne(pt => pt.ResponsibleUser)
            .HasForeignKey(pt => pt.ResponsibleUserId);

        builder.HasIndex(u => u.Login)
            .HasDatabaseName("LoginIndex")
            .IsUnique();
    }
}