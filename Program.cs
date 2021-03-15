using System;
using System.Collections.Generic;

namespace ChatBots
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Why talk with people when there are bots?!?!");

            // Create a list of bots
            List<IChatBot> bots = CreateBots();
            // Set the user chosen bot to chosenBot
            IChatBot chosenBot = ChooseBot(bots);
            // Pass the bot into HaveConversation so it can interact with the user
            HaveConversation(chosenBot);
        }

        // The method that creates a list of bots using the IChatBot interface
        static List<IChatBot> CreateBots()
        {
            return new List<IChatBot>() {
                new MimicBot(),
                new ReverserBot(),
                new AnswererBot(),
                new QuestionerBot(),
                new DuckDuckGoBot(),
                new ShoutBot(),
                new MemoryBot(),
                new MathBot(),
            };
        }

        // Give the user bot options and use their selection to assign the proper bot
        static IChatBot ChooseBot(List<IChatBot> botOptions)
        {
            Console.WriteLine();
            Console.WriteLine("Choose a bot to chat with:");
            for (int i = 0; i < botOptions.Count; i++)
            {
                IChatBot bot = botOptions[i];
                Console.WriteLine($"  {i}) {bot.Name}");
            }
            Console.Write("> ");

            // If the user chose an actual option assign the bot to be used
            try
            {
                int chosenIndex = int.Parse(Console.ReadLine());
                return botOptions[chosenIndex];
            }
            // Choose the first bot in the in the list since the user didn't follow directions
            catch
            {
                Console.WriteLine("You're bad at choosing. You'll get the bot I give you.");
                return botOptions[0];
            }
        }

        // Use the assigned bot with the IChatBot interface type to interact with the user
        static void HaveConversation(IChatBot bot)
        {
            Console.WriteLine();
            Console.WriteLine("Keep chatting as long as you want.");
            Console.WriteLine("Enter a blank line to end the conversation.");

            // If the bot.WelcomeText isn't null then print the string
            if (!string.IsNullOrWhiteSpace(bot.WelcomeText))
            {
                BotWriteLine(bot, bot.WelcomeText);
            }

            // Run this loop until the user input is null or whitespace
            while (true)
            {
                Console.WriteLine();
                Console.Write("> ");

                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                string response = bot.SendMessage(input);
                BotWriteLine(bot, response);
            }

            // Say goodbye!
            Console.WriteLine("The chat is over. Good-bye.");
        }

        // Let the bot say something to the user
        static void BotWriteLine(IChatBot bot, string text)
        {
            Console.Write($"{bot.Name}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
