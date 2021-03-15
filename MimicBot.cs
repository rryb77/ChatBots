namespace ChatBots
{
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