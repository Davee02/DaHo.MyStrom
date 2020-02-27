using Newtonsoft.Json;

namespace DaHo.MyStrom.Models
{
    public class TemperatureMeasurement
    {
        /// <summary>
        /// The measured raw temperature by sensor
        /// </summary>
        [JsonProperty("measured")]
        public double Measured { get; set; }

        /// <summary>
        /// How much we have to compensate the raw <see cref="Measured"/> data for the cpu heat.
        /// </summary>
        [JsonProperty("compensation")]
        public double Compensation { get; set; }

        /// <summary>
        /// The actual room temperature near the device (<see cref="Measured"/> - <see cref="Compensated"/>)
        /// </summary>
        [JsonProperty("compensated")]
        public double Compensated { get; set; }
    }
}