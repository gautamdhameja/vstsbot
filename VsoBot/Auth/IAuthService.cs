using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoBot.Auth
{
    /// <summary>
    /// Authorization setup service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Saves the VSO Public Access Token for the user
        /// </summary>
        /// <param name="creds"></param>
        /// <param name="currentActivity"></param>
        /// <returns></returns>
        Task<bool> SetCreds(VsoCreds creds, Activity currentActivity);

        /// <summary>
        /// Gets the VSO Public Access Token for the user
        /// </summary>
        /// <param name="creds"></param>
        /// <param name="currentActivity"></param>
        /// <returns></returns>
        Task<VsoCreds> GetCreds(Activity currentActivity);
    }
}
