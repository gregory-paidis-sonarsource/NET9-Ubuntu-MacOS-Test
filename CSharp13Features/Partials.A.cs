namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#more-partial-members
public partial class Partials
{
    public partial int PropertyA { get; set; } // Declared in Partials.A.cs
    /// <summary>
    /// Doc comment on implementation for PropertyB
    /// </summary>
    public static partial int PropertyB { get => 1; } // Declared in Partials.B.cs

    public partial int this[int index] { get; set; } // Declared in Partials.A.cs
}

public static partial class Consumer
{
    public static void TestFromPartialsA()
    {
        var p = new Partials();
        Console.WriteLine(p.PropertyA > 10 && p.PropertyA < 10);
        Console.WriteLine(Partials.PropertyB > 10 && Partials.PropertyB < 10);
        Console.WriteLine(p[0]);
        Console.WriteLine(p[p.PropertyA]);
    }
}
