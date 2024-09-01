namespace ProjectManagementSystem.SQLiteDb.Entities;

public class TaskStatusEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public ProjectTaskEntity[] Tasks { get; set; } = null!;
}