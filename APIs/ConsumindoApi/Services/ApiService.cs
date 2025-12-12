
using Dominio;
using Newtonsoft.Json;


namespace Services;
public class ApiService
{
  private readonly HttpClient _cliente;

  public ApiService(HttpClient cliente)
  {
    _cliente = cliente;
  }
  //Como disswe, aqui temos que retornar uma lista, pois foi oque definimos na nossa API
  public async Task<List<Cliente>> GetClienteAsync()
  {
    HttpResponseMessage response = await _cliente.GetAsync("http://localhost:5217/api/Cliente");
    response.EnsureSuccessStatusCode();
    string json = await response.Content.ReadAsStringAsync();
    // return JsonConvert.DeserializeObject<Cliente>(json); Isso so retorna se for por ID, algo unico, nos fizemos uma lista
    
    var clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
    return clientes ?? new List<Cliente>(); // caso nao tenha nenhum cliente ele retorna uma lista vazia

  }
}