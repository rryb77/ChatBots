using System.Collections.Generic;

namespace ChatBots
{
    public class MemoryBot : IChatBot
    {
        // Create a private list of replies for the answer bot to use
        private List<string> _userMessages = new List<string>();

        // Set the name of the bot, and only allow it to be accessed with 'get'
        public string Name { get; } = "Membot";

        // Set the welcome text to be shown once the bot is chosen by the user
        public string WelcomeText { get; } = "Tell me stuff, and I'll repeat all of it back.";

        // Take the question from the user and reply with an answer
        public string SendMessage(string message)
        {

            string allMessages = "";
            _userMessages.Add(message);

            foreach (string userMessage in _userMessages)
            {
                allMessages = allMessages + "\n" + userMessage;
            };


            return allMessages;
        }
    }
}