using System;
using System.Net;

public class Util
{
    /// <summary>
    /// Returns IP as String
    /// </summary>
    /// <param name="endPoint">EndPoint</param>
    /// <returns>IP as String</returns>
    public static string GetIP(EndPoint endPoint) => ((IPEndPoint)endPoint).Address.ToString();

    /// <summary>
    /// Returns IP as String
    /// </summary>
    /// <param name="ipEndPoint">IPEndPoint</param>
    /// <returns>IP as String</returns>
    public static string GetIP(IPEndPoint ipEndPoint) => ipEndPoint.Address.ToString();
}