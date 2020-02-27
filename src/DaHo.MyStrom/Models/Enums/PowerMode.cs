using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum PowerMode
    {
        /// <summary>
        /// Turning the device off
        /// </summary>
        [EnumMember(Value = "off")]
        Off = 0,

        /// <summary>
        /// Turning the device on
        /// </summary>
        [EnumMember(Value = "on")]
        On = 1,

        /// <summary>
        /// Toggles the device (on -> off or off -> on)
        /// </summary>
        [EnumMember(Value = "toggle")]
        Toggle = 2
    }
}