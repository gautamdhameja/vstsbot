using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VsoBot
{
    /// <summary>
    /// Static strings used for generic bot replies
    /// </summary>
    public static class BotReplyConstants
    {
        public static string Error = "Some error occurred!";

        public static string DidNotUnderstand = "Sorry, I didn't get that. Please send 'help' and I'll tell you what I support.";

        public static string SetupSuccess = "You are all set up. Ready to go!";

        public static string SetupFailure = "Error setting your creds. Valid format is 'Set me up <space> <token>'.";
    }
}