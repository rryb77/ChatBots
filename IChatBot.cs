namespace ChatBots
{
    // Interface defining what ALL chat bots must have
    public interface IChatBot
    {
        string Name { get; }
        string WelcomeText { get; }

        string SendMessage(string message);
    }
}