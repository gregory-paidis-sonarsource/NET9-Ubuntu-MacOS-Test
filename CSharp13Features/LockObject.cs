
namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#new-lock-object
public static class LockObject
{
    private static readonly Lock _lock = new Lock();

    public static void ListAdd(ICollection<int> list, int add)
    {
        ArgumentNullException.ThrowIfNull(list);
        lock (_lock)
        {
            list.Add(add);
        }
    }

    public static void ManualLock()
    {
        using(_lock.EnterScope())
        {
            // Do something
        }
    }
}
