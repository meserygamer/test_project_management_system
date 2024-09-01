namespace ProjectManagementSystem.SQLiteDb.Entities;

public class ChangeOfTaskStatusEntity
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public DateTime ChangeDate { get; set; }

    public int UserId { get; set; }

    public int NewStatusId { get; set; }

    #region NavigationProperties

    public ProjectTaskEntity Task { get; set; } = null!;

    public UserEntity User { get; set; } = null!;

    public TaskStatusEntity NewStatus { get; set; } = null!;

    #endregion
}