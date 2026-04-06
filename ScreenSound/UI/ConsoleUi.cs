namespace ScreenSound.UI;

internal static class ConsoleUi
{
    public static void PrintColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void TypeLine(string text, ConsoleColor color = ConsoleColor.White, int delayMs = 1)
    {
        Console.ForegroundColor = color;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    public static void ShowSectionHeader(string title)
    {
        Console.WriteLine();
        PrintColored(title, ConsoleColor.Yellow);
        Console.WriteLine();
    }
}
