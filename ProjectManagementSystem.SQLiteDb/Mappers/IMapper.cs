namespace ProjectManagementSystem.SQLiteDb.Mappers;

public interface IMapper<S,D>
{
    D MapToDestination(S source);
    S MapToSource(D destination);
}