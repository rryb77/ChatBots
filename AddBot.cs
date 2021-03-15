using System;
using System.Collections.Generic;

namespace ChatBots
{
    public class AddBot : IChatBot
    {
        // Create a private list of replies for the answer bot to use
        private List<string> _userMessages = new List<string>();

        // Set the name of the bot, and only allow it to be accessed with 'get'
        public string Name { get; } = "Addbot";

        // Set the welcome text to be shown once the bot is chosen by the user
        public string WelcomeText { get; } = "Let's do some math. Give me numbers seperated by spaces and I'll add 'em up!";

        // Take the question from the user and reply with an answer
        public string SendMessage(string message)
        {
            string[] Split = message.Split(' ');
            int answer = 0;

            foreach (string s in Split)
            {
                try
                {
                    int parsed = Int32.Parse(s);
                    answer = answer + parsed;
                }
                catch
                {
                    continue;
                }

            }
            return answer.ToString();
        }
    }
}