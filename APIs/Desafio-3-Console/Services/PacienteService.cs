using System.Text;
using Dominio;
using Newtonsoft.Json;

namespace Services;

public class PacienteService
{
  private readonly HttpClient _client;
  private const string BaseUrl = "http://localhost:5261/api/Paciente";

  public PacienteService(HttpClient client)
  {
    _client = client;
  }

  public async Task<List<Paciente>> GetPacientesAsync()
  {
    HttpResponseMessage responseMessage = await _client.GetAsync(BaseUrl);
    responseMessage.EnsureSuccessStatusCode();

    string json = await responseMessage.Content.ReadAsStringAsync();
    var pacientes = JsonConvert.DeserializeObject<List<Paciente>>(json);

    return pacientes ?? new List<Paciente>();
  }

  public async Task<Paciente?> GetPacienteByIdAsync(int IDPaciente)
  {
    HttpResponseMessage responseMessage = await _client.GetAsync($"{BaseUrl}/{IDPaciente}");
    
    if (!responseMessage.IsSuccessStatusCode)
      return null;

    string json = await responseMessage.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<Paciente>(json);
  }

  public async Task<int> AddPacienteAsync(Paciente paciente)
  {
    string json = JsonConvert.SerializeObject(paciente);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage responseMessage = await _client.PostAsync(BaseUrl, content);
    responseMessage.EnsureSuccessStatusCode();

    string result = await responseMessage.Content.ReadAsStringAsync();
    var pacienterCriado = JsonConvert.DeserializeObject<Paciente>(result);

    return pacienterCriado!.IDPaciente;
  }

  public async Task<bool> UpdatePacienteAsync(int IDPaciente, Paciente paciente)
  {
    string json = JsonConvert.SerializeObject(paciente);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage responseMessage = await _client.PutAsync($"{BaseUrl}/{IDPaciente}", content);
    return responseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> AltaAsync(int IDPaciente)
  {
    HttpResponseMessage responseMessage = await _client.PutAsync($"{BaseUrl}/{IDPaciente}/alta", null);
    return responseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> ConsultarAsync(int IDPaciente)
  {
    HttpResponseMessage responseMessage = await _client.PutAsync($"{BaseUrl}/{IDPaciente}/consultar", null);
    return responseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeletePacienteAsync(int IDPaciente)
  {
    HttpResponseMessage responseMessage = await _client.DeleteAsync($"{BaseUrl}/{IDPaciente}");
    return responseMessage.IsSuccessStatusCode;
  }
}