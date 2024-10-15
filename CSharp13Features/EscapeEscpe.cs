namespace CSharpLatest.CSharp13Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13#new-escape-sequence
public static class EscapeEscape
{
    public static void EscapeSequenceForEscape()
    {
        _ = "\e";
        _ = "\' \" \\ \0 \a \b \e \f \n \r \t \v";
        _ = '\e';
        _ = $"\e{"\e"}";
        _ = $"{'\e'}";
        _ = $@"{'\e'}";
        _ = $"""{'\e'}""";
        _ = $"""
            {'\e'}
            """;
    }
}
