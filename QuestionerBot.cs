using System;
using System.Collections.Generic;

namespace ChatBots
{
    public class QuestionerBot : IChatBot
    {
        private List<string> _questions = new List<string>() {
            "Are you having a good day?",
            "Have you seen Bill and Ted's Excellent Adventure?",
            "Why did the chicken cross the road?",
            "Why are we here?",
            "Why is the sky blue?",
            "Where does Santa do his grocery shopping?",
            "Have you ever been on the moon?",
            "Do you like talking to me?",
            "Do you think I'm attractive?",
            "If you were tree, what kind of tree would you be?",
            "Which is better, ice cream or bacon?"
        };

        public string Name { get; } = "Questioner";

        public string WelcomeText { get; } = "I will ask you questions. Ready?";

        public string SendMessage(string message)
        {
            if (message.EndsWith("?"))
            {
                return "Hey, I ask the questions around here!";
            }
            int randomIndex = new Random().Next(_questions.Count);
            return _questions[randomIndex];
        }
    }
}