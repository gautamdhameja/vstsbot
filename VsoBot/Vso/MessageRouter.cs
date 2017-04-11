using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Threading.Tasks;
using VsoBot.Auth;

namespace VsoBot.Vso
{
    /// <summary>
    /// Routes incoming messages
    /// </summary>
    public class MessageRouter : IMessageRouter
    {
        private readonly IAuthService authService;

        public MessageRouter(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<string> RouteMessageAsync(Activity activity)
        {
            if (!string.IsNullOrWhiteSpace(activity.Text))
            {
                if (activity.Text.StartsWith("Set me up", StringComparison.InvariantCultureIgnoreCase))
                {
                    var pat = activity.Text.Split(' ').Last();
                    if(await this.authService.SetCreds(new Auth.VsoCreds { Token = pat }, activity))
                    {
                        return BotReplyConstants.SetupSuccess;
                    }
                    else
                    {
                        return BotReplyConstants.SetupFailure;
                    }
                }

                if (activity.Text.Equals("Get my token", StringComparison.InvariantCultureIgnoreCase))
                {
                    return (await this.authService.GetCreds(activity)).Token;            
                }

                if (activity.Text.Equals("Hi", StringComparison.InvariantCultureIgnoreCase))
                {
                    return BotReplyConstants.DidNotUnderstand;
                }
            }

            return BotReplyConstants.DidNotUnderstand;
        }
    }
}