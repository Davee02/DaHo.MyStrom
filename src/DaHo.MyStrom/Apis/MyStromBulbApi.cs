using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;
using DaHo.MyStrom.Utilities;

namespace DaHo.MyStrom
{
    public class MyStromBulbApi : GeneralMyStromApi, IMyStromBulbApi
    {
        public MyStromBulbApi(string myStromDeviceAddress, HttpMessageHandler handler = null)
            : base(myStromDeviceAddress, handler)
        { }

        /// <inheritdoc/>
        public async Task<BulbResponse> SetPowerModeAsync(string bulbMacAddress, BulbPowerModeRequest powerMode)
        {
            var response = await PostAsync<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", powerMode.ToDictionary());
            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public BulbResponse SetPowerMode(string bulbMacAddress, BulbPowerModeRequest powerMode)
        {
            var response = Post<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", powerMode.ToDictionary());
            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public async Task<BulbResponse> SetColorAsync(string bulbMacAddress, BulbColorParameters colorParameters)
        {
            ValidateColor(colorParameters.ColorMode, colorParameters.Color);

            IDictionary<string, BulbResponse> response;
            if (colorParameters.ColorMode == BulbColorMode.Wrgb)
            {
                response = await PostAsync<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", colorParameters.ToDictionary());
            }
            else
            {
                var content = new StringContent(colorParameters.ToFormString(), Encoding.UTF8, "application/x-www-form-urlencoded");
                response = await PostRawAsync<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", content);
            }

            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public BulbResponse SetColor(string bulbMacAddress, BulbColorParameters colorParameters)
        {
            ValidateColor(colorParameters.ColorMode, colorParameters.Color);

            IDictionary<string, BulbResponse> response;
            if (colorParameters.ColorMode == BulbColorMode.Wrgb)
            {
                response = Post<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", colorParameters.ToDictionary());
            }
            else
            {
                var content = new StringContent(colorParameters.ToFormString(), Encoding.UTF8, "application/x-www-form-urlencoded");
                response = PostRaw<IDictionary<string, BulbResponse>>($"api/v1/device/{bulbMacAddress}", content);
            }

            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public async Task<BulbInfo> GetBulbInfoAsync()
        {
            var response = await GetAsync<IDictionary<string, BulbInfo>>("api/v1/device");
            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public BulbInfo GetBulbInfo()
        {
            var response = Get<IDictionary<string, BulbInfo>>("api/v1/device");
            return response.FirstOrDefault().Value;
        }

        /// <inheritdoc/>
        public async Task<BulbColorSettings> GetColorSettingsAsync()
        {
            return await GetAsync<BulbColorSettings>("api/v1/colors");
        }

        /// <inheritdoc/>
        public BulbColorSettings GetColorSettings()
        {
            return Get<BulbColorSettings>("api/v1/colors");
        }

        /// <summary>
        /// Checks if the <paramref name="color"/> is in the correct format and throws an <see cref="ArgumentException"/> if not
        /// </summary>
        private void ValidateColor(BulbColorMode colorMode, string color)
        {
            var validationResult = ColorValidator.ValidateFormat(colorMode, color);

            if (!validationResult.Success)
                throw new ArgumentException($"The color has an invalid format: {validationResult.ValidationError}");
        }
    }
}