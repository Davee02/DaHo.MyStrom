using DaHo.MyStrom.Models.Enums;
using System.Net;

namespace DaHo.MyStrom.Models
{
    public class MyStromDevice
    {
        /// <summary>
        /// The MAC address, without any delimiters
        /// </summary>
        /// <example>3065EC6FC458</example>
        public string MacAddress { get; set; }

        /// <summary>
        /// The IP address
        /// </summary>
        public IPAddress IpAddress { get; set; }

        /// <summary>
        /// The device type
        /// </summary>
        public DeviceType DeviceType { get; set; }
    }
}
