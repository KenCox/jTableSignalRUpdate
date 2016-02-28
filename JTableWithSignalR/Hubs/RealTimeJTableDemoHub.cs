using Microsoft.AspNet.SignalR;

namespace JTableWithSignalRDemo.Hubs
{
    public class RealTimeJTableDemoHub : Hub
    {
        public void SendMessage(string clientName, string message)
        {
             Clients.All.GetMessage(clientName, message);
        }
    }
}