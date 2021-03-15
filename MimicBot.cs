namespace ChatBots
{
    // Mimic bot is using the IChatBot interface
    public class MimicBot : IChatBot
    {

        public string Name { get; } = "Mimic";
        public string WelcomeText { get; } = "";

        public string SendMessage(string message)
        {
            return message;
        }
    }
}