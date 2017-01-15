using JwtTokenParser;
using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        var parser = new TokenParser();
        var result = parser.SetToken(args[0]);
        var formatter = new TokenResultConsoleFormatter();
        formatter.WriteToConsole(result);
    }

    private static void ShowHelp()
    {
        Console.WriteLine("\n** Usage **");
        Console.WriteLine("JwtTokenParser {token}\n");
    }
}
