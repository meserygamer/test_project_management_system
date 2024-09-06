using System.Text;

namespace ProjectManagementSystem.Core.DomainEntities;

public class ProjectTask
{
    /// <summary>
    /// Number of task in the system
    /// </summary>
    public int Id { get; set; }

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
    public TaskStatus TaskStatus { get; set; } = null!;

    /// <summary>
    /// Responsible for completing the task
    /// </summary>
    public User? ResponsibleUser { get; set; }

    public string ProjectTaskInfo 
        => new StringBuilder()
            .Append($"Номер задачи: {Id}\n")
            .Append($"Заголовок: {Title}\n")
            .Append($"Описание: {Description}\n")
            .Append($"Дата начала: {StartTime}\n")
            .Append($"Статус: {TaskStatus.Title}\n")
            .ToString();

    public string ProjectTaskInfoWithResponsible
    {
        get
        {
            string responsibleUser = ResponsibleUser is not null 
                ? $"{ResponsibleUser.FullName} ({ResponsibleUser.Login})"
                : "-";
            return new StringBuilder()
                .Append($"Номер задачи: {Id}\n")
                .Append($"Заголовок: {Title}\n")
                .Append($"Описание: {Description}\n")
                .Append($"Дата начала: {StartTime}\n")
                .Append($"Статус: {TaskStatus.Title}\n")
                .Append($"Ответсвенный: {responsibleUser}\n")
                .ToString();
        }
    }
    
}