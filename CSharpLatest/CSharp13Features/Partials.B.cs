namespace CSharpLatest.CSharp13Features;

public partial class Partials
{
    private int _PropertyA;

    public partial int PropertyA { get => _PropertyA; set => _PropertyA = value; }
    /// <summary>
    /// Doc comment on declaration for PropertyB
    /// </summary>
    public static partial int PropertyB { get; }

    public partial int this[int index] { get => 1; set { _ = value * index; } }
}

public static partial class Consumer
{
    public static void TestFromPartialsB()
    {
        var p = new Partials();
        Console.WriteLine(p.PropertyA > 10 && p.PropertyA < 10);
        Console.WriteLine(Partials.PropertyB > 10 && Partials.PropertyB < 10);
        Console.WriteLine(p[0]);
        Console.WriteLine(p[p.PropertyA]);
    }
}
