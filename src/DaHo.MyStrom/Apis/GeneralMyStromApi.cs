using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;

namespace DaHo.MyStrom
{
    public abstract class GeneralMyStromApi : BaseRestApi, IGeneralMyStromApi
    {
        protected GeneralMyStromApi(string myStromDeviceAddress, HttpMessageHandler handler = null)
        : base(myStromDeviceAddress, handler)
        { }

        /// <inheritdoc/>
        public async Task<GeneralInfo> GetGeneralInfoAsync()
        {
            return await GetAsync<GeneralInfo>("api/v1/info");
        }

        /// <inheritdoc/>
        public GeneralInfo GetGeneralInfo()
        {
            return Get<GeneralInfo>("api/v1/info");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WifiSignal>> GetWifiWithSignalStrengthsAsync()
        {
            var result = (await GetAsync<IEnumerable<string>>("api/v1/scan")).ToList();

            var wifiSignals = new List<WifiSignal>();
            for (int i = 0; i < result.Count / 2; i += 2)
            {
                wifiSignals.Add(new WifiSignal
                {
                    WifiName = result[i],
                    SignalStrength = int.Parse(result[i + 1])
                });
            }

            return wifiSignals;
        }

        /// <inheritdoc/>
        public IEnumerable<WifiSignal> GetWifiWithSignalStrengths()
        {
            var result = Get<IEnumerable<string>>("api/v1/scan").ToList();

            for (int i = 0; i < result.Count / 2; i += 2)
            {
                yield return new WifiSignal
                {
                    WifiName = result[i],
                    SignalStrength = int.Parse(result[i + 1])
                };
            }
        }

        /// <inheritdoc/>
        public async Task<string> GetHelpAsync()
        {
            return await GetStringAsync("help");
        }

        /// <inheritdoc/>
        public string GetHelp()
        {
            return GetString("help");
        }
    }
}