using System;
using System.Collections.Generic;

namespace ChatBots
{
    public class AnswererBot : IChatBot
    {
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

        public string Name { get; } = "Answerer";

        public string WelcomeText { get; } = "Ask me a question. I have all the answers.";

        public string SendMessage(string message)
        {
            if (!message.EndsWith("?"))
            {
                return "I will only respond to questions.";
            }

            int randomIndex = new Random().Next(_answers.Count);
            return _answers[randomIndex];
        }
    }
}