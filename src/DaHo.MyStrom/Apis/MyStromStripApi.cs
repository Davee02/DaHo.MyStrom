using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;

namespace DaHo.MyStrom
{
    public class MyStromLedStripApi : GeneralMyStromApi, IMyStromLedStripApi
    {
        public MyStromLedStripApi(string myStromDeviceAddress, HttpMessageHandler handler = null)
            : base(myStromDeviceAddress, handler)
        { }

        /// <inheritdoc/>
        public async Task StartLightEffectAsync(int effectNumber)
        {
            await PostAsync($"api/v1/effect/start/{effectNumber}");
        }

        /// <inheritdoc/>
        public void StartLightEffect(int effectNumber)
        {
            Post($"api/v1/effect/start/{effectNumber}");
        }

        /// <inheritdoc/>
        public async Task StopLightEffectAsync()
        {
            await PostAsync("api/v1/effect/stop");
        }

        /// <inheritdoc/>
        public void StopLightEffect()
        {
            Post("api/v1/effect/stop");
        }

        /// <inheritdoc/>
        public async Task SetLightEffectAsync(int effectNumber, IEnumerable<LightEffect> lightEffects)
        {
            await PostRawAsync($"api/v1/effect/set/{effectNumber}", new JsonContent(lightEffects));
        }

        /// <inheritdoc/>
        public void SetLightEffect(int effectNumber, IEnumerable<LightEffect> lightEffects)
        {
            PostRaw($"api/v1/effect/set/{effectNumber}", new JsonContent(lightEffects));
        }
    }
}