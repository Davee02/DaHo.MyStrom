using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class ScannedWifi
    {
        /// <summary>
        /// SSID of the Wifi
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Wireless signal strength measured in dBm (decibel milliwatts) 
        /// </summary>
        [JsonProperty("signal")]
        public long SignalStrength { get; set; }

        /// <summary>
        /// Wether or not the wifi signal is encrypted
        /// </summary>
        [JsonProperty("encryption-on")]
        public bool IsEncryptionOn { get; set; }

        /// <summary>
        /// The encryption standard used
        /// </summary>
        [JsonProperty("encryption")]
        public string EncryptionName { get; set; }
    }
}