using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class WebrequestPowerCycleParameters
    {
        /// <summary>
        /// The network address we want to check if it is still up
        /// </summary>
        [JsonProperty("address")]
        public string WebrequestAddress { get; set; }

        /// <summary>
        /// Interval in seconds until we check again
        /// </summary>
        [JsonProperty("tryAt")]
        public int RequestInterval { get; set; }

        /// <summary>
        /// How many times we retry to check the address if a request has failed
        /// </summary>
        [JsonProperty("attempts")]
        public int RequestAttempts { get; set; }

        /// <summary>
        /// Wether or not we actually want to enable this function
        /// </summary>
        [JsonProperty("enable")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Minimum duration in seconds until the switch can be turned on/off again due to the ping not suceeding
        /// </summary>
        [JsonProperty("inhibitTime")]
        public int InhibitTime { get; set; }

        /// <summary>
        /// How long the ping waits for a response until it fails (in ms)
        /// </summary>
        [JsonProperty("pingTimeout")]
        public int RequestTimeout { get; set; }

        /// <summary>
        /// The time the switch remains off before it starts again
        /// </summary>
        [JsonProperty("relayOffTime")]
        public int SwitchOffTime { get; set; }
    }
}