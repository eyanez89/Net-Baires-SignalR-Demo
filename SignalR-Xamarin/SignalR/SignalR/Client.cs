using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class Client
    {
        public const string SITE_URL = "http://net-baires-signalr.azurewebsites.net/";
        
        private readonly string _platform;
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;
        
        public string UserName;
        public event EventHandler<string> OnMessageReceived;

        public Client(string platform)
        {
            _platform = platform;
            _connection = new HubConnection(SITE_URL);
            _proxy = _connection.CreateHubProxy("chat");
        }

        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On("receiveMessage", (string sender, string message, string from) =>
            {
                OnMessageReceived?.Invoke(this, $"{sender} - from {from}: \n {message}");
            });

            await Send("Connected");
        }

        public Task Send(string message)
        {
            return _proxy.Invoke("sendMessage", UserName, message, _platform);
        }
    }
}

