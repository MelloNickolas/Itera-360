using Dominio;
using Newtonsoft.Json;
using System.Text;

namespace Services;

public class JogoService
{
  private readonly HttpClient _client;
  private const string BaseUrl = "http://localhost:5203/api/jogo";

  public JogoService(HttpClient client)
  {
    _client = client;
  }

  // LISTAR TODOS OS JOGOS
  public async Task<List<Jogo>> GetJogosAsync()
  {
    HttpResponseMessage response = await _client.GetAsync(BaseUrl);
    response.EnsureSuccessStatusCode();

    string json = await response.Content.ReadAsStringAsync();
    var jogos = JsonConvert.DeserializeObject<List<Jogo>>(json);

    return jogos ?? new List<Jogo>();
  }

  // OBTER JOGO POR ID
  public async Task<Jogo> GetJogoByIdAsync(int id)
  {
    HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}/{id}");

    if (!response.IsSuccessStatusCode)
      return null;

    string json = await response.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<Jogo>(json);
  }

  // ADICIONAR NOVO JOGO
  public async Task<int> AddJogoAsync(Jogo jogo)
  {
    string json = JsonConvert.SerializeObject(jogo);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _client.PostAsync(BaseUrl, content);
    response.EnsureSuccessStatusCode();

    string result = await response.Content.ReadAsStringAsync();
    var jogoCriado = JsonConvert.DeserializeObject<Jogo>(result);

    return jogoCriado!.IDJogo;
  }

  // ATUALIZAR JOGO
  public async Task<bool> UpdateJogoAsync(int id, Jogo jogo)
  {
    string json = JsonConvert.SerializeObject(jogo);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await _client.PutAsync($"{BaseUrl}/{id}", content);
    return response.IsSuccessStatusCode;
  }

  // ALUGAR JOGO
  public async Task<bool> AlugarJogoAsync(int id)
  {
    HttpResponseMessage response = await _client.PutAsync($"{BaseUrl}/{id}/Alugar", null);
    return response.IsSuccessStatusCode;
  }

  // DEVOLVER JOGO
  public async Task<bool> DevolverJogoAsync(int id)
  {
    HttpResponseMessage response = await _client.PutAsync($"{BaseUrl}/{id}/Devolver", null);
    return response.IsSuccessStatusCode;
  }

  // REMOVER JOGO
  public async Task<bool> DeleteJogoAsync(int id)
  {
    HttpResponseMessage response = await _client.DeleteAsync($"{BaseUrl}/{id}");
    return response.IsSuccessStatusCode;
  }
}
