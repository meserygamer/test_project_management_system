using Microsoft.EntityFrameworkCore;
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
}