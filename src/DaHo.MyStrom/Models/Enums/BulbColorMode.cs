using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum BulbColorMode
    {
        /// <summary>
        /// The color in the WRBG format
        /// Contains the hex-values of each components of the the WRGB color (white;red;green;blue)
        /// </summary>
        /// <example>
        /// white: FF000000
        /// green: 0000ff00
        /// </example>
        /// <remarks>
        /// The hex-identifier (#) must not be included
        /// </remarks>
        [EnumMember(Value = "rgb")]
        Wrgb = 0,

        /// <summary>
        /// The color in the HSV format
        /// Contains 3 semi-colon delimited integers in the HSV format (hue 0-359;saturation 0-100;value 0-100)
        /// </summary>
        /// <example>
        /// white: 0;0;100
        /// green: 120;100;100
        /// </example>
        [EnumMember(Value = "hsv")]
        Hsv = 1,

        /// <summary>
        /// The color in the mono format
        /// Contains 2 semi-colon delimited integers in the format (color temperature 1-18;brightness 0-100)
        /// </summary>
        /// <example>
        /// Color temp. 1 with full brightness: 1;100
        /// color temp. 5 with half brightness: 5;50
        /// </example>
        [EnumMember(Value = "mono")]
        Mono = 2
    }
}