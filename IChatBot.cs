namespace ChatBots
{
    public interface IChatBot
    {
        string Name { get; }
        string WelcomeText { get; }

        string SendMessage(string message);
    }
}