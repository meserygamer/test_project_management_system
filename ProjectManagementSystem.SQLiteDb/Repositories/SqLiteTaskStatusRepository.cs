using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Repositories;

public class SqLiteTaskStatusRepository : ITaskStatusRepository
{
    private readonly Func<ProjectManagementSystemSQLiteDbContext> _dbContextFactory;
    private readonly IMapper<TaskStatusEntity, TaskStatus> _mapperProjectTaskToCore;
    
    public SqLiteTaskStatusRepository(Func<ProjectManagementSystemSQLiteDbContext> dbContextFactory,
        IMapper<TaskStatusEntity, TaskStatus> mapperToCore)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException();
        _mapperProjectTaskToCore = mapperToCore ?? throw new ArgumentNullException();
    }
    
    public async Task<List<TaskStatus>> GetAllStatusesAsync()
    {
        using (ProjectManagementSystemSQLiteDbContext dbContext = _dbContextFactory.Invoke())
        {
            List<TaskStatusEntity> statusesFromDb = await dbContext.TaskStatuses.ToListAsync();
            return statusesFromDb.ConvertAll(ts => _mapperProjectTaskToCore.MapToDestination(ts));
        }
    }
}