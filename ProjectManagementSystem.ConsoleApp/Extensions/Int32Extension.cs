namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class Int32Extension
{
    public static bool IsInRange(this int number, int minInclusive, int maxInclusive)
        => number >= minInclusive && number <= maxInclusive;
}