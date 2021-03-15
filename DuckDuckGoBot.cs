using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatBots
{
    // NOTE: there's some pretty advanced stuff going on in here
    // You should not be exploring this class until you understand the rest of the app
    public class DuckDuckGoBot : IChatBot
    {
        private const string URL = "https://api.duckduckgo.com/?format=json&pretty=1&atb=v252-1&q=";

        private HttpClient _client = new HttpClient();

        public string Name => "Duck Duck Go API";

        public string WelcomeText => "I will search the Duck Duck Go Answer API for you.";


        public string SendMessage(string message)
        {
            DuckDuckGoResponse response = DoSearch(message).Result;
            if (string.IsNullOrWhiteSpace(response.Abstract))
            {
                return $"Sorry, I couldn't find anything about '{message}'";
            }

            return $@"{response.Abstract}

source: {response.AbstractSource}
url: {response.AbstractURL}";
        }

        private async Task<DuckDuckGoResponse> DoSearch(string criterion)
        {
            HttpResponseMessage response = await _client.GetAsync(URL + WebUtility.UrlEncode(criterion));
            string json = await response.Content.ReadAsStringAsync();
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