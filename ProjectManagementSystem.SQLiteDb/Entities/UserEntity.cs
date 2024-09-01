namespace ProjectManagementSystem.SQLiteDb.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string Surname { get; set; } = null!;
    
    public string Patronymic { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public int UserRoleId { get; set; }

    public string Login { get; set; } = null!;
    
    public string HashedPassword { get; set; } = null!;

    public UserRoleEntity UserRole { get; set; } = null!;

    public ProjectTaskEntity[] Tasks { get; set; } = null!;
}