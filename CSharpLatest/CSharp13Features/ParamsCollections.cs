using System.Collections;
using System.Runtime.CompilerServices;

namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#params-collections
public static class ParamsCollections
{
    public static bool A(params int[] array) => true;
    public static bool B(params Span<int> span) => true;
    public static bool C(params ReadOnlySpan<int> span) => true;
    public static bool D(params IEnumerable<int> enumerable) => true;
    public static bool E(params IReadOnlyCollection<int> readonlyCollection) => true;
    public static bool F(params IReadOnlyList<int> readonlyList) => true;
    public static bool G(params ICollection<int> collection) => true;
    public static bool H(params IList<int> list) => true;
    public static bool I(params MyImmutableArray<int> collectionBuilder) => true;
    public static bool J(params CustomStruct customStruct) => true;
    public static bool K(params IEnumerable<object>? enumerable) => true;
    public static bool L(params IEnumerable<object?> enumerable) => true;
    public static bool M(params IEnumerable<object?>? enumerable) => true;
    public static bool N(params object?[] array) => true;
    public static bool O(params object[]? array) => true;
    public static bool P(params object?[]? array) => true;
}

[CollectionBuilder(typeof(MyImmutableArray), "Create")]
public struct MyImmutableArray<T> : IEnumerable<T>
{
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => default!;
    IEnumerator IEnumerable.GetEnumerator() => default!;
}

public static class MyImmutableArray
{
    public static MyImmutableArray<T> Create<T>(ReadOnlySpan<T> items) => [];
}

public struct CustomStruct : IEnumerable
{
    public void Add(int value) { /* Add */ }
    IEnumerator IEnumerable.GetEnumerator() => default!;
}
