namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#ref-and-unsafe-in-iterators-and-async-methods
public static class RefUnsafeIterator
{
    public static IEnumerable<int> Iterator_RefStruct()
    {
        ReadOnlySpan<int> span = [1, 2, 3];
        yield return span[0];
        // span is not accessible here: error CS4007: Instance of type 'System.ReadOnlySpan<int>' cannot be preserved across 'await' or 'yield' boundary.
    }

    public static IEnumerable<int> Iterator_Unsafe()
    {
        int i = 0;
        var span = new ReadOnlySpan<int>(in i);
        unsafe
        {
            fixed (int* p = span)
            {
                _ = p + 1;
            }
        }
        yield return i;
        // span is not accessible here: error CS4007: Instance of type 'System.ReadOnlySpan<int>' cannot be preserved across 'await' or 'yield' boundary.
    }

    public static async Task Async_RefStruct()
    {
        int i = 0;
        ref readonly int r = ref i;
        ReadOnlySpan<int> span = [1, 2, 3];
        await Task.Yield();
        // span is not accessible here: error CS4007: Instance of type 'System.ReadOnlySpan<int>' cannot be preserved across 'await' or 'yield' boundary.
        // r is not accessible here: A 'ref' local cannot be preserved across 'await' or 'yield' boundary.
    }

    public static async Task Async_Unsafe()
    {
        int i = 0;
        var span = new ReadOnlySpan<int>(in i);
        unsafe
        {
            fixed (int* p = span)
            {
                _ = p + 1;
            }
        }
        await Task.Yield();
        // span is not accessible here: error CS4007: Instance of type 'System.ReadOnlySpan<int>' cannot be preserved across 'await' or 'yield' boundary.
    }
}
