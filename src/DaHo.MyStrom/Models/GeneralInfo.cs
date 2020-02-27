using DaHo.MyStrom.Models.Enums;
using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class GeneralInfo
    {
        /// <summary>
        /// Current firmware version
        /// </summary>
        [JsonProperty("version")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// The MAC address, without any delimiters
        /// </summary>
        /// <example>3065EC6FC458</example>
        [JsonProperty("mac")]
        public string MacAddress { get; set; }

        /// <summary>
        /// The type of the queried device
        /// </summary>
        [JsonProperty("type")]
        public DeviceType Type { get; set; }

        /// <summary>
        /// SSID of the currently connected network
        /// </summary>
        [JsonProperty("ssid")]
        public string Ssid { get; set; }

        /// <summary>
        /// Current ip address
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Mask of the current network
        /// </summary>
        [JsonProperty("mask")]
        public string SubnetMask { get; set; }

        /// <summary>
        /// Gateway of the current network
        /// </summary>
        [JsonProperty("gw")]
        public string Gateway { get; set; }

        /// <summary>
        /// DNS of the curent network
        /// </summary>
        [JsonProperty("dns")]
        public string Dns { get; set; }

        /// <summary>
        /// Wether or not the ip address is static
        /// </summary>
        [JsonProperty("static")]
        public bool IsIpAddressStatic { get; set; }

        /// <summary>
        /// Wether or not the device is connected to the internet
        /// </summary>
        [JsonProperty("connected")]
        public bool IsConnectedToInternet { get; set; }
    }
}