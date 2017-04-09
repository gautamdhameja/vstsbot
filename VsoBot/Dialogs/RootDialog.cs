using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using VsoBot.Vso;

namespace VsoBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        [NonSerialized]
        private readonly IMessageRouter messageRouter;

        public RootDialog(IMessageRouter router)
        {
            this.messageRouter = router;
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.PostAsync(await this.messageRouter.RouteMessageAsync(context.Activity as Activity));
            
            context.Wait(MessageReceivedAsync);
        }
    }
}