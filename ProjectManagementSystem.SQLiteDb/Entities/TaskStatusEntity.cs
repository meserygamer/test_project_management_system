namespace ProjectManagementSystem.SQLiteDb.Entities;

public class TaskStatusEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    #region NavigationProperties

    public ICollection<ProjectTaskEntity> Tasks { get; set; } = null!;

    public ICollection<ChangeOfTaskStatusEntity> ChangesTasksStatus { get; set; } = null!;

    #endregion

}