namespace ProjectManagementSystem.Core.DomainEntities;

public class ProjectTask
{
    /// <summary>
    /// Number of task in the system
    /// </summary>
    public int TaskNumber { get; set; }

    /// <summary>
    /// Task title in the system
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Task description in the system
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Date and time the task was issued
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Current task status
    /// </summary>
    public TaskStatus TaskStatus { get; set; }
}