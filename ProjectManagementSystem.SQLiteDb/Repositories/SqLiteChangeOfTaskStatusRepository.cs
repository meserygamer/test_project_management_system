using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;

namespace ProjectManagementSystem.SQLiteDb.Repositories;

public class SqLiteChangeOfTaskStatusRepository : IChangeOfTaskStatusRepository
{
    private readonly Func<ProjectManagementSystemSQLiteDbContext> _dbContextFactory;
    private readonly IMapper<ChangeOfTaskStatusEntity, ChangeOfTaskStatus> _mapperChangeOfTaskToCore;
    
    public SqLiteChangeOfTaskStatusRepository(Func<ProjectManagementSystemSQLiteDbContext> dbContextFactory,
        IMapper<ChangeOfTaskStatusEntity, ChangeOfTaskStatus> mapperToCore)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException();
        _mapperChangeOfTaskToCore = mapperToCore ?? throw new ArgumentNullException();
    }
    
    public async Task<bool> AddChangeOfTaskStatusAsync(ChangeOfTaskStatus changeOfTaskStatus)
    {
        ChangeOfTaskStatusEntity entity = _mapperChangeOfTaskToCore.MapToSource(changeOfTaskStatus);
        try
        {
            using (ProjectManagementSystemSQLiteDbContext dbContext = _dbContextFactory.Invoke())
            {
                await dbContext.ChangesOfTasksStatus.AddAsync(entity);
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