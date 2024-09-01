namespace ProjectManagementSystem.SQLiteDb.Entities;

public class UserRoleEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    #region NavigationProperties

    public ICollection<UserEntity> Users { get; set; } = null!;

    #endregion
}