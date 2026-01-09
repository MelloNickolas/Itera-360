using Dominio;
public interface IPacienteRepository
{

  //Métodos comuns para realizar, estou usando TASK para nao travar meu codigo que nem recomendaram na revisão!
  Task<IEnumerable<Paciente?>> GetAllPacientes();
  Task<Paciente?> GetPacienteById(int IdPaciente);
  Task<Paciente> CreatePaciente(Paciente paciente);
  Task<Paciente?> UpdatePaciente(Paciente paciente);
  Task<bool> DeletePaciente(int IdPaciente);


  //ENDPOINTS SOLICITADOS
  Task<Paciente?> UpdatePacienteToEmConsulta(int IdPaciente);
  Task<Paciente?> UpdatePacienteToAlta(int IdPaciente);
}