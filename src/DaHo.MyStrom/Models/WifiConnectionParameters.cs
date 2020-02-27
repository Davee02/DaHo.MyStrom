using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class WifiConnectionParameters
    {
        /// <summary>
		/// The SSID of the network you want your device to connect to
		/// </summary>
        [JsonProperty("ssid")]
        public string Ssid { get; set; }

        /// <summary>
		/// The password of the network you want your device to connect to
		/// </summary>
        [JsonProperty("passwd")]
        public string Password { get; set; }
    }
}