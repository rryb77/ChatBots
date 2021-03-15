namespace ChatBots
{
    // Mimic bot is using the IChatBot interface
    public class ShoutBot : IChatBot
    {

        public string Name { get; } = "Shouter";
        public string WelcomeText { get; } = "I LOVE TO SHOUT! WHAT DO YOU WANT TO SHOUT?";

        public string SendMessage(string message)
        {
            string LastChar = message.Substring(message.Length - 1, 1);

            if (LastChar == "." || LastChar == "?" || LastChar == "!")
            {
                return message.Remove(message.Length - 1, 1).ToUpper() + "!";
            }

            return message.ToUpper() + "!";
        }
    }
}