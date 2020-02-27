using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum ButtonActionType
    {
        /// <summary>
        /// Pressing the button once
        /// </summary>
        [EnumMember(Value = "single")]
        Single = 0,

        /// <summary>
        /// Pressing the button twice
        /// </summary>
        [EnumMember(Value = "double")]
        Double = 1,

        /// <summary>
        /// Pressing the button long
        /// </summary>
        [EnumMember(Value = "long")]
        Long = 2,

        /// <summary>
        /// Execute in case of any action on button. Additionally, automatically every 12 hours
        /// </summary>
        [EnumMember(Value = "generic")]
        Generic = 3
    }
}