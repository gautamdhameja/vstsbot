using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace VsoBot.Auth
{
    /// <summary>
    /// Authorization setup service
    /// </summary>
    public class AuthService : IAuthService
    {
        private const string PATKey = "PAT";

        /// <summary>
        /// Saves the VSO Public Access Token for the user
        /// </summary>
        /// <param name="creds"></param>
        /// <param name="currentActivity"></param>
        /// <returns></returns>
        public async Task<bool> SetCreds(VsoCreds creds, Activity currentActivity)
        {
            var result = false;

            try
            {
                var stateClient = currentActivity.GetStateClient();
                var userData = await stateClient.BotState.GetUserDataAsync(currentActivity.ChannelId, currentActivity.From.Id);
                userData.SetProperty<string>(PATKey, creds.Token);
                await stateClient.BotState.SetUserDataAsync(currentActivity.ChannelId, currentActivity.From.Id, userData);
                result = true;
            }
            catch
            {
                // TODO: Handle it
                result = false;
            }            

            return result;
        }

        /// <summary>
        /// Gets the VSO Public Access Token for the user
        /// </summary>
        /// <param name="creds"></param>
        /// <param name="currentActivity"></param>
        /// <returns></returns>
        public async Task<VsoCreds> GetCreds(Activity currentActivity)
        {
            VsoCreds result = null;

            try
            {
                var stateClient = currentActivity.GetStateClient();
                var userData = await stateClient.BotState.GetUserDataAsync(currentActivity.ChannelId, currentActivity.From.Id);
                var token = userData.GetProperty<string>(PATKey);
                result = new VsoCreds { Token = token };
            }
            catch
            {
                // TODO: Handle it
                result = null;
            }

            return result;
        }
    }
}