using System.Collections.Generic;
using System.Threading.Tasks;
using DaHo.MyStrom.Models;
using DaHo.MyStrom.Models.Enums;

namespace DaHo.MyStrom.Abstractions
{
    public interface IMyStromButtonApi : IGeneralMyStromApi
    {
        /// <summary>
        /// Asynchronously sets a list of actions for a specific action / interaction type
        /// </summary>
        /// <param name="actionType">The action / interaction type</param>
        /// <param name="actions">A list of actions</param>
        Task SetButtonActionsAsync(ButtonActionType actionType, IEnumerable<ButtonAction> actions);
        /// <summary>
        /// Sets a list of actions for a specific action / interaction type
        /// </summary>
        /// <param name="actionType">The action / interaction type</param>
        /// <param name="actions">A list of actions</param>
        void SetButtonActions(ButtonActionType actionType, IEnumerable<ButtonAction> actions);

        /// <summary>
        /// Asynchronously gets general information about the button
        /// </summary>
        Task<ButtonInfo> GetButtonInfoAsync();
        /// <summary>
        /// Gets general information about the button
        /// </summary>
        ButtonInfo GetButtonInfo();

        /// <summary>
        /// Asynchronously gets the currently assigned action for the specified interaction with the button
        /// </summary>
        /// <param name="actionType">The action / interaction type</param>
        Task<ButtonAction> GetButtonActionAsync(ButtonActionType actionType);
        /// <summary>
        /// Gets the currently assigned action for the specified interaction with the button
        /// </summary>
        /// <param name="actionType">The action / interaction type</param>
        ButtonAction GetButtonAction(ButtonActionType actionType);
    }
}