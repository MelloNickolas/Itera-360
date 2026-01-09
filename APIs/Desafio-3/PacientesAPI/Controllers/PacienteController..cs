using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class PacienteController : Controller
{
  private readonly IPacienteRepository _pacientes;

  public PacienteController(IPacienteRepository pacientes)
  {
    _pacientes = pacientes;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllPacientes()
  {
    var listaPacientes = await _pacientes.GetAllPacientes();

    if (listaPacientes == null)
      return NotFound();

    return Ok(listaPacientes);
  }

  [HttpGet("{IDPaciente}")]
  public async Task<IActionResult> GetPacienteById([FromRoute] int IDPaciente)
  {
    var paciente = await _pacientes.GetPacienteById(IDPaciente);

    if (paciente == null)
      return NotFound();

    return Ok(paciente);
  }

  [HttpPost]
  public async Task<IActionResult> PostPaciente([FromBody] Paciente paciente)
  {
    var novoPaciente = await _pacientes.CreatePaciente(paciente);

    if (novoPaciente == null)
      return NotFound();

    return Ok(novoPaciente);
  }

  [HttpPut("{IDPaciente}")]
  public async Task<IActionResult> UpdatePaciente([FromRoute] int IDPaciente, [FromBody] Paciente paciente)
  {
    var pacienteExistente = await _pacientes.GetPacienteById(IDPaciente);
    if (pacienteExistente == null)
      return NotFound();

    paciente.IDPaciente = IDPaciente; // garante que atualiza o certo

    var atualizado = await _pacientes.UpdatePaciente(paciente);
    if (atualizado == null)
      return NotFound();

    return Ok(atualizado);
  }

  [HttpDelete("{IDPaciente}")]
  public async Task<IActionResult> DeletePaciente([FromRoute] int IDPaciente)
  {
    var pacienteDeletado = await _pacientes.DeletePaciente(IDPaciente);
    if (!pacienteDeletado!)
      return NotFound();

    return NoContent();
  }

  [HttpPut("{IDPaciente}/consultar")]
  public async Task<IActionResult> PutPacienteToEmConsulta([FromRoute] int IDPaciente, [FromBody] Paciente paciente)
  {
    var pacienteExistente = await _pacientes.GetPacienteById(IDPaciente);
    if (pacienteExistente == null)
      return NotFound();

    if (pacienteExistente.Ativo == true)
      return BadRequest("O paciente já está em consulta!");

    var atualizado = await _pacientes.UpdatePacienteToEmConsulta(IDPaciente);

    return Ok(atualizado);
  }

  [HttpPut("{IDPaciente}/alta")]
  public async Task<IActionResult> PutPacienteToAlta([FromRoute] int IDPaciente, [FromBody] Paciente paciente)
  {
    var pacienteExistente = await _pacientes.GetPacienteById(IDPaciente);
    if (pacienteExistente == null)
      return NotFound();

    if (pacienteExistente.Ativo == false)
      return BadRequest("O paciente já está com ALTA!");

    var atualizado = await _pacientes.UpdatePacienteToAlta(IDPaciente);
    return Ok(atualizado);
  }
}