using System.Collections.Generic;
using System.Threading.Tasks;
using DaHo.MyStrom.Models;

namespace DaHo.MyStrom.Abstractions
{
    public interface IMyStromLedStripApi : IGeneralMyStromApi
    {
        /// <summary>
        /// Asynchronously starts the light effect
        /// </summary>
        /// <param name="effectNumber">The number indicating the effect we are starting.</param>
        Task StartLightEffectAsync(int effectNumber);
        /// <summary>
        /// Starts the light effect
        /// </summary>
        /// <param name="effectNumber">The number indicating the effect we are starting</param>
        void StartLightEffect(int effectNumber);

        /// <summary>
        /// Asynchronously stops any currently ongoing light effect
        /// </summary>
        Task StopLightEffectAsync();
        /// <summary>
        /// Stops any currently ongoing light effect
        /// </summary>
        void StopLightEffect();

        /// <summary>
        /// Asynchronously saves a list of light effects to a specific number
        /// </summary>
        /// <param name="effectNumber">The number indicating the effect we are setting</param>
        /// <param name="lightEffects">A list of light effects the LED strip will go through</param>
        Task SetLightEffectAsync(int effectNumber, IEnumerable<LightEffect> lightEffects);
        /// <summary>
        /// Saves a list of light effects to a specific number
        /// </summary>
        /// <param name="effectNumber">The number indicating the effect we are setting</param>
        /// <param name="lightEffects">A list of light effects the LED strip will go through</param>
        void SetLightEffect(int effectNumber, IEnumerable<LightEffect> lightEffects);
    }
}