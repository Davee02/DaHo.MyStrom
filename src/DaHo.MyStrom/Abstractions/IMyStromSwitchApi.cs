using System.Collections.Generic;
using System.Threading.Tasks;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;

namespace DaHo.MyStrom.Abstractions
{
    public interface IMyStromSwitchApi : IGeneralMyStromApi
    {
        /// <summary>
        /// Asynchronously turns the switch on or off
        /// </summary>
        /// <param name="switchPowerState">The desired powermode (on or off)</param>
        Task SetSwitchPowerStateAsync(SwitchPowerState switchPowerState);
        /// <summary>
        /// Turns the switch on or off
        /// </summary>
        /// <param name="switchPowerState">The desired powermode (on or off)</param>
        void SetSwitchPowerState(SwitchPowerState switchPowerState);

        /// <summary>
        /// Asynchronously toggles the switch
        /// </summary>
        /// <returns>The powermode after the request has executed</returns>
        Task<SwitchPowerState> ToggleSwitchPowerStateAsync();
        /// <summary>
        /// Toggles the switch
        /// </summary>
        /// <returns>The powermode after the request has executed</returns>
        SwitchPowerState ToggleSwitchPowerState();

        /// <summary>
        /// Asynchronously gets the raw log of the myStrom switch
        /// </summary>
        Task<string> GetLogAsync();
        /// <summary>
        /// Gets the raw log of the myStrom switch
        /// </summary>
        string GetLog();

        /// <summary>
        /// Asynchronously gets a report from the switch
        /// </summary>
        Task<SwitchReport> GetReportAsync();
        /// <summary>
        /// Gets a report from the switch
        /// </summary>
        SwitchReport GetReport();

        /// <summary>
        /// Asynchronously gets more detailed information about the temperature. The compensation field might initially be wrong, but will automatically correct itself over the span of a few hours
        /// </summary>
        Task<TemperatureMeasurement> GetTemperatureAsync();
        /// <summary>
        /// Gets more detailed information about the temperature. The compensation field might initially be wrong, but will automatically correct itself over the span of a few hours
        /// </summary>
        TemperatureMeasurement GetTemperature();

        /// <summary>
        /// Asynchronously scans for nearby wifi networks in a detailed manner
        /// </summary>
        Task<IEnumerable<ScannedWifi>> GetNearbyWifisAsync();
        /// <summary>
        /// Scans for nearby wifi networks in a detailed manner
        /// </summary>
        IEnumerable<ScannedWifi> GetNearbyWifis();

        /// <summary>
        /// Asynchronously turns the switch off, waits for a specified amount of time (max 1h), then starts it again
        /// The switch has to be turned on in order for this call to work
        /// </summary>
        /// <param name="timeInSeconds">The time in seconds to wait before turning the switch on again. The time must not be bigger than 3600s</param>
        Task PowerCycleSwitchAsync(int timeInSeconds);
        /// <summary>
        /// Turns the switch off, waits for a specified amount of time (max 1h), then starts it again
        /// The switch has to be turned on in order for this call to work
        /// </summary>
        /// <param name="timeInSeconds">The time in seconds to wait before turning the switch on again. The time must not be bigger than 3600s</param>
        void PowerCycleSwitch(int timeInSeconds);

        /// <summary>
        /// Asynchronously sets the switch to a specific state, waits for a specified amount of time (max 1h), then sets the the switch to the inverse state.
        /// </summary>
        /// <param name="powerCycleParameters">The parameters for a advanced power cycle</param>
        Task PowerCycleSwitchAsync(AdvancedPowerCycleParameters powerCycleParameters);
        /// <summary>
        /// Sets the switch to a specific state, waits for a specified amount of time (max 1h), then sets the the switch to the inverse state.
        /// </summary>
        /// <param name="powerCycleParameters">The parameters for a advanced power cycle</param>
        void PowerCycleSwitch(AdvancedPowerCycleParameters powerCycleParameters);

        /// <summary>
        /// Asynchronously turns the switch off and on again depending on wether or not a ping succeeds.
        /// With this you can restart your switch if for example, you loose internet connectivity. This can be very usefull if a router is attached to the switch.
        /// This request only works if the switch is currently set to on.
        /// </summary>
        /// <param name="powerCycleParameters">The parameters for a webrequest power cycle</param>
        Task PowerCycleSwitchAsync(WebrequestPowerCycleParameters powerCycleParameters);
        /// <summary>
        /// Turns the switch off and on again depending on wether or not a ping succeeds.
        /// With this you can restart your switch if for example, you loose internet connectivity. This can be very usefull if a router is attached to the switch.
        /// This request only works if the switch is currently set to on.
        /// </summary>
        /// <param name="powerCycleParameters">The parameters for a webrequest power cycle</param>
        void PowerCycleSwitch(WebrequestPowerCycleParameters powerCycleParameters);
    }
}