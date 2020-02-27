using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum SwitchPowerState
    {
        /// <summary>
        /// Turn the switch off
        /// </summary>
        [EnumMember(Value = "off")]
        Off = 0,

        /// <summary>
        /// Turn the switch on
        /// </summary>
        [EnumMember(Value = "on")]
        On = 1
    }
}