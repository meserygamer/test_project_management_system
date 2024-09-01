namespace ProjectManagementSystem.Core.DomainEntities;

public class TaskStatus
{
    /// <summary>
    /// Id of task status
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of task status
    /// </summary>
    public string Title { get; set; } = null!;
}