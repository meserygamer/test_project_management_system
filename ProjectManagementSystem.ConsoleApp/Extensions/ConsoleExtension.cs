namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class ConsoleExtension
{
    public static bool TryGetInt32(out int number)
    {
        try
        {
            number = Convert.ToInt32(Console.ReadLine());
            return true;
        }
        catch (Exception e)
        {
            number = 0;
            return false;
        }
    }
}