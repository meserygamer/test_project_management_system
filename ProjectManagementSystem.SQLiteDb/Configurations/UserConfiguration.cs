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

        builder.HasData(
            new UserEntity 
            { 
                Id = 1,
                Login = "Employee",
                HashedPassword = "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC",
                Name = "Работник",
                Surname = "Работников",
                Patronymic = "Работникович",
                Email = "test@mail.com",
                UserRoleId = 2
            },
            new UserEntity()
            {
                Id = 2,
                Login = "Supervisor",
                HashedPassword = "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC",
                Name = "Управляющий",
                Surname = "Управ",
                Patronymic = "Управляющевич",
                Email = "test@mail.com",
                UserRoleId = 1
            }
            );
    }
}