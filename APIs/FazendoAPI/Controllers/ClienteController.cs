using Microsoft.AspNetCore.Mvc;
using Dominio;

//URL /cliente, ele vai entender que é cliente por causa da ROUTE
[Route("api/[controller]")]
[ApiController] //Attribute, um metadado avisando para o Dotnet que é uma API
public class ClienteController : Controller
{
  private readonly List<Cliente> _clientes;

  public ClienteController()
  {
    _clientes = new List<Cliente>();
    _clientes.Add(new Cliente { ID = 1, Nome = "Nickolas", Email = "nickolasphmello10@gmail.com" });
    _clientes.Add(new Cliente { ID = 2, Nome = "Pedro", Email = "pedroloiro@gmail.com" });
    _clientes.Add(new Cliente { ID = 3, Nome = "Mauricio", Email = "mauro@gmail.com" });
  }

  [HttpGet("{IDCliente}")] //definindo o tipo doo metodo
  // ele vai colocar /ID no fim da rota para voce pudar puxar esses dados
  public IActionResult GetClienteByID([FromRoute]int IDCliente)
  {
    var cliente = _clientes.FirstOrDefault(c => c.ID == IDCliente); // relacionando o ID com o parametro do construtor

    if(cliente == null)
    {
      return NotFound();
    }
    else
    {
      return Ok(cliente); //retorna o 202 e o cliente
    }
  }

  [HttpGet]
  public IActionResult GetAllCliente()
  {
    return Ok(_clientes);
  }

  [HttpPost]
  public IActionResult PostCliente([FromBody] Cliente cliente)
  {
    cliente.ID = _clientes.Count() + 1;

    _clientes.Add(cliente);

    return Ok(new {ID = cliente.ID});
  }

  // PUT: api/Cliente/IDcliente
  [HttpPut("{IDCliente}")]
  public IActionResult UpdateCliente([FromRoute] int IDCliente, [FromBody] Cliente cliente)
  {
    var clienteExistente = _clientes.FirstOrDefault(c => c.ID == cliente.ID);

    if(clienteExistente == null)
    {
      return NotFound();
    }

    clienteExistente.Nome = cliente.Nome;
    clienteExistente.Email = cliente.Email;

    return NoContent();
  }

  // DELETE: api/Cliente/IDcliente
  [HttpDelete("{IDCliente}")] 
  public IActionResult DeleteCliente([FromRoute] int IDCliente)
  {
    var cliente = _clientes.FirstOrDefault(c => c.ID == IDCliente);
    if(cliente == null)
    {
      return NotFound();
    }

    _clientes.Remove(cliente);

    return NoContent();
  }
}