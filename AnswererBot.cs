using System;
using System.Collections.Generic;

namespace ChatBots
{
    public class AnswererBot : IChatBot
    {
        // Create a private list of replies for the answer bot to use
        private List<string> _answers = new List<string>() {
            "Yes!",
            "No.",
            "Hardly ever.",
            "Such questions should not be asked.",
            "I'm glad you asked, but I have no idea.",
            "I don't know.",
            "I do know, but I won't say.",
            "It depends.",
            "If only you'd thought to ask that earlier.",
            "Why not?",
            "I cannot effectively express how little I care.",
            "Have you considered figuring it out for yourself?",
            "Probably?",
            "Absolutely!",
            "I doubt it, but maybe.",
        };

        // Set the name of the bot, and only allow it to be accessed with 'get'
        public string Name { get; } = "Answerer";

        // Set the welcome text to be shown once the bot is chosen by the user
        public string WelcomeText { get; } = "Ask me a question. I have all the answers.";

        // Take the question from the user and reply with an answer
        public string SendMessage(string message)
        {
            // If the user message doesn't end with a '?' then refuse to reply and send this message
            if (!message.EndsWith("?"))
            {
                return "I will only respond to questions.";
            }

            // Since user message ends with a '?' generate a random number and return the answer with the index of that from the _answers list
            int randomIndex = new Random().Next(_answers.Count);
            return _answers[randomIndex];
        }
    }
}