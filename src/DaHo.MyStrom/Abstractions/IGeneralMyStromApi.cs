using System.Collections.Generic;
using System.Threading.Tasks;
using DaHo.MyStrom.Models;

namespace DaHo.MyStrom.Abstractions
{
    public interface IGeneralMyStromApi
    {
        /// <summary>
        /// Asynchronously gets general information about your myStrom device
        /// </summary>
        Task<GeneralInfo> GetGeneralInfoAsync();
        /// <summary>
        /// Gets general information about your myStrom device
        /// </summary>
        GeneralInfo GetGeneralInfo();

        /// <summary>
        /// Asynchronously scans for nearby wifi networks
        /// </summary>
        Task<IEnumerable<WifiSignal>> GetWifiWithSignalStrengthsAsync();
        /// <summary>
        /// Scans for nearby wifi networks
        /// </summary>
        IEnumerable<WifiSignal> GetWifiWithSignalStrengths();

        /// <summary>
        /// Asynchronously returns quick help of available HTTP API queries. The result depends on device type.
        /// </summary>
        /// <remarks>
        /// The first word specifies the type of method the query should be executed: GET or POST. 
        /// Then the path and possible parameters appear. Square brackets indicate the optional part. Sharp brackets mean that value should be substituted for them. 
        /// The sharp start parenthesis is followed by the type of the variable and its range.
        /// The pipe character specifies that one of the values separated by it should be set. If there is a space after the path and its parameters, then the query parameters should be sent as a JSON object, otherwise the parameters for POST queries should be sent in the format key=value[&key=value] application / x-www-form-urlencoded.
        /// This API is available for all device types with the latest firmware version. It may not be on older devices.
        /// </remarks>
        Task<string> GetHelpAsync();
        /// <summary>
        /// Returns quick help of available HTTP API queries. The result depends on device type.
        /// </summary>
        /// <remarks>
        /// The first word specifies the type of method the query should be executed: GET or POST. 
        /// Then the path and possible parameters appear. Square brackets indicate the optional part. Sharp brackets mean that value should be substituted for them. 
        /// The sharp start parenthesis is followed by the type of the variable and its range.
        /// The pipe character specifies that one of the values separated by it should be set. If there is a space after the path and its parameters, then the query parameters should be sent as a JSON object, otherwise the parameters for POST queries should be sent in the format key=value[&key=value] application / x-www-form-urlencoded.
        /// This API is available for all device types with the latest firmware version. It may not be on older devices.
        /// </remarks>
        string GetHelp();
    }
}