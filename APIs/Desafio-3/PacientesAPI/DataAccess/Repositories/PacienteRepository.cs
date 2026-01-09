
using System.Data;
using Dominio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class PacienteRepository : IPacienteRepository
{
  private readonly Contexto _contexto;

  public PacienteRepository(Contexto contexto)
  {
    _contexto = contexto;
  }


  public async Task<Paciente> CreatePaciente(Paciente paciente)
  {
    _contexto.Pacientes.Add(paciente);
    await _contexto.SaveChangesAsync();
    return paciente;
  }

  public async Task<bool> DeletePaciente(int IdPaciente)
  {
    var VerificarPaciente = await _contexto.Pacientes.FindAsync(IdPaciente);

    if (VerificarPaciente == null)
      return false;

    _contexto.Pacientes.Remove(VerificarPaciente);
    await _contexto.SaveChangesAsync();

    return true;
  }

  public async Task<IEnumerable<Paciente?>> GetAllPacientes()
  {
    return await _contexto.Pacientes.ToListAsync();
  }

  public async Task<Paciente?> GetPacienteById(int IdPaciente)
  {
    var BuscarPaciente = await _contexto.Pacientes.FindAsync(IdPaciente);
    return BuscarPaciente;
  }

  public async Task<Paciente?> UpdatePaciente(Paciente paciente)
  {
    var PacienteExistente = await _contexto.Pacientes.FindAsync(paciente.IDPaciente);

    if (PacienteExistente == null)
      return null;

    _contexto.Entry(PacienteExistente).CurrentValues.SetValues(paciente);
    await _contexto.SaveChangesAsync();

    return PacienteExistente;
  }

  public async Task<Paciente?> UpdatePacienteToAlta(int IdPaciente)
  {
    var PacienteExistente = await _contexto.Pacientes.FindAsync(IdPaciente);

    if (PacienteExistente == null)
      return null;

    PacienteExistente.Ativo = false;
    await _contexto.SaveChangesAsync();

    return PacienteExistente;
  }

  public async Task<Paciente?> UpdatePacienteToEmConsulta(int IdPaciente)
  {
    var PacienteExistente = await _contexto.Pacientes.FindAsync(IdPaciente);

    if (PacienteExistente == null)
      return null;

    PacienteExistente.Ativo = true;
    await _contexto.SaveChangesAsync();

    return PacienteExistente;
  }
}
