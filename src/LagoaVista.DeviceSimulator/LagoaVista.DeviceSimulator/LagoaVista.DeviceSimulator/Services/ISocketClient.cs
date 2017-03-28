using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoaVista.DeviceSimulator.Services
{
    public interface ISocketClient : IDisposable
    {
        Task Connect(string host, int port);

        Task<int> ReadAsync(byte[] buffer);

        Task WriteAsync(byte[] buffer, int start, int length);

        Task WriteAsync(string output);

        Task CloseAsync();
    }
}
