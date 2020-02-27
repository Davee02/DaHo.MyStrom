using DaHo.Library.Utilities;
using DaHo.MyStrom.Models.Enums;
using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models
{
    public class ButtonAction
    {
        public ButtonRequestType RequestType { get; set; }

        public string RequestAddress { get; set; }

        public int RequestPort { get; set; }

        public string RequestData { get; set; }


        public override string ToString()
        {
            var typeString = RequestType.GetAttributeFromEnum<EnumMemberAttribute>().Value;
            return $"{typeString}://{RequestAddress}:{RequestPort}?{RequestData}";
        }

        public static ButtonAction FromString(string value)
        {
            return new ButtonAction();
        }
    }
}