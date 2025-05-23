using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        string prompt = "Give me a creative journal prompt for self-reflection.";
        string response = await GetChatGptResponse(prompt);
        Console.WriteLine("Prompt: " + response);
    }

    static async Task<string> GetChatGptResponse(string userPrompt)
{
    var apiKey = ""; // Replace with your actual key
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "user", content = userPrompt }
        }
    };

    var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

    var responseString = await response.Content.ReadAsStringAsync();

    // Log the full JSON response for debugging
    Console.WriteLine("\nFull API response:\n" + responseString);

    using var document = JsonDocument.Parse(responseString);

    // Try to get expected data
    var root = document.RootElement;

    if (root.TryGetProperty("choices", out JsonElement choices))
    {
        var messageContent = choices[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return messageContent;
    }
    else if (root.TryGetProperty("error", out JsonElement error))
    {
        var errorMessage = error.GetProperty("message").GetString();
        return $"Error from API: {errorMessage}";
    }
    else
    {
        return "Unexpected response format from API.";
    }
}

}
