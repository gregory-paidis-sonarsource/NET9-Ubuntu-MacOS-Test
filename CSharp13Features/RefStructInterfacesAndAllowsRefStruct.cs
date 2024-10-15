namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#ref-struct-interfaces
public ref struct DisposableRefStruct : IDisposable
{
    public void Dispose() { /* Not relevant */ }
}

public class Consumer<T> where T : struct, IDisposable, allows ref struct 
{
    // The interface declared on a ref struct can only be accessed through generic constraints as shown here. See also
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct#restrictions-for-ref-struct-types-that-implement-an-interface

    public void Consume(in T t) => t.Dispose();
}

public class Test
{
    public Test()
    {
        var c = new Consumer<DisposableRefStruct>(); // DisposableRefStruct can be passed as a type argument because of the "allows ref struct" constraint
    }
}
