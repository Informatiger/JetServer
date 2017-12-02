using System;
using System.Net;

public class Util
{
    public static string GetIP(EndPoint endPoint)
    {
        return ((IPEndPoint)endPoint).Address.ToString();
    } 

    public static string GetIP(IPEndPoint ipEndPoint)
    {
        return ipEndPoint.Address.ToString();
    }   
}