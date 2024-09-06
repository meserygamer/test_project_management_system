namespace ProjectManagementSystem.Core.DomainEntities;

public class ChangeOfTaskStatus
{
    public int Id { get; set; }

    public ProjectTask Task { get; set; } = null!;

    public DateTime ChangeDate { get; set; }

    public User User { get; set; } = null!;

    public TaskStatus NewStatus { get; set; } = null!;
}