using Services;
using Dominio;

namespace ConsumindoApi;
class Program
{
  static async Task Main(string[] args)
  {
    HttpClient client = new HttpClient();
    ApiService servicoAPI = new ApiService(client);

    try
    {
      var clientes = await servicoAPI.GetClienteAsync();

      foreach (var cliente in clientes)
      Console.WriteLine($"ID: {cliente.ID}, Nome: {cliente.Nome}, Email: {cliente.Email}");
    }
    catch( HttpRequestException e)
    {
       Console.WriteLine("Erro ao fazer chamada de API: " + e.Message);
    }

  }

}