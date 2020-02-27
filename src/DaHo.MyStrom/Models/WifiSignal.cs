namespace DaHo.MyStrom.Models
{
    public class WifiSignal
    {
        /// <summary>
        /// SSID of the Wifi
        /// </summary>
        public string WifiName { get; set; }

        /// <summary>
        /// Wireless signal strength measured in dBm (decibel milliwatts) 
        /// </summary>
        public int SignalStrength { get; set; }
    }
}
