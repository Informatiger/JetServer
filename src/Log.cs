using System;

public class Log
{
    /// <summary>
    /// Type of log entry
    /// </summary>
    public enum TYPE
    {
        INFO,
        DEBUG,
        ERROR
    }

    /// <summary>
    /// Default Console-Color
    /// </summary>
    private static ConsoleColor defaultColor = Console.ForegroundColor;
    /// <summary>
    /// Color for [INFO] entries
    /// </summary>
    private static ConsoleColor infoColor = ConsoleColor.Yellow;
    /// <summary>
    /// Color for [DEBUG] entries
    /// </summary>
    private static ConsoleColor dbgColor = ConsoleColor.Blue;
    /// <summary>
    /// Color for [ERROR] entries
    /// </summary>
    private static ConsoleColor errColor = ConsoleColor.Red;

    /// <summary>
    /// Writes log message to console
    /// </summary>
    /// <param name="message">log message</param>
    /// <param name="type">type of log entry</param>
    public static void WriteLine(string message, TYPE type)
    {
        var logType = getTypeMessage(type);
        var time = DateTime.Now.ToShortTimeString();

        Console.WriteLine(String.Format("{0} [{1}] {2}", time, logType, message));
        Console.ForegroundColor = defaultColor;
    }

    /// <summary>
    /// Clears the console
    /// </summary>
    public static void Clear() => Console.Clear();

    /// <summary>
    /// Return name of type
    /// </summary>
    /// <param name="type">type</param>
    /// <returns></returns>
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