namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#method-group-natural-type
// Example taken from https://github.com/dotnet/csharplang/issues/7364
public static class MethodGroupNaturalType
{
    public static void Test()
    {
        var c = new C();
        Action x = c.M;         // C.M()
        Action<object> y = c.M; // E.M(C, object)
        var z = c.M;            // the delegate type could not be inferred before C# 13
    }
}

public class C
{
    public void M() { /* not relevant */ }
}

public static class E
{
    public static void M(this C c, object o) { /* not relevant */ }
}
