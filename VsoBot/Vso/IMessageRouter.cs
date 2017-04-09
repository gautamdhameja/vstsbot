using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoBot.Vso
{
    public interface IMessageRouter
    {
        Task<string> RouteMessageAsync(Activity activity);
    }
}
