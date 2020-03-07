using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DaHo.MyStrom
{
    public class MyStromDeviceDetector : IMyStromDeviceDetector
    {
        private CancellationToken _cancellationToken;

        public const int MYSTROM_BORADCAST_PORT = 7979;
        public const int MAC_ADDRESS_LENGTH = 6;

        public MyStromDeviceDetector(CancellationToken cancellationToken = default)
        {
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Listens on UDP broadcasts on port 7979 to detect myStrom devices in the current network
        /// </summary>
        /// <param name="onDeviceFound">The callback function for when a device was found</param>
        public async Task GetLocalMyStromDevices(Action<MyStromDevice> onDeviceFound)
        {
            var deviceAddresses = new HashSet<string>();

            using (var listener = new UdpClient(MYSTROM_BORADCAST_PORT))
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    var receivedMessage = await listener.ReceiveAsync();

                    var mac = string.Concat(receivedMessage.Buffer.Take(MAC_ADDRESS_LENGTH).Select(x => x.ToString("X2")));
                    var deviceType = receivedMessage.Buffer.Skip(MAC_ADDRESS_LENGTH).Take(1).First();

                    if (deviceAddresses.Add(mac))
                    {
                        onDeviceFound(new MyStromDevice
                        {
                            MacAddress = mac,
                            IpAddress = receivedMessage.RemoteEndPoint.Address,
                            DeviceType = (DeviceType)deviceType
                        });
                    }
                }
            }
        }
    }
}
