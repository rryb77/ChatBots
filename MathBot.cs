using System;
using System.Collections.Generic;

namespace ChatBots
{
    public class MathBot : IChatBot
    {
        // Create a private list of replies for the answer bot to use
        private List<string> _userMessages = new List<string>();

        // Set the name of the bot, and only allow it to be accessed with 'get'
        public string Name { get; } = "MathBot";

        // Set the welcome text to be shown once the bot is chosen by the user
        public string WelcomeText { get; } = "Let's do some math. Give me numbers seperated by spaces and I'll add 'em up!";

        // Take the question from the user and reply with an answer
        public string SendMessage(string message)
        {
            string[] Split = message.Split(' ');
            int answer = 0;
            int counter = 0;

            string mathType = Split[0];

            foreach (string s in Split)
            {
                try
                {
                    int parsed = Int32.Parse(s);

                    if (mathType == "add")
                    {

                        answer = answer + parsed;
                    }
                    else if (mathType == "subtract")
                    {
                        if (counter == 1)
                        {
                            answer = Int32.Parse(s);
                        }
                        else if (counter > 1)
                        {
                            answer = answer - parsed;
                        }
                    }
                    else if (mathType == "multiply")
                    {
                        if (counter == 1)
                        {
                            answer = Int32.Parse(s);
                        }
                        else if (counter > 1)
                        {
                            answer = answer * parsed;
                        }

                    }
                    else if (mathType == "divide")
                    {
                        if (counter == 1)
                        {
                            answer = Int32.Parse(s);
                        }
                        else if (counter > 1)
                        {
                            answer = answer / parsed;
                        }
                    }

                    counter++;
                }
                catch
                {
                    counter++;
                    continue;
                }
            }

            return answer.ToString();
        }
    }
}