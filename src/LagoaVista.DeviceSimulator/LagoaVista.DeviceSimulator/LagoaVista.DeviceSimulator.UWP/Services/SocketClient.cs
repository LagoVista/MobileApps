using LagoaVista.DeviceSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LagoaVista.DeviceSimulator.UWP.Services
{
    public class SocketClient : ISocketClient
    {
        TcpClient _client;

        public Task CloseAsync()
        {
            if(_client != null)
            {
                _client.Dispose();
                _client = null;
            }

            return Task.FromResult(default(object));
        }

        public async Task Connect(string host, int port)
        {
            _client = new TcpClient(AddressFamily.InterNetwork);
            await _client.ConnectAsync(host, port);
        }

        public Task<int> ReadAsync(byte[] buffer)
        {
            return _client.GetStream().ReadAsync(buffer, 0, buffer.Length);
        }

        public Task WriteAsync(byte[] buffer, int start, int length)
        {
            return _client.GetStream().WriteAsync(buffer, start, length);
        }

        public Task WriteAsync(byte[] buffer)
        {
            return _client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public Task WriteAsync(string output)
        {
            var buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(output);
            return _client.GetStream().WriteAsync(buffer, 0, buffer.Length);
       }

        public void Dispose()
        {
            CloseAsync();
        }
    }
}
