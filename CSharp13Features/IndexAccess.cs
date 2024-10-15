namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#implicit-index-access
public static class IndexAccess
{
    public static void ObjectInitializer()
    {
        DataBuffer buffer = new()
        {
            [-1] = -1,
            [1] = 0,
            [2] = 1,
            [3] = 2,
            [4] = 3,
            [5] = 4,
            [6] = 5,
            [7] = 6,
            [8] = 7,
            [9] = 8,
            [10] = 9
        };
    }
}

public class DataBuffer
{
    public int this[Index index]
    {
        get => 1;
        set { /* not relevant */ }
    }
}
