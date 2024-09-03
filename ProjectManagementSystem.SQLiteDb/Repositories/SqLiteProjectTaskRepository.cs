using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;

namespace ProjectManagementSystem.SQLiteDb.Repositories;

public class SqLiteProjectTaskRepository : IProjectTaskRepository
{
    private readonly Func<ProjectManagementSystemSQLiteDbContext> _dbContextFactory;
    private readonly IMapper<ProjectTaskEntity, ProjectTask> _mapperProjectTaskToCore;
    
    public SqLiteProjectTaskRepository(Func<ProjectManagementSystemSQLiteDbContext> dbContextFactory,
        IMapper<ProjectTaskEntity, ProjectTask> mapperToCore)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException();
        _mapperProjectTaskToCore = mapperToCore ?? throw new ArgumentNullException();
    }
    
    public async Task<List<ProjectTask>> GetAllUsersTasksAsync(int userId)
    {
        using (ProjectManagementSystemSQLiteDbContext dbContext = _dbContextFactory.Invoke())
        {
            List<ProjectTaskEntity> tasksFromDb = await dbContext.ProjectTasks
                .Where(pt => pt.ResponsibleUserId == userId)
                .Include(pt => pt.TaskStatus)
                .ToListAsync();
            return tasksFromDb.ConvertAll<ProjectTask>(pt => _mapperProjectTaskToCore.MapToDestination(pt));
        }
    }

    public async Task<ProjectTask?> GetTaskByIdAsync(int taskId)
    {
        using (ProjectManagementSystemSQLiteDbContext dbContext = _dbContextFactory.Invoke())
        {
            ProjectTaskEntity? taskFromDb = await dbContext.ProjectTasks
                .Include(pt => pt.TaskStatus)
                .FirstOrDefaultAsync(pt => pt.Id == taskId);
            return taskFromDb is not null ? _mapperProjectTaskToCore.MapToDestination(taskFromDb) : null;
        }
    }

    public async Task<bool> UpdateTaskAsync(ProjectTask newTaskData)
    {
        ProjectTaskEntity entityOnUpdate = _mapperProjectTaskToCore.MapToSource(newTaskData);
        try
        {
            using (ProjectManagementSystemSQLiteDbContext dbContext = _dbContextFactory.Invoke())
            {
                EntityEntry<ProjectTaskEntity> entity =  dbContext.ProjectTasks.Attach(entityOnUpdate);
                entity.State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }
}