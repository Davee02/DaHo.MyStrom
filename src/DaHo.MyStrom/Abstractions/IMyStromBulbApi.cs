using System.Threading.Tasks;
using DaHo.MyStrom.Models;

namespace DaHo.MyStrom.Abstractions
{
    public interface IMyStromBulbApi : IGeneralMyStromApi
    {
        /// <summary>
        /// Asynchronously sets the powermode (on, off or toggle) of the bulb
        /// </summary>
        /// <param name="bulbMacAddress">The MAC address of the bulb</param>
        /// <param name="powerMode">The desired powermode</param>
        Task<BulbResponse> SetPowerModeAsync(string bulbMacAddress, BulbPowerModeRequest powerMode);
        /// <summary>
        /// Sets the powermode (on, off or toggle) of the bulb
        /// </summary>
        /// <param name="bulbMacAddress">The MAC address of the bulb</param>
        /// <param name="powerMode">The desired powermode</param>
        BulbResponse SetPowerMode(string bulbMacAddress, BulbPowerModeRequest powerMode);

        /// <summary>
        /// Asynchronously sets the color and the powermode of the bulb
        /// </summary>
        /// <param name="bulbMacAddress">The MAC address of the bulb</param>
        /// <param name="colorParameters">The desired color and powermode</param>
        Task<BulbResponse> SetColorAsync(string bulbMacAddress, BulbColorParameters colorParameters);
        /// <summary>
        /// Sets the color and the powermode of the bulb
        /// </summary>
        /// <param name="bulbMacAddress">The MAC address of the bulb</param>
        /// <param name="colorParameters">The desired color and powermode</param>
        BulbResponse SetColor(string bulbMacAddress, BulbColorParameters colorParameters);

        /// <summary>
        /// Asynchronously gets general information about the bulb
        /// </summary>
        Task<BulbInfo> GetBulbInfoAsync();
        /// <summary>
        /// Gets general information about the bulb
        /// </summary>
        BulbInfo GetBulbInfo();

        /// <summary>
        /// Asynchronously gets the current color and colormode
        /// </summary>
        Task<BulbColorSettings> GetColorSettingsAsync();
        /// <summary>
        /// Gets the current color and colormode
        /// </summary>
        BulbColorSettings GetColorSettings();
    }
}