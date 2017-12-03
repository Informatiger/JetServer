using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;

using SimpleTCP;

namespace jetServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {     
                Dictionary<string, string> Users = new Dictionary<string, string>();
         
                var server = new SimpleTcpServer();
                var serverRunning = false;
                var port = 31415;

                server.Start(port);
                serverRunning = true;
                // var listening_ip = server.GetListeningIPs().Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

                Log.Clear();
                Log.WriteLine(String.Format("Server started on {0}", port), Log.TYPE.INFO); 

                server.ClientConnected += (sender, arg) =>
                {
                    var msg = String.Format("{0} joined.", Util.GetIP(arg.Client.RemoteEndPoint));
                    Log.WriteLine(msg, Log.TYPE.INFO);

                    server.BroadcastLine(String.Format("!INF:New client joined (Clients: {0})", server.ConnectedClientsCount));                                        
                };

                server.ClientDisconnected += (sender, arg) =>
                {
                    if (server.ConnectedClientsCount <= 0)
                        serverRunning = false;

                    var ip = Util.GetIP(arg.Client.RemoteEndPoint);
                    var msg = String.Format("{0} left.", ip);
                    Log.WriteLine(msg, Log.TYPE.INFO);

                    if (Users.ContainsKey(ip))
                    {    
                        server.BroadcastLine(String.Format("!INF:{0} left (Clients: {1})", Users[ip], server.ConnectedClientsCount));
                        Users.Remove(ip);
                    }
                };

                server.DataReceived += (sender, msg) =>
                {
                    var ip = Util.GetIP(msg.TcpClient.Client.RemoteEndPoint);

                    if (Users.ContainsKey(ip))
                    {
                        Log.WriteLine(String.Format("{0}: {1}", Users[ip], msg.MessageString), Log.TYPE.INFO);
                        server.BroadcastLine(String.Format("{0}: {1}", Users[ip], msg.MessageString));
                    }
                    else
                    {
                       Users.Add(ip, msg.MessageString.Trim());
                       Log.WriteLine(String.Format("{0} is known as {1}", ip, Users[ip]), Log.TYPE.INFO);
                       server.BroadcastLine(String.Format("!INF:New client is known as {0}", Users[ip]));
                    }    
                };

                while(serverRunning);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
