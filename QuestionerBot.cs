using System;
using System.Collections.Generic;

namespace ChatBots
{
    // QuetionerBot is using the IChatBot interface
    public class QuestionerBot : IChatBot
    {
        // Create a private list of questions to ask the user
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

        // Give the bot a name and allow it to be accessed only
        public string Name { get; } = "Questioner";

        // Set the welcome text for this bot and allow it to be accessed only
        public string WelcomeText { get; } = "I will ask you questions. Ready?";

        // Send out messages to the user
        public string SendMessage(string message)
        {
            // If the user message ends with a '?' print this message
            if (message.EndsWith("?"))
            {
                return "Hey, I ask the questions around here!";
            }

            // The user message didn't end with a '?' so get a random number and use it to grab a random index from the private questions list
            int randomIndex = new Random().Next(_questions.Count);
            return _questions[randomIndex];
        }
    }
}