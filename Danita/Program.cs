using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;

namespace SignalRSelfHost
{
	class Program
	{
		static void Main(string[] args)
		{
            try
            {
                // This will *ONLY* bind to localhost, if you want to bind to all addresses
                // use http://*:8080 to bind to all addresses. 
                // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
                // for more information.
                string url = "http://localhost:7890";
                using (WebApp.Start(url))
                {
                    Console.WriteLine("Server running on {0}", url);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
		}
	}
	public class MyHub : Hub
	{
		public void Send(string name, string message)
		{
			Clients.All.addMessage(name, message);
		}
	}
}
