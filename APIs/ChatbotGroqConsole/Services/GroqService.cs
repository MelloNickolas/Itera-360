using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Models;

namespace Services
{
  public class GroqService
  {
    private readonly HttpClient _httpClient;
    private const string Endpoint = "https://api.groq.com/openai/v1/chat/completions";

    public GroqService(string apiKey)
    {
      _httpClient = new HttpClient();
      _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> EnviarAsync(List<Message> mensagens)
    {
      var request = new ChatRequest
      {
        model = "llama-3.3-70b-versatile",
        messages = mensagens,
        temperature = 0.7,
        max_tokens = 512
      };

      string json = JsonConvert.SerializeObject(request);
      using var content = new StringContent(json, Encoding.UTF8, "application/json");

      HttpResponseMessage response = await _httpClient.PostAsync(Endpoint, content);
      string responseBody = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode)
        return $"[ERRO {(int)response.StatusCode}] {responseBody}";

      var chatResponse = JsonConvert.DeserializeObject<ChatResponse>(responseBody);
      return chatResponse?.choices?[0]?.message?.content ?? "(sem resposta)";
    }
  }
}
