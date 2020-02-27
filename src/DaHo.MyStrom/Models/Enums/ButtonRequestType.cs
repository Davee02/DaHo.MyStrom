using System.Runtime.Serialization;

namespace DaHo.MyStrom.Models.Enums
{
    public enum ButtonRequestType
    {
        /// <summary>
        /// A HTTP GET request is sent
        /// </summary>
        [EnumMember(Value = "get")]
        Get = 0,

        /// <summary>
        /// A HTTP POST request is sent
        /// </summary>
        [EnumMember(Value = "post")]
        Post = 1,

        /// <summary>
        /// A HTTP GET request is PUT
        /// </summary>
        [EnumMember(Value = "put")]
        Put = 2,

        /// <summary>
        /// A HTTP DELETE request is sent
        /// </summary>
        [EnumMember(Value = "delete")]
        Delete = 3
    }
}