using System.Linq;

namespace ChatBots
{
    // The ReverserBot is using the IChatBot interface
    public class ReverserBot : IChatBot
    {
        // Set the name of the bot and allow it to be accessed only.
        public string Name { get; } = "Reverser";
        // Set up the WelcomeText variable
        public string WelcomeText { get; }

        // Reverse the welcome text so the theme is inline with the bot style
        public ReverserBot()
        {
            WelcomeText = Reverse("I will reverse your words for you.");
        }

        // Take the user message, reverse it, and print it to the console
        public string SendMessage(string message)
        {
            return Reverse(message);
        }

        // Reverse the user message
        private string Reverse(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}