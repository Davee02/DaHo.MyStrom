using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using DaHo.Library.Utilities;
using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;

namespace DaHo.MyStrom
{
    public class MyStromButtonApi : GeneralMyStromApi, IMyStromButtonApi
    {
        public MyStromButtonApi(string myStromDeviceAddress, HttpMessageHandler handler = null)
            : base(myStromDeviceAddress, handler)
        { }

        /// <inheritdoc/>
        public async Task SetButtonActionsAsync(ButtonActionType actionType, IEnumerable<ButtonAction> actions)
        {
            var typeString = actionType.GetAttributeFromEnum<EnumMemberAttribute>().Value;
            var actionString = actions.Select(x => x.ToString()).Aggregate((x, y) => $"{x}||{y}");

            if (actionString.Length >= 800)
                throw new ArgumentException($"The length of the action has to be smaller than 800 characters. Actual length: {actionString.Length}");

            await PostRawAsync($"api/v1/action/{typeString}", new StringContent(actionString));
        }

        /// <inheritdoc/>
        public void SetButtonActions(ButtonActionType actionType, IEnumerable<ButtonAction> actions)
        {
            var typeString = actionType.GetAttributeFromEnum<EnumMemberAttribute>().Value;
            var actionString = actions.Select(x => x.ToString()).Aggregate((x, y) => $"{x}||{y}");

            if (actionString.Length >= 800)
                throw new ArgumentException($"The length of the action has to be smaller than 800 characters. Actual length: {actionString.Length}");

            PostRaw($"api/v1/action/{typeString}", new StringContent(actionString));
        }

        /// <inheritdoc/>
        public async Task<ButtonInfo> GetButtonInfoAsync()
        {
            return await GetAsync<ButtonInfo>("api/v1/device");
        }

        /// <inheritdoc/>
        public ButtonInfo GetButtonInfo()
        {
            return Get<ButtonInfo>("api/v1/device");
        }

        /// <inheritdoc/>
        public async Task<ButtonAction> GetButtonActionAsync(ButtonActionType actionType)
        {
            var typeString = actionType.GetAttributeFromEnum<EnumMemberAttribute>().Value;
            var raw = await GetAsync<IDictionary<string, string>>($"api/v1/action/{typeString}");

            return ButtonAction.FromString(raw["url"]);
        }

        /// <inheritdoc/>
        public ButtonAction GetButtonAction(ButtonActionType actionType)
        {
            var typeString = actionType.GetAttributeFromEnum<EnumMemberAttribute>().Value;
            var raw = Get<IDictionary<string, string>>($"api/v1/action/{typeString}");

            return ButtonAction.FromString(raw["url"]);
        }
    }
}