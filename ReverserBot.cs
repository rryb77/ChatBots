using System.Linq;

namespace ChatBots
{
    public class ReverserBot : IChatBot
    {
        public string Name { get; } = "Reverser";
        public string WelcomeText { get; }

        public ReverserBot()
        {
            WelcomeText = Reverse("I will reverse your words for you.");
        }

        public string SendMessage(string message)
        {
            return Reverse(message);
        }

        private string Reverse(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}