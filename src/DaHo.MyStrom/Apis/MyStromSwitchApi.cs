using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DaHo.MyStrom.Abstractions;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;
using DaHo.MyStrom.Utilities;

namespace DaHo.MyStrom
{
    public class MyStromSwitchApi : GeneralMyStromApi, IMyStromSwitchApi
    {
        public MyStromSwitchApi(string myStromDeviceAddress, HttpMessageHandler handler = null)
            : base(myStromDeviceAddress, handler)
        { }

        /// <inheritdoc/>
        public async Task SetSwitchPowerStateAsync(SwitchPowerState switchPowerState)
        {
            await GetStringAsync($"relay?state={(int)switchPowerState}");
        }

        /// <inheritdoc/>
        public void SetSwitchPowerState(SwitchPowerState switchPowerState)
        {
            GetString($"relay?state={(int)switchPowerState}");
        }

        /// <inheritdoc/>
        public async Task<SwitchPowerState> ToggleSwitchPowerStateAsync()
        {
            var response = await GetStringAsync("toggle");

            return response.Contains("true")
                ? SwitchPowerState.On
                : SwitchPowerState.Off;
        }

        /// <inheritdoc/>
        public SwitchPowerState ToggleSwitchPowerState()
        {
            var response = GetString("toggle");

            return response.Contains("true")
                ? SwitchPowerState.On
                : SwitchPowerState.Off;
        }

        /// <inheritdoc/>
        public async Task<string> GetLogAsync()
        {
            return await GetStringAsync("log");
        }

        /// <inheritdoc/>
        public string GetLog()
        {
            return GetString("log");
        }

        /// <inheritdoc/>
        public async Task<SwitchReport> GetReportAsync()
        {
            return await GetAsync<SwitchReport>("report");
        }

        /// <inheritdoc/>
        public SwitchReport GetReport()
        {
            return Get<SwitchReport>("report");
        }

        /// <inheritdoc/>
        public async Task<TemperatureMeasurement> GetTemperatureAsync()
        {
            return await GetAsync<TemperatureMeasurement>("temp");
        }

        /// <inheritdoc/>
        public TemperatureMeasurement GetTemperature()
        {
            return Get<TemperatureMeasurement>("temp");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ScannedWifi>> GetNearbyWifisAsync()
        {
            var result = await GetAsync<IDictionary<string, ScannedWifi>>("networks");
            return result.Values;
        }

        /// <inheritdoc/>
        public IEnumerable<ScannedWifi> GetNearbyWifis()
        {
            var result = Get<IDictionary<string, ScannedWifi>>("networks");
            return result.Values;
        }

        /// <inheritdoc/>
        public async Task PowerCycleSwitchAsync(int timeInSeconds)
        {
            if (timeInSeconds > 3600)
                throw new System.ArgumentOutOfRangeException(nameof(timeInSeconds), "The time must not be longer than 3600s (1h)");

            await GetStringAsync($"power_cycle?time={timeInSeconds}");
        }

        /// <inheritdoc/>
        public void PowerCycleSwitch(int timeInSeconds)
        {
            if (timeInSeconds > 3600)
                throw new System.ArgumentOutOfRangeException(nameof(timeInSeconds), "The time must not be longer than 3600s (1h)");

            GetString($"power_cycle?time={timeInSeconds}");
        }

        /// <inheritdoc/>
        public async Task PowerCycleSwitchAsync(AdvancedPowerCycleParameters powerCycleParameters)
        {
            if (powerCycleParameters.TimeInSeconds > 3600)
                throw new System.ArgumentOutOfRangeException(nameof(powerCycleParameters.TimeInSeconds), "The time must not be longer than 3600s (1h)");

            await PostAsync($"timer?mode={powerCycleParameters.PowerCycleMode}&time={powerCycleParameters.TimeInSeconds}");
        }

        /// <inheritdoc/>
        public void PowerCycleSwitch(AdvancedPowerCycleParameters powerCycleParameters)
        {
            if (powerCycleParameters.TimeInSeconds > 3600)
                throw new System.ArgumentOutOfRangeException(nameof(powerCycleParameters.TimeInSeconds), "The time must not be longer than 3600s (1h)");

            Post($"timer?mode={powerCycleParameters.PowerCycleMode.ToString().ToLower()}&time={powerCycleParameters.TimeInSeconds}");
        }

        /// <inheritdoc/>
        public async Task PowerCycleSwitchAsync(WebrequestPowerCycleParameters powerCycleParameters)
        {
            await PostAsync("api/v1/monitor", powerCycleParameters.ToDictionary());
        }

        /// <inheritdoc/>
        public void PowerCycleSwitch(WebrequestPowerCycleParameters powerCycleParameters)
        {
            Post("api/v1/monitor", powerCycleParameters.ToDictionary());
        }
    }
}