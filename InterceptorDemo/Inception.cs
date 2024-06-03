using System.Runtime.CompilerServices;

namespace InterceptorDemo;

public static class Inception
{
    [InterceptsLocation(
        filePath: "C:\\_repos\\auth-sync-2024-03-dotnet8\\InterceptorDemo\\Program.cs",
        line: 11,
        column: 8)]
    public static void InterceptSort(
        this ArraySorter arraySorter, int[] array)
    {
        Console.WriteLine($"Intercept using Array.Sort to sort {array.Length} elements");
        Array.Sort(array);
    }
}
