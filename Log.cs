using System;

public class Log
{
    public enum TYPE
    {
        INFO,
        DEBUG,
        ERROR
    }

    private static ConsoleColor defaultColor = Console.ForegroundColor;
    private static ConsoleColor infoColor = ConsoleColor.Yellow;
    private static ConsoleColor dbgColor = ConsoleColor.Blue;
    private static ConsoleColor errColor = ConsoleColor.Red;

    public static void WriteLine(string message, TYPE type)
    {
        var logType = getTypeMessage(type);
        var time = DateTime.Now.ToShortTimeString();

        Console.WriteLine(String.Format("{0} [{1}] {2}", logType, time, message));
        Console.ForegroundColor = defaultColor;
    }
    
    public static void Clear()
    {
        Console.Clear();
    }

    private static String getTypeMessage (TYPE type)
    {
        switch (type)
        {
            case TYPE.INFO:
                Console.ForegroundColor = infoColor;
                return "INFO";
            case TYPE.DEBUG:
                Console.ForegroundColor = dbgColor;
                return "DEBUG";
            case TYPE.ERROR:
                Console.ForegroundColor = errColor;
                return "ERROR";
            default:
                Console.ForegroundColor = defaultColor;
                return getTypeMessage(TYPE.INFO);
        }
    }
}