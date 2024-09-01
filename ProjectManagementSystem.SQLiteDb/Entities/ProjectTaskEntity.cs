namespace ProjectManagementSystem.SQLiteDb.Entities;

public class ProjectTaskEntity
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime StartTime { get; set; }

    public int TaskStatusId { get; set; }

    public int ResponsibleUserId { get; set; }

    public UserEntity ResponsibleUser { get; set; } = null!;

    public TaskStatusEntity TaskStatus { get; set; } = null!;
}