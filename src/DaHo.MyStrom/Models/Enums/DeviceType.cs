using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum DeviceType
    {
        /// <summary>
        /// Switch CH v1
        /// </summary>
        [EnumMember(Value = "Switch CH v1")]
        SwitchChV1 = 101,

        /// <summary>
        /// Bulb
        /// </summary>
        [EnumMember(Value = "Bulb")]
        Bulb = 102,

        /// <summary>
        /// Button+
        /// </summary>
        [EnumMember(Value = "Button+")]
        ButtonPlus = 103,

        /// <summary>
        /// Button
        /// </summary>
        [EnumMember(Value = "Button")]
        Button = 104,

        /// <summary>
        /// LED strip
        /// </summary>
        [EnumMember(Value = "LED strip")]
        LedStrip = 105,

        /// <summary>
        /// Switch CH v2
        /// </summary>
        [EnumMember(Value = "WS2")]
        SwitchChV2 = 106,

        /// <summary>
        /// Switch EU
        /// </summary>
        [EnumMember(Value = "Switch EU")]
        SwitchEu = 107
    }
}
