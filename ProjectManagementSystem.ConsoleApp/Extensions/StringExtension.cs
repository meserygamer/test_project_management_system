namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class StringExtension
{
    public static bool IsInList(this string? str, params string[] strsToCompare)
    {
        if (str is null)
            return false;
        
        foreach (var strToCompare in strsToCompare)
        {
            if (str == strToCompare)
                return true;
        }

        return false;
    }

    public static bool TryConvertToInt32(this string? str, out int number)
    {
        number = 0;
        if (str is null)
            return false;
        
        try
        {
            number = Convert.ToInt32(str);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}