using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatBots
{
    // NOTE: there's some pretty advanced stuff going on in here
    // You should not be exploring this class until you understand the rest of the app

    // This bot is using the IChatBot interface
    public class DuckDuckGoBot : IChatBot
    {
        // Set the private URL variable to the DuckDuckGo API search URL
        private const string URL = "https://api.duckduckgo.com/?format=json&pretty=1&atb=v252-1&q=";

        // Set the private _client variable to a new HttpClient type
        private HttpClient _client = new HttpClient();

        // Set the name of the bot
        public string Name => "Duck Duck Go API";

        // Set the welcome text for the bot
        public string WelcomeText => "I will search the Duck Duck Go Answer API for you.";


        // Send a message back to the user
        public string SendMessage(string message)
        {
            // Set the response of the DuckDuckGoResponse type to the search result of the API
            DuckDuckGoResponse response = DoSearch(message).Result;
            // If nothing was found then return the message notifying the user
            if (string.IsNullOrWhiteSpace(response.Abstract))
            {
                return $"Sorry, I couldn't find anything about '{message}'";
            }
            // Something was found so return it with the text, source, and URL where it was found
            return $@"{response.Abstract}

source: {response.AbstractSource}
url: {response.AbstractURL}";
        }

        // Search for the string the user entered via a private asynchronous method 
        private async Task<DuckDuckGoResponse> DoSearch(string criterion)
        {
            // await the response from the GetAsync method and return it to the 'response' variable
            HttpResponseMessage response = await _client.GetAsync(URL + WebUtility.UrlEncode(criterion));
            // Set the json variable to the content of the response as a string
            string json = await response.Content.ReadAsStringAsync();

            // Parse the json results into an instance of the DuckDuckGoResponse type.
            return JsonSerializer.Deserialize<DuckDuckGoResponse>(json);
        }

        private class DuckDuckGoResponse
        {

            public string Abstract { get; set; }
            public string AbstractSource { get; set; }
            public string AbstractURL { get; set; }
        }
    }
}