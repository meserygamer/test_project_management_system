namespace ProjectManagementSystem.SQLiteDb.Entities;

public class UserRoleEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public UserEntity[] Users { get; set; } = null!;
}