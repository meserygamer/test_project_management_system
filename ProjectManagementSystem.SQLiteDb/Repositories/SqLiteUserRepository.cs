using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;

namespace ProjectManagementSystem.SQLiteDb.Repositories;

public class SqLiteUserRepository : IUserRepository
{
    private readonly Func<ProjectManagementSystemSQLiteDbContext> _dbContextFactory;
    private readonly IMapper<UserEntity, User> _mapperUserToCore;
    
    public SqLiteUserRepository(Func<ProjectManagementSystemSQLiteDbContext> dbContextFactory,
        IMapper<UserEntity, User> mapperToCore)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException();
        _mapperUserToCore = mapperToCore ?? throw new ArgumentNullException();
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        List<UserEntity> usersFromDb;
        using (ProjectManagementSystemSQLiteDbContext db = _dbContextFactory.Invoke()) 
            usersFromDb = await db.Users.Include(ue => ue.UserRole).ToListAsync();
        return usersFromDb.ConvertAll<User>(ue => _mapperUserToCore.MapToDestination(ue)).ToList();
    }

    public async Task<User?> GetUserByLoginAsync(string login)
    {
        UserEntity? userFromDb;
        using (ProjectManagementSystemSQLiteDbContext db = _dbContextFactory.Invoke())
            userFromDb = await db.Users.Include(ue => ue.UserRole)
                .FirstOrDefaultAsync(ue => ue.Login == login);
        return userFromDb is null 
            ? null 
            : _mapperUserToCore.MapToDestination(userFromDb);
    }

    public async Task<bool> TryAddUserAsync(User newUser)
    {
        UserEntity newUserEntity = _mapperUserToCore.MapToSource(newUser);
        try
        {
            using (ProjectManagementSystemSQLiteDbContext db = _dbContextFactory.Invoke())
            {
                await db.Users.AddAsync(newUserEntity);
                await db.SaveChangesAsync();
            }

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }
}