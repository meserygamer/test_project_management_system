using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.ToTable("UserRoles")
            .HasKey(ur => ur.Id);

        builder.Property(ur => ur.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ur => ur.Title)
            .IsRequired();

        builder.HasMany(ur => ur.Users)
            .WithOne(u => u.UserRole)
            .HasForeignKey(u => u.UserRoleId);
        
        builder.HasData(
            new UserRoleEntity { Id = 1, Title = "Управляющий" },
            new UserRoleEntity { Id = 2, Title = "Обычный сотрудник" }
            );
    }
}